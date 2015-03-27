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
        }


        protected void b_generateTeams_Click(object sender, EventArgs e)
        {

            using (var db = new TeamContext())
            {
                PopulateTeams.CreateLeagues();
            }

        }
    }
}