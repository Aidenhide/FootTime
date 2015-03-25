using Elifoot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elifoot
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadTeam();
        }

        protected void loadTeam()
        {
            using (var db = new TeamContext())
            {
                var teams = db.Teams.ToList();
                if (teams != null)
                {
                    var team = teams.FirstOrDefault();
                    repeaterTeam.DataSource = team.Players;
                    repeaterTeam.DataBind();
                }
            }
        }
    }
}