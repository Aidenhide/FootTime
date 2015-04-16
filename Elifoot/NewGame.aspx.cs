using Elifoot.Logic;
using Elifoot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Threading;
namespace Elifoot
{
    public partial class NewGame : System.Web.UI.Page
    {
        public int Count { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ddlplayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddl = sender as DropDownList;
            switch (ddl.SelectedValue)
            {
                case "1": 
                    div_p2.Visible = false;
                    div_p3.Visible = false;
                    div_p4.Visible = false;
                    break;
                case "2":
                    div_p2.Visible = true;
                    div_p3.Visible = false;
                    div_p4.Visible = false;
                    break;
                case "3":
                    div_p2.Visible = true;
                    div_p3.Visible = true;
                    div_p4.Visible = false;
                    break;
                case "4":
                    div_p2.Visible = true;
                    div_p3.Visible = true;
                    div_p4.Visible = true;
                    break;
            }
        }

        protected void b_begin_Click(object sender, EventArgs e)
        {
            if (tb_player1.Text.Trim().Length < 3)
            {
                l_error.Text = "Player 1 inválido. Pelo menos 3 letras necessario";
                return;
            }
            if (tb_player2.Text.Trim().Length < 3 && ddlplayers.SelectedValue.Equals("2"))
            {
                l_error.Text = "Player 2 inválido. Pelo menos 3 letras necessario";
                return;
            }
            if (tb_player3.Text.Trim().Length < 3 && ddlplayers.SelectedValue.Equals("3"))
            {
                l_error.Text = "Player 3 inválido. Pelo menos 3 letras necessario";
                return;
            }
            if (tb_player4.Text.Trim().Length < 3 && ddlplayers.SelectedValue.Equals("4"))
            {
                l_error.Text = "Player 4 inválido. Pelo menos 3 letras necessario";
                return;
            }
            BeginGame();
        }

        private void BeginGame()
        {
            using (var db = new TeamContext())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM Players");
                db.Database.ExecuteSqlCommand("DELETE FROM GameEvents");
                db.Database.ExecuteSqlCommand("DELETE FROM Matches");
                db.Database.ExecuteSqlCommand("DELETE FROM Journeys");
                db.Database.ExecuteSqlCommand("DELETE FROM Teams");
                db.Database.ExecuteSqlCommand("DELETE FROM Leagues");
                PopulateTeams.CreateLeagues();

                var num_players = int.Parse(ddlplayers.SelectedValue);
                string[] names = { tb_player1.Text, tb_player2.Text, tb_player3.Text, tb_player4.Text };
                for (int i = 0; i < num_players; i++)
                {
                    db.Managers.Add(new Manager(names[i], true));
                }
                db.SaveChanges();

                
                
                var teams = db.Teams.Where(x => db.Leagues.Where(y => y.Division == 4).FirstOrDefault().Teams.Contains(x)).Take(num_players).ToList();
                var managers = db.Managers.Where(x => x.isHuman == true).ToList();
                for (int i = 0; i < num_players; i++)
                {
                   
                    teams[i].ManagerId = managers[i].ManagerId;
                    teams[i].humanControl = true;
                }
                db.SaveChanges();
                var matchs = db.Matches.Include(x => x.House).Where(x=> x.House.humanControl == true).ToList();
                foreach (Match m in matchs)
                {
                    m.IsHouseHuman = true;
                }
                matchs = db.Matches.Include(x => x.Visitor).Where(x => x.Visitor.humanControl == true).ToList();
                foreach (Match m in matchs)
                {
                    m.IsVisitorHuman = true;
                }

                db.SaveChanges();
                Response.Redirect("Home.aspx");
            }


            
        }


    }
}