using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Elifoot.Models;
using System.Data.Entity;
using System.Web.UI.HtmlControls;
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
                var leagues = db.Leagues.Include(x => x.Journeys).ToList();
                var journeys = db.Journeys.Include(x => x.Matchs).ToList();
                var currentJorney = journeys.Where(x => x.JourneyId == leagues.FirstOrDefault().CurrentJourney).FirstOrDefault();
                l_journey.Text = "Jornada Nº" + currentJorney.Number;
                l_time.Text = currentJorney.Time.ToString();
                if (currentJorney.Time == 90)
                {
                    Response.Redirect("AfterGameStatistics.aspx");
                }
                leagueRepeater.DataSource = leagues;
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

        protected void MatchRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var match = e.Item.DataItem as Match;
            if (match != null)
            {
                var le_house = match.GameEvents.Where(x => x.Location == GameEventLocation.House).LastOrDefault();
                var le_visitor = match.GameEvents.Where(x => x.Location == GameEventLocation.Visitor).LastOrDefault();

                if (le_house != null)
                {
                    var l_houseLastEvent = (Label)e.Item.FindControl("l_houseLastEvent");
                    l_houseLastEvent.Text = le_house.Time + "' " + le_house.PlayerName;
                    var I_house = (HtmlImage)e.Item.FindControl("I_house");
                    I_house.Src = le_house.Icon;
                }
                if (le_visitor != null)
                {
                    var l_visitorLastEvent = (Label)e.Item.FindControl("l_visitorLastEvent");
                    l_visitorLastEvent.Text = le_visitor.PlayerName + " " + le_visitor.Time + "'";
                    var I_visitor = (HtmlImage)e.Item.FindControl("I_visitor");
                    I_visitor.Src = le_visitor.Icon;
                }
            }
        }
    }
        
}