using Elifoot.Logic;
using Elifoot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Web.UI.HtmlControls;

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
                    ViewState["team"] = team;
                    ViewState["bgcolor"] = team.BackgroundColor;
                    ViewState["frcolor"] = team.ForegroundColor;
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
            MatchManager.beginSimulation();
            Response.Redirect("Simulation.aspx");
        }

        protected void repeaterTeam_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           var lk = (LinkButton)e.Item.FindControl("b_shirt");
           var img = (HtmlImage)e.Item.FindControl("i_shirt");
            Player p = (Player)e.Item.DataItem;
            if (p != null && p.Selected)
            {
                img.Src = "../Content/Images/shirtSelected20.png";
                return;
            }
            if (p != null && p.SubSelected)
            {
                img.Src = "../Content/Images/shirtSubs20.png";
                return;
            }
            return;
        }

        protected void lk_calendar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Calendar.aspx");
        }


        
    }
}