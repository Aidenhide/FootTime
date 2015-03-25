using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elifoot.Models;

namespace Elifoot.Logic
{
    public class MatchManager
    {
        public MatchManager()
        {

        }

        public void beginSimulation()
        {
            using (var db = new TeamContext())
            {
                var time = 0;
                while (time < 90)
                {
                    Simulate(time);
                    System.Threading.Thread.Sleep(1000);
                    time++;
                }
            }

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
            if (house == 50)
            {
                match.VisitorScore++;
            }
        }
    }
}