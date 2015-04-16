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
    public partial class AfterGameStatistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadMatchs();
        }

        public void loadMatchs()
        {
            using (var db = new TeamContext())
            {
                var leagues = db.Leagues.Include(x => x.Journeys).ToList();
                var journeys = db.Journeys.Include(x => x.Matchs).ToList();
                var currentJorney = journeys.Where(x => x.JourneyId == leagues.FirstOrDefault().CurrentJourney).FirstOrDefault();
                l_journey.Text = "Jornada Nº" + currentJorney.Number;
                leagueRepeater.DataSource = leagues;
                leagueRepeater.DataBind();
            }
        }

        protected void leagueRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var league = e.Item.DataItem as League;
            if (league != null)
            {

                var matchRepeater = (Repeater)e.Item.FindControl("matchRepeater");
                matchRepeater.DataSource = league.Journeys.Where(x => x.JourneyId == league.CurrentJourney).FirstOrDefault().Matchs;
                matchRepeater.DataBind();
            }
        }

        protected void b_nextJorney_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}