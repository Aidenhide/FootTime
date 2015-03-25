using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Elifoot.Models
{
    public class Context
    {
    }

    public class TeamContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<BuyingOffer> BuyingOffers { get; set; }
    }
}