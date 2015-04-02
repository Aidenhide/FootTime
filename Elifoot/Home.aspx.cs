using Elifoot.Logic;
using Elifoot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Elifoot
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadInfo();
        }

        protected void loadInfo()
        {
            using (var db = new TeamContext())
            {
                var t = db.Teams.Include(x => x.Players).ToList();
                var teams = t.Where(x => x.humanControl == true).ToList();
                if (teams != null)
                {
                    var team = teams.FirstOrDefault();
                    repeaterTeam.DataSource = team.Players;
                    repeaterTeam.DataBind();


                    l_teamName.Text = team.Name;
                    l_managerName.Text = db.Managers.Where(x => x.ManagerId == team.ManagerId).FirstOrDefault().Name; 
                    l_money.Text = team.Money.ToString();
                }
            }
        }

        protected void lk_beginJourney_Click(object sender, EventArgs e)
        {
            MatchManager mm = new MatchManager();
            mm.beginSimulation();
            Response.Redirect("Simulation.aspx");
        }

        
    }
}