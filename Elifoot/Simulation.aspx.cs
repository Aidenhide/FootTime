using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Elifoot.Models;
using System.Data.Entity;
using System.Web.UI.HtmlControls;
using Elifoot.Logic;
using System.Diagnostics;
namespace Elifoot
{

    public partial class Simulation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadMatchs();
            MatchManager.NewNotificationsReceived -= MatchManager_NewNotificationsReceived;
            MatchManager.NewNotificationsReceived += MatchManager_NewNotificationsReceived;
        }

        protected void GetTime(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }


        void MatchManager_NewNotificationsReceived(bool humanRequired, GameEvent gameEvent)
        {
            //if (humanRequired)
            //{

            //    if (gameEvent.Type == GameEventType.Goal)
            //    {
            //        l_eventHeader.Text = "GOLO!";
            //        l_eventBody.Text = "O jogador " + gameEvent.PlayerName + " remate a bola para o fundo das redes!\n" +
            //            "Golo para a equipa " + gameEvent.Team;
            //    }
            //    div_event.Attributes.CssStyle["Display"] = "block";
            //    div_page.Attributes.CssStyle["-webkit-filter"] = "blur(5px) grayscale(50%)";
            //    div_page.Attributes.CssStyle["pointer-events"] = "none";
            //    div_event.Attributes.CssStyle["pointer-events"] = "auto";
            //    loadMatchs();
            //    return;
            //}
            //else
            //{
            //   // b_up_Click(null, null);
            //}
        }

        public void loadMatchs()
        {
            using (var db = new TeamContext())
            {
                var leagues = db.Leagues.Include(x => x.Journeys).ToList();
                var journeys = db.Journeys.Include(x => x.Matchs).ToList();
                var currentJorney = journeys.Where(x => x.JourneyId == leagues.FirstOrDefault().CurrentJourney).FirstOrDefault();

                if (currentJorney.IsOver)
                {
                    Response.Redirect("AfterGameStatistics.aspx");
                }

                l_journey.Text = "Jornada Nº" + currentJorney.Number;
                l_time.Text = currentJorney.Time.ToString();
                
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

        protected void b_closeModal_Click(object sender, EventArgs e)
        {
            MatchManager.IsPaused = false;
            div_event.Attributes.CssStyle["Display"] = "none";
            div_page.Attributes.CssStyle["-webkit-filter"] = "";
            div_page.Attributes.CssStyle["pointer-events"] = "auto";
            div_event.Attributes.CssStyle["pointer-events"] = "none";
        }
    }

}