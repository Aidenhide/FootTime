using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Elifoot.Models;
using Elifoot.Logic;

namespace Elifoot
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //loadTeams();
        }

        protected void b_team_Click(object sender, EventArgs e)
        {
            using (var db = new TeamContext())
            {
                var name = tb_team.Text;

                Team team = new Team(name);
                db.Teams.Add(team);
                db.SaveChanges();

                var teams = db.Teams.ToList();
                if (teams != null)
                {
                    lv_teams.DataSource = teams;
                    lv_teams.DataBind();
                }
            }

        }

        protected void b_generateTeams_Click(object sender, EventArgs e)
        {
            using (var db = new TeamContext())
            {
                PopulateTeams.CreateLeagues();
                loadTeams();
            }

        }

        protected void lv_teams_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var team = e.Item.DataItem as Team;
            var players = (Repeater)e.Item.FindControl("playerRepeater");
            players.DataSource = team.Players;
            players.DataBind();
        }

        protected void loadTeams()
        {
            using (var db = new TeamContext())
            {
                var teams = db.Teams.ToList();
                if (teams != null)
                {
                    lv_teams.DataSource = teams;
                    lv_teams.DataBind();
                }
            }
        }

        protected void b_simulate_Click(object sender, EventArgs e)
        {
            MatchManager mm = new MatchManager();
            mm.beginSimulation();
            Response.Redirect("Simulation.aspx");
        }
    }
}