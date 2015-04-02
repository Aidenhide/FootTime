using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elifoot.Models;
using System.Data.Entity;
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

        public static bool AddManagerToTeam(Team team, Manager manager)
        {
            using (var db = new TeamContext())
            {
                var t = db.Teams.Where(x => x.TeamId == team.TeamId).FirstOrDefault();
                if (t != null)
                {
                    t.ManagerId = manager.ManagerId;
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static int SelectPlayer(Player player, Team team)
        {
            using (var db = new TeamContext())
            {
                var t = db.Teams.Include(x => x.SelectedPlayers).Include(x => x.Players).Where(x => x.TeamId == team.TeamId).FirstOrDefault();
                if (t != null)
                {
                    if (team.SelectedPlayers.Count == 11)
                    {
                        return 0; // MAX PLAYERS
                    }
                    if (team.SelectedPlayers.Count == 10 &&
                        team.SelectedPlayers.Where(x => x.Position == PlayerPosition.GoalKeeper).ToList().Count == 0 &&
                        player.Position != PlayerPosition.GoalKeeper)
                    {
                        return 1; // GOALKEEPER NEEEDED
                    }
                    if (team.SelectedPlayers.Count == 8 &&
                        team.SelectedPlayers.Where(x => x.Position == PlayerPosition.Defender).ToList().Count == 0 &&
                        player.Position != PlayerPosition.Defender)
                    {
                        return 2; // DEFENDER NEEEDED
                    }
                    if (team.SelectedPlayers.Count == 8 &&
                        team.SelectedPlayers.Where(x => x.Position == PlayerPosition.Midfielder).ToList().Count == 0 &&
                        player.Position != PlayerPosition.Midfielder)
                    {
                        return 3; // MIDFIELDER NEEEDED
                    }
                    if (team.SelectedPlayers.Count == 8 &&
                        team.SelectedPlayers.Where(x => x.Position == PlayerPosition.Forward).ToList().Count == 0 &&
                        player.Position != PlayerPosition.Forward)
                    {
                        return 4; // FORWARD NEEEDED
                    }
                    if(player.Position == PlayerPosition.GoalKeeper &&
                       team.SelectedPlayers.Where(x => x.Position == PlayerPosition.GoalKeeper).ToList().Count != 0)
                    {
                        return 5; // MAX GOALKEEPERS
                    }
                    team.SelectedPlayers.Add(player);
                    db.SaveChanges();
                    return 6; // SUCCESS
                }
            }
            return -1;
        }

        public static bool SelectSubsPlayer(Player player, Team team)
        {
            using (var db = new TeamContext())
            {
                var t = db.Teams.Include(x => x.SelectedPlayers).Include(x => x.Players).Where(x => x.TeamId == team.TeamId).FirstOrDefault();
                if (t != null)
                {
                    if (team.SelectedSubsPlayers.Count < 7)
                    {
                        team.SelectedSubsPlayers.Add(player);
                        db.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
        }

        public static bool RemoveSelectedPlayer(Player player, Team team)
        {
            using (var db = new TeamContext())
            {
                var t = db.Teams.Include(x => x.SelectedPlayers).Include(x => x.Players).Where(x => x.TeamId == team.TeamId).FirstOrDefault();
                if (t != null)
                {
                    t.SelectedPlayers.Remove(player);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool RemoveSelectedSubsPlayer(Player player, Team team)
        {
            using (var db = new TeamContext())
            {
                var t = db.Teams.Include(x => x.SelectedPlayers).Include(x => x.Players).Where(x => x.TeamId == team.TeamId).FirstOrDefault();
                if (t != null)
                {
                    t.SelectedSubsPlayers.Remove(player);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }


}