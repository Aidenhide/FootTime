using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elifoot.Models;

namespace Elifoot.Logic
{
    public static class PopulateTeams
    {
        private static Random rand = new Random();

        public static void CreateLeagues() {
            using (var db = new TeamContext())
            {
                var prize = 100000000;
                for (int i = 1; i < 5; i++)
                {
                    var league = new League(i+"ª Divisão");
                    league.Division = i;
                    league.FirstPrize = prize / i;
                    league.SecondPrize = league.FirstPrize / 2;
                    league.ThirdPrize = league.ThirdPrize / 2;
                    league.Teams = CreateTeams(i);
                    db.Leagues.Add(league);
                }
                db.SaveChanges();
            }
        }

        public static List<Team> CreateTeams(int division)
        {
            using (var db = new TeamContext())
            {
                var nameGenerator = new NameGenerator();
                var count = nameGenerator.Names.Count;
                List<Team> teamList = new List<Team>();
                for (int i = 0; i < 10; i++)
                {
                    var team = new Team(nameGenerator.Names[rand.Next(count)]);
                    team.Money = 10000000 / division;
                    team.Moral = 100;
                    teamList.Add(team);
                    db.Teams.Add(team);
                    db.SaveChanges();
                    CreatePlayers(team, division);
                }
                db.SaveChanges();
                return teamList;
            }
        }

        public static void CreatePlayers(Team team, int division)
        {
            using (var db = new TeamContext())
            {
                for (int i = 0; i < 22; i++)
                {
                    Player p = generatePlayer(division);
                    p.Salary = 1000 * i;
                    TeamManager.AddPlayerToTeam(p, team);
                }
            }
        }

        public static Player generatePlayer(int division)
        {
            var count = new NameGenerator().Names.Count;
            Player p = new Player(new NameGenerator().Names[rand.Next(count)]);
            p.Age = rand.Next(38) + 16;
            p.Injured = false;
            p.Nationality = Nationality.Portugal;
            p.Stamina = generateStat(division);
            p.Strength = generateStat(division);
            p.Technick = generateStat(division);
            p.OverallPower = (p.Strength + p.Stamina + p.Technick) / 3;
            p.MarketValue = generateMarketValue(p.OverallPower, p.Age);
            
            return p;
        }

        public static int generateStat(int division)
        {
            switch (division)
            {
                case 1: return rand.Next(80) + 50;
                case 2: return rand.Next(60) + 40;
                case 3: return rand.Next(40) + 25;
                case 4: return rand.Next(25) + 10;
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
    }
}