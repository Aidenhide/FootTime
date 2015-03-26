using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elifoot.Models;
using System.Threading;

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
                System.Threading.Thread.Sleep(1000);
                time++;
            }
            // Next journey
        }

        private void Simulate(int time)
        {
            using (var db = new TeamContext())
            {
                foreach (League league in db.Leagues)
                {
                    var journey = db.Journeys.Where(x => x.JourneyId == league.CurrentJourney).FirstOrDefault();
                    foreach (Match match in journey.Matchs)
                    {
                        match.Time = time;
                        CalculateMatch(match);
                    }
                }
                db.SaveChanges();
            }
        }

        private void CalculateMatch(Match match)
        {
            var house = Randomizer.GetRandomizer.Next(100);
            var visitor = Randomizer.GetRandomizer.Next(100);
            if (house == 50)
            {
                match.HouseScore++;
            }
            if (visitor == 50)
            {
                match.VisitorScore++;
            }

            //if(WhoHasTheBall(match.House, match.Visitor) == 0) {
            //    Attacking(match.House, match.Visitor);
            //}
        }


        private int WhoHasTheBall(Team a, Team b) 
        {
            var apower = a.Players.Where(x => x.Position == PlayerPosition.Midfielder).Sum(x => x.OverallPower);
            var bpower = b.Players.Where(x => x.Position == PlayerPosition.Midfielder).Sum(x => x.OverallPower);
            apower = apower + Randomizer.GetRandomizer.Next(50);
            bpower = bpower + Randomizer.GetRandomizer.Next(50);

            if (apower > bpower)
            {
                return 0;
            }
            return 1;
        }

        private void Attacking(Team Attacker, Team Defender)
        {
            var apower = Attacker.Players.Where(x => x.Position == PlayerPosition.Forward).Sum(x => x.OverallPower);
            var bpower = Defender.Players.Where(x => x.Position == PlayerPosition.Defender).Sum(x => x.OverallPower);

            apower = apower + Randomizer.GetRandomizer.Next(50);
            bpower = bpower + Randomizer.GetRandomizer.Next(50);

            if (apower > bpower)
            {
                var count = Attacker.Players.Where(x => x.Position == PlayerPosition.Forward).Count();
                var r = Randomizer.GetRandomizer.Next(count);
                var shooter = Attacker.Players.Where(x => x.Position == PlayerPosition.Forward).ToList()[r];
                var keeper = Defender.Players.Where(x => x.Position == PlayerPosition.GoalKeeper);
                // YOLO
            }

            
        }
    }
}