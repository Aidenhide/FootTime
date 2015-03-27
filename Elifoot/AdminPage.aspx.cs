using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Elifoot.Models;
using System.Data.SqlClient;
using Elifoot.Logic;

namespace Elifoot
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadStatistics();
        }

        protected void b_clearDb_Click(object sender, EventArgs e)
        {
            using (var db = new TeamContext())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM Players");
                db.Database.ExecuteSqlCommand("DELETE FROM Matches");
                db.Database.ExecuteSqlCommand("DELETE FROM Journeys");
                db.Database.ExecuteSqlCommand("DELETE FROM Teams");
                db.Database.ExecuteSqlCommand("DELETE FROM Leagues");
                db.SaveChanges();
            }
            loadStatistics();
        }


        protected void b_generateTeams_Click(object sender, EventArgs e)
        {
            using (var db = new TeamContext())
            {
                PopulateTeams.CreateLeagues();
            }
            loadStatistics();
        }

        protected void loadStatistics()
        {
            using (var db = new TeamContext())
            {
                l_lcount.Text = db.Leagues.Count().ToString();
                l_jcount.Text = db.Journeys.Count().ToString();
                l_mcount.Text = db.Matches.Count().ToString();
                l_tcount.Text = db.Teams.Count().ToString();
                l_pcount.Text = db.Players.Count().ToString();
            }
            loadInfo();
        }

        protected void loadInfo()
        {
            using (var db = new TeamContext())
            {
                repeaterLeagues.DataSource = db.Leagues.ToList();
                repeaterJourneys.DataSource = db.Journeys.ToList();
                repeaterMatches.DataSource = db.Matches.ToList();
                repeaterTeams.DataSource = db.Teams.ToList();
                repeaterPlayers.DataSource = db.Players.ToList();

                repeaterLeagues.DataBind();
                repeaterJourneys.DataBind();
                repeaterMatches.DataBind();
                repeaterTeams.DataBind();
                repeaterPlayers.DataBind();
            }
        }
    }
}