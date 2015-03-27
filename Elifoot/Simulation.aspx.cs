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
                var currentJorney = db.Journeys.Where(x => x.JourneyId == db.Leagues.FirstOrDefault().CurrentJourney).FirstOrDefault();
                l_journey.Text = "Jornada Nº"+currentJorney.Number;
                leagueRepeater.DataSource = db.Leagues.ToList();
                leagueRepeater.DataBind();
            }
        }

        protected void leagueRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var league = e.Item.DataItem as League;
            if (league != null)
            {

                var matchRepeater = (Repeater)e.Item.FindControl("MatchRepeater");
                matchRepeater.DataSource = league.Journeys.Where(x => x.JourneyId == league.CurrentJourney).FirstOrDefault().Matchs;
                matchRepeater.DataBind();
            }
        }
    }
}