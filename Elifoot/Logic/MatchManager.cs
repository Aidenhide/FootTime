﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elifoot.Models;
using System.Threading;
using System.Data.Entity;
using System.IO;
using System.Diagnostics;

namespace Elifoot.Logic
{


    public delegate void NotificationsReceivedDelegate(bool humanRequired, GameEvent gameEvent);

    public static class MatchManager
    {
        public static event NotificationsReceivedDelegate NewNotificationsReceived;

        private static Thread game;

        public static bool IsPaused { get; set; }

        public static Thread Game
        {
            get { return game; }
            set { game = value; }
        }

        public static void beginSimulation()
        {
            if (game == null)
            {
                game = new Thread(new ThreadStart(ThreadSimulation));
                IsPaused = false;
                game.Start();
            }
            else
            {
                if (game.ThreadState == System.Threading.ThreadState.Running)
                {
                    // do nothing
                }
                if (game.ThreadState == System.Threading.ThreadState.Unstarted
                    || game.ThreadState == System.Threading.ThreadState.Aborted
                        || game.ThreadState == System.Threading.ThreadState.Stopped
                            || game.ThreadState == System.Threading.ThreadState.Suspended
                                || game.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
                {
                    game.Abort();
                    game = new Thread(new ThreadStart(ThreadSimulation));
                    IsPaused = false;
                    game.Start();
                }
            }



        }

        public static void ThreadSimulation()
        {
            try
            {
                var time = 0;
                using (var db = new TeamContext())
                {
                    var leagues = db.Leagues.Include(x => x.Journeys).FirstOrDefault();
                    var journey = leagues.Journeys.Where(x => x.JourneyId == leagues.CurrentJourney).FirstOrDefault();
                    time = journey.Time;
                }

                var running = true;
                while (running)
                {
                    if (!IsPaused && time < 91)
                    {
                        Simulate(time);
                        System.Threading.Thread.Sleep(50);
                        if (NewNotificationsReceived != null)
                        {
                            NewNotificationsReceived(false, null);
                        }
                        time++;
                    }
                    if (time > 90)
                    {
                        using (var db = new TeamContext())
                        {
                            var leagues = db.Leagues.Include(x => x.Journeys).ToList();
                            System.Threading.Thread.Sleep(1000);
                            nextJorney(leagues);
                            System.Threading.Thread.Sleep(1000);
                            db.SaveChanges();
                        }
                        running = false;
                    }
                    if (IsPaused)
                        System.Threading.Thread.Sleep(1000);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("ERRROOO:" + e.Message);
            }
        }

        private static void Simulate(int time)
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
                    if (time == 90)
                    {
                        journey.IsOver = true;
                    }

                }
                db.SaveChanges();
            }
        }

        private static void CalculatePlay(Match m)
        {
            if (FaultEvent(m))
            {
                return;
            }

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

        private static bool FaultEvent(Match m)
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

        private static bool CardEvent(Match m)
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

        private static void HouseAttacking(Match m)
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

        private static void VisitiorAttacking(Match m)
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

        private static bool HouseShoots(Match m)
        {
            m.HouseShots++;

            var shooter = getShooter(m.House);
            while (shooter == null)
            {
                shooter = getShooter(m.House);
            }

            var keeper = m.Visitor.Players.Where(x => x.Position == PlayerPosition.GoalKeeper).FirstOrDefault();
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

                try
                {
                    ge.Team = m.HouseName;
                    ge.OtherTeam = m.VisitorName;
                }
                catch (Exception e)
                {
                    Debug.WriteLine("ERRO 4 " + e.Message);
                }
                m.GameEvents.Add(ge);

                if ((m.IsHouseHuman || m.IsVisitorHuman) && NewNotificationsReceived != null)
                {
                    //IsPaused = true;
                    NewNotificationsReceived(true, ge);
                }
                return true;
            }
            return false;
        }

        private static bool VisitorShoots(Match m)
        {
            m.VisitorShots++;

            var shooter = getShooter(m.Visitor);
            while (shooter == null)
            {
                shooter = getShooter(m.Visitor);
            }

            var keeper = m.House.Players.Where(x => x.Position == PlayerPosition.GoalKeeper).FirstOrDefault();
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

                try
                {
                    ge.Team = m.VisitorName;
                    ge.OtherTeam = m.HouseName;
                    m.GameEvents.Add(ge);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("ERRO 5 " + e.Message);
                }

                if ((m.IsHouseHuman || m.IsVisitorHuman) && NewNotificationsReceived != null)
                {
                    //IsPaused = true;
                    NewNotificationsReceived(true, ge);
                }
                return true;
            }
            return false;
        }

        private static Player getShooter(Team m)
        {
            var r = Randomizer.GetRandomizer.Next(10);
            var count = 0;
            var shooter = new Player();
            if (r > 5)
            {
                count = m.Players.Where(x => x.Position == PlayerPosition.Forward).Count();
                r = Randomizer.GetRandomizer.Next(count);
                return m.Players.Where(x => x.Position == PlayerPosition.Forward).ToList()[r];
            }
            else if ((r > 2 && r <= 5) || count == 0)
            {
                count = m.Players.Where(x => x.Position == PlayerPosition.Midfielder).Count();
                r = Randomizer.GetRandomizer.Next(count);
                return m.Players.Where(x => x.Position == PlayerPosition.Midfielder).ToList()[r];
            }
            else if (r <= 2 || count == 0)
            {
                count = m.Players.Where(x => x.Position == PlayerPosition.Defender).Count();
                r = Randomizer.GetRandomizer.Next(count);
                return m.Players.Where(x => x.Position == PlayerPosition.Defender).ToList()[r];
            }
            return null;
        }



        private static bool HouseCornerEvent(Match m)
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

        private static bool VisitorCornerEvent(Match m)
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

        private static void nextJorney(List<League> leagues)
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