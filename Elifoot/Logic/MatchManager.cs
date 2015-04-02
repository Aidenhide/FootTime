using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elifoot.Models;
using System.Threading;
using System.Data.Entity;
using System.IO;

namespace Elifoot.Logic
{
    public class MatchManager
    {
        public MatchManager()
        {

        }

        public void beginSimulation()
        {
            Thread s = new Thread(new ThreadStart(ThreadSimulation));
            s.Start();
        }

        public void ThreadSimulation()
        {
            var time = 0;
            while (time < 91)
            {
                Simulate(time);
                System.Threading.Thread.Sleep(10);
                time++;
            }
            // Next journey
        }

        private void Simulate(int time)
        {
            using (var db = new TeamContext())
            {
                var leagues = db.Leagues.Include(x => x.Journeys).ToList();
                var journeys = db.Journeys.Include(x => x.Matchs).ToList();
                foreach (League league in leagues)
                {
                    var journey = journeys.Where(x => x.JourneyId == league.CurrentJourney).FirstOrDefault();
                    var allmatchs = db.Matches.Include(x => x.House).Include(x => x.Visitor).ToList();
                    var matchs = allmatchs.Where(x => journey.Matchs.Contains(x)).ToList();
                    foreach (Match match in matchs)
                    {
                        journey.Time = time;
                        match.Time = time;
                        CalculatePlay(match);
                        if (time == 90)
                        {
                            double res = 100 * match.HouseBallTime / 90;
                            match.HouseBallTime = (int)Math.Round(res, 0);
                            res = 100 * match.VisitorBallTime / 90;
                            match.VisitorBallTime = (int)Math.Round(res, 0);
                        }
                    }
                }
                db.SaveChanges();
            }
        }

        private void CalculatePlay(Match m)
        {
            if (FaultEvent(m))
            {
                File.AppendAllText(@"C:\Users\Fabio Pacheco\Desktop\log.txt", "FALTA\n");
                return;
            }
            File.AppendAllText(@"C:\Users\Fabio Pacheco\Desktop\log.txt", "-------------\n");

            var apower = m.House.Players.Where(x => x.Position == PlayerPosition.Midfielder).Sum(x => x.OverallPower);
            var bpower = m.Visitor.Players.Where(x => x.Position == PlayerPosition.Midfielder).Sum(x => x.OverallPower);

            var bpowerT = bpower + Randomizer.GetRandomizer.Next((int)Math.Floor(apower));
            var apowerT = apower + Randomizer.GetRandomizer.Next((int)Math.Floor(bpower));
            
            if (apowerT > bpowerT)
            {
                m.HouseBallTime++;
                HouseAttacking(m);
                return;
            }
            m.VisitorBallTime++;
            VisitiorAttacking(m);
            return;
        }

        private bool FaultEvent(Match m)
        {
            if (CardEvent(m))
            {
                return true;
            }
            var chance = Randomizer.GetRandomizer.Next(100);
            if (chance < 5)
            {
                m.VisitorBallTime++;
                m.HouseFaults++;
                return true;
            }
            if (chance > 95)
            {
                m.HouseBallTime++;
                m.VisitorFaults++;
                return true;
            }
            return false;
        }

        private bool CardEvent(Match m)
        {
            var chance = Randomizer.GetRandomizer.Next(100);
            if (chance == 1)
            {
                m.VisitorBallTime++;
                m.HouseFaults++;
                var player = m.House.Players.ToList()[Randomizer.GetRandomizer.Next(m.House.Players.Count())];

                var ge = new GameEvent();
                chance = Randomizer.GetRandomizer.Next(100);
                if (chance < 3)
                {
                    ge.Type = GameEventType.RedCard;
                    ge.Icon = "../Content/Images/RedCard15.png";
                }
                else
                {
                    ge.Type = GameEventType.YellowCard;
                    ge.Icon = "../Content/Images/yellowCard15.png";
                }
                ge.Time = m.Time;
                ge.PlayerName = player.Name;
                ge.Location = GameEventLocation.House;
                m.GameEvents.Add(ge);
                return true;
            }
            if (chance == 98)
            {
                m.HouseBallTime++;
                m.VisitorFaults++;
                var player = m.Visitor.Players.ToList()[Randomizer.GetRandomizer.Next(m.Visitor.Players.Count())];

                var ge = new GameEvent();
                chance = Randomizer.GetRandomizer.Next(100);
                if (chance < 3)
                {
                    ge.Type = GameEventType.RedCard;
                    ge.Icon = "../Content/Images/RedCard15.png";
                }
                else
                {
                    ge.Type = GameEventType.YellowCard;
                    ge.Icon = "../Content/Images/yellowCard15.png";
                }
                ge.Time = m.Time;
                ge.PlayerName = player.Name;
                ge.Location = GameEventLocation.Visitor;
                m.GameEvents.Add(ge);
                return true;
            }
            return false;
        }

        private void HouseAttacking(Match m)
        {
            var Attacker = m.House;
            var Defender = m.Visitor;
            var apower = Attacker.Players.Where(x => x.Position == PlayerPosition.Forward).Sum(x => x.OverallPower);
            var bpower = Defender.Players.Where(x => x.Position == PlayerPosition.Defender).Sum(x => x.OverallPower);

            apower = apower + Randomizer.GetRandomizer.Next((int)Math.Floor(bpower));
            bpower = bpower + Randomizer.GetRandomizer.Next((int)Math.Floor(apower));


            if (apower > bpower)
            {
                if (HouseShoots(m))
                {
                    return;
                }
                else
                {
                    HouseCornerEvent(m);
                }
            }
            return;
        }

        private void VisitiorAttacking(Match m)
        {
            var Attacker = m.Visitor;
            var Defender = m.House;
            var apower = Attacker.Players.Where(x => x.Position == PlayerPosition.Forward).Sum(x => x.OverallPower);
            var bpower = Defender.Players.Where(x => x.Position == PlayerPosition.Defender).Sum(x => x.OverallPower);

            apower = apower + Randomizer.GetRandomizer.Next((int)Math.Floor(bpower));
            bpower = bpower + Randomizer.GetRandomizer.Next((int)Math.Floor(apower));

            if (apower > bpower)
            {
                if (VisitorShoots(m))
                {
                    return;
                }
                else
                {
                    VisitorCornerEvent(m);
                }
            }
            return;
        }

        private bool HouseShoots(Match m)
        {
            m.HouseShots++;
            var count = m.House.Players.Where(x => x.Position == PlayerPosition.Forward).Count();
            var r = Randomizer.GetRandomizer.Next(count);
            var shooter = m.House.Players.Where(x => x.Position == PlayerPosition.Forward).ToList()[r];
            var keeper = m.Visitor.Players.Where(x => x.Position == PlayerPosition.GoalKeeper).FirstOrDefault();
            // YOLO
            var shootPower = shooter.OverallPower - keeper.OverallPower;

            if (shootPower < 0) shootPower = 5;
            else shootPower += 5;
            var luck = Randomizer.GetRandomizer.Next(100);
            if (luck < shootPower)
            {
                m.HouseScore++;
                var ge = new GameEvent(GameEventType.Goal);
                ge.Time = m.Time;
                ge.PlayerName = shooter.Name;
                ge.Location = GameEventLocation.House;
                ge.Icon = "../Content/Images/goal15.png";
                m.GameEvents.Add(ge);
                return true;
            }
            return false;
        }

        private bool VisitorShoots(Match m)
        {
            m.VisitorShots++;
            var count = m.Visitor.Players.Where(x => x.Position == PlayerPosition.Forward).Count();
            var r = Randomizer.GetRandomizer.Next(count);
            var shooter = m.Visitor.Players.Where(x => x.Position == PlayerPosition.Forward).ToList()[r];
            var keeper = m.House.Players.Where(x => x.Position == PlayerPosition.GoalKeeper).FirstOrDefault();
            // YOLO
            var shootPower = shooter.OverallPower - keeper.OverallPower;

            if (shootPower < 0) shootPower = 5;
            else shootPower += 5;


            var luck = Randomizer.GetRandomizer.Next(100);
            if (luck < shootPower)
            {
                m.VisitorScore++;
                var ge = new GameEvent(GameEventType.Goal);
                ge.Time = m.Time;
                ge.PlayerName = shooter.Name;
                ge.Location = GameEventLocation.Visitor;
                ge.Icon = "../Content/Images/goal15.png";
                m.GameEvents.Add(ge);
                return true;
            }
            return false;
        }

        private bool HouseCornerEvent(Match m)
        {
            var chance = Randomizer.GetRandomizer.Next(100);
            if (chance < 25)
            {
                m.HouseCorners++;
                if (HouseShoots(m))
                {
                    return true;
                }
                else
                {
                    return HouseCornerEvent(m);
                }
            }
            return false;
        }

        private bool VisitorCornerEvent(Match m)
        {
            var chance = Randomizer.GetRandomizer.Next(100);
            if (chance < 25)
            {
                m.VisitorCorners++;
                if (VisitorShoots(m))
                {
                    return true;
                }
                else
                {
                    return VisitorCornerEvent(m);
                }
            }
            return false;
        }

        private void nextJorney(List<League> leagues)
        {
            foreach (League l in leagues)
            {
                var actual = l.Journeys.Where(x => x.JourneyId == l.CurrentJourney).FirstOrDefault();
                var next = l.Journeys.Where(x => x.Number == actual.Number + 1).FirstOrDefault();

                if (next != null)
                {
                    l.CurrentJourney = next.JourneyId;
                }
                else
                {
                    // Acabou a temporada
                }
            }
        }
    }
}