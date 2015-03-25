using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Elifoot.Models;

namespace Elifoot
{
    public partial class Simulation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadMatchs();
        }

        public void loadMatchs()
        {
            using (var db = new TeamContext())
            {
                leagueRepeater.DataSource = db.Leagues.ToList();
                leagueRepeater.DataBind();
            }
        }

        protected void leagueRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var league = e.Item.DataItem as League;
            var matchRepeater = (Repeater)e.Item.FindControl("MatchRepeater");
            matchRepeater.DataSource = league.Journeys.Where(x => x.JourneyId == league.CurrentJourney).FirstOrDefault().Matchs;
            matchRepeater.DataBind();
        }

        protected void MatchRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var match = e.Item.DataItem as Match;
            var house = (Label)e.Item.FindControl("l_house");
            house.Text = match.House.Name;
            var visitor = (Label)e.Item.FindControl("l_visitor");
            visitor.Text = match.Visitor.Name;
        }
    }
}