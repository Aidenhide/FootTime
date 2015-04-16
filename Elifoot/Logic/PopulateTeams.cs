using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elifoot.Models;
using System.Drawing;

namespace Elifoot.Logic
{
    public static class PopulateTeams
    {
        private static Random rand = new Random();

        public static void CreateLeagues()
        {
            using (var db = new TeamContext())
            {
                var prize = 100000000;
                for (int i = 1; i < 5; i++)
                {
                    var league = new League(i + "ª Divisão");
                    league.Division = i;
                    league.FirstPrize = prize / i;
                    league.SecondPrize = league.FirstPrize / 2;
                    league.ThirdPrize = league.ThirdPrize / 2;
                    league.Teams = CreateTeams(i);
                    CreateJourneys(ref league);
                    db.Leagues.Add(league);

                }
                db.SaveChanges();

                createManagers();
                assignManagersToTeams();

                foreach (League l in db.Leagues)
                {
                    l.CurrentJourney = l.Journeys[0].JourneyId;
                }
                db.SaveChanges();
            }
        }

        public static List<Team> CreateTeams(int division)
        {

            var nameGenerator = new NameGenerator();
            var count = nameGenerator.Names.Count;
            List<Team> teamList = new List<Team>();
            for (int i = 0; i < 10; i++)
            {
                var team = new Team(nameGenerator.Names[rand.Next(count)]);
                team.Money = 10000000 / division;
                team.Moral = 100;
                team.humanControl = false;
                CreatePlayers(team, division);

                Random randomGen = Randomizer.GetRandomizer;
                KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                Color text = Color.FromKnownColor(names[randomGen.Next(names.Length)]);
                Color background = Color.FromKnownColor(names[randomGen.Next(names.Length)]);

                while (!checkColorDiff(text,background))
                {
                    text = Color.FromKnownColor(names[randomGen.Next(names.Length)]);
                    background = Color.FromKnownColor(names[randomGen.Next(names.Length)]);
                }

                team.ForegroundColor = String.Format("rgb({0},{1},{2})",text.R, text.G, text.B);
                team.BackgroundColor = String.Format("rgb({0},{1},{2})",background.R, background.G, background.B);

                teamList.Add(team);

            }
            return teamList;
        }

        public static bool checkColorDiff(Color Text, Color Background)
        {

            var hue = Math.Max((Text.R - Background.R),(Background.R - Text.R)) + 
                Math.Max((Text.G - Background.G),(Background.G - Text.G)) +
                    Math.Max((Text.B - Background.B),(Background.B - Text.B));
            if(hue < 500) 
            {
                return false;
            }

            var bright = Math.Abs(((Text.R*299) + (Text.G*587) + (Text.B*114)) - 
                ((Background.R*299) + (Background.G*587) + (Background.B*114)));

            if (bright < 125)
            {
                return false;
            }
            return true;
        }


        public static bool CreateJourneys(ref League l)
        {
            var teams = l.Teams;
            //1st round
            List<Match> firstRoundMatches = new List<Match>();

            int journeyCount = 0;

            List<Team> homeTeams = new List<Team>();
            List<Team> awayTeams = new List<Team>();

            Team controlTeam = teams[2];

            int controlVar = 0;

            homeTeams = teams.Skip(0).Take(teams.Count / 2).ToList();
            awayTeams = teams.Skip(teams.Count / 2).Take(teams.Count / 2).ToList();
            controlTeam = homeTeams[1];

            List<Journey> leagueJourneys = new List<Journey>();

            while (homeTeams[1].TeamId != controlTeam.TeamId || journeyCount <= 8)
            {
                Journey j = new Journey(journeyCount + 1);
                j.IsOver = false;

                for (int i = 0; i < homeTeams.Count; i++)
                {
                    Match m;
                    if (controlVar % 2 == 0)
                    {
                        m = new Match(homeTeams[i], awayTeams[i]);
                        getTeamsColors(m, homeTeams[i], awayTeams[i]);
                    }
                    else
                    {
                        m = new Match(awayTeams[i], homeTeams[i]);
                        getTeamsColors(m, awayTeams[i], homeTeams[i]);
                    }
                    j.Matchs.Add(m);
                }
                leagueJourneys.Add(j);
                l.Journeys.Add(j);
                journeyCount++;

                awayTeams.Add(homeTeams.Last());
                homeTeams.Remove(homeTeams.Last());

                homeTeams.Insert(1, awayTeams.First());
                awayTeams.RemoveAt(0);
            }
            /// 2nd round
            /// 

            for (int i = 0; i < journeyCount; i++)
            {
                Journey j = leagueJourneys[i];

                Journey srJourney = new Journey((journeyCount + i + 1));
                srJourney.IsOver = false;

                foreach (Match frMatch in j.Matchs)
                {
                    Match srMatch = new Match(frMatch.Visitor, frMatch.House);
                    getTeamsColors(srMatch, frMatch.Visitor, frMatch.House);
                    srJourney.Matchs.Add(srMatch);
                }

                leagueJourneys.Add(srJourney);
                l.Journeys.Add(srJourney);
            }
            return true;
        }

        public static void getTeamsColors(Match m, Team house, Team visitor)
        {
            m.HouseBackgroundColor = house.BackgroundColor;
            m.HouseForegroundColor = house.ForegroundColor;
            m.VisitorBackgroundColor = visitor.BackgroundColor;
            m.VisitorForegroundColor = visitor.ForegroundColor;
        }


        public static void CreatePlayers(Team team, int division)
        {
            for (int i = 0; i < 3; i++)
            {
                Player p = generatePlayer(division, PlayerPosition.GoalKeeper);
                team.Players.Add(p);
            }
            for (int i = 0; i < 6; i++)
            {
                Player p = generatePlayer(division, PlayerPosition.Defender);
                team.Players.Add(p);
            }
            for (int i = 0; i < 8; i++)
            {
                Player p = generatePlayer(division, PlayerPosition.Midfielder);
                team.Players.Add(p);
            }
            for (int i = 0; i < 5; i++)
            {
                Player p = generatePlayer(division, PlayerPosition.Forward);
                team.Players.Add(p);
            }
        }

        public static Player generatePlayer(int division, PlayerPosition position)
        {
            var count = new NameGenerator().Names.Count;
            Player p = new Player(new NameGenerator().Names[rand.Next(count)] + " " + new NameGenerator().Names[rand.Next(count)]);
            p.Position = position;
            p.Age = rand.Next(22) + 16;
            p.Injured = false;
            p.Nationality = Nationality.Portugal;
            p.Stamina = generateStat(division);
            p.Strength = generateStat(division);
            p.Technick = generateStat(division);
            p.Experience = generateStat(division);
            p.OverallPower = (p.Strength + p.Stamina + p.Technick) / 3;
            p.MarketValue = generateMarketValue(p.OverallPower, p.Age);
            p.Salary = Math.Floor(p.MarketValue / 20);

            return p;
        }

        public static int generateStat(int division)
        {
            switch (division)
            {
                case 1: return rand.Next(30) + 50;
                case 2: return rand.Next(20) + 40;
                case 3: return rand.Next(15) + 25;
                case 4: return rand.Next(15);
                default: return 0;
            }
        }

        public static decimal generateMarketValue(decimal power, int age)
        {
            if (power > 80)
            {
                return (80000) * ((50 - age) + power);
            }
            else if (power > 60)
            {
                return (40000) * ((50 - age) + power);
            }
            else if (power > 40)
            {
                return (18000) * ((50 - age) + power);
            }
            else
            {
                return (5000) * ((50 - age) + power);
            }
        }

        private static void createManagers()
        {
            using (var db = new TeamContext())
            {
                var count = 0;
                while (count < 40)
                {
                    Manager m = new Manager(new NameGenerator().Names[(Randomizer.GetRandomizer.Next(new NameGenerator().Names.Count))], false);
                    db.Managers.Add(m);
                    count++;
                }
                db.SaveChanges();
            }
        }

        private static void assignManagersToTeams()
        {
            using (var db = new TeamContext())
            {
                var teams = db.Teams.ToList();
                var managers = db.Teams.ToList();

                var count = 0;
                foreach (Team t in teams)
                {
                    t.ManagerId = managers[count].ManagerId;
                    count++;
                }
                db.SaveChanges();
            }
        }
    }
}