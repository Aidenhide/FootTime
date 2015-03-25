using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elifoot.Models;

namespace Elifoot.Logic
{
    public static class TeamManager
    {
        public static bool AddPlayerToTeam(Player player, Team team)
        {
            using (var db = new TeamContext())
            {
                var t = db.Teams.Where(x => x.TeamId == team.TeamId).FirstOrDefault();
                if (t != null)
                {
                    t.Players.Add(player);
                    db.SaveChanges();
                }
                return true;
            }

        }

        public static bool RemovePlayerFromTeam(Player player, Team team)
        {
            using (var db = new TeamContext())
            {
                var t = db.Teams.Where(x => x.TeamId == team.TeamId).FirstOrDefault();
                if (t != null)
                {
                    t.Players.Remove(player);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool CreateBuyingOffer(Team from_team, Team to_team, Player player, decimal value)
        {
            using (var db = new TeamContext())
            {
                var t = db.BuyingOffers.Add(new BuyingOffer() { From = from_team, To = to_team, Player = player, Value = value });
                db.SaveChanges();
                return true;
            }
        }
    }


}