using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elifoot.Models
{
    public class League
    {
        public League() { }
        public League(string name)
        {
            Name = name;
        }

        [Key]
        public int LeagueId { get; set; }

        public int Division { get; set; }
        
        public string Name { get; set; }

        public int Journey { get; set; }

        public virtual IList<Team> Teams
        {
            get
            {
                return _Teams;
            }
            set
            {
                _Teams = value;
            }
        }

        private IList<Team> _Teams;

        public decimal FirstPrize { get; set; }

        public decimal SecondPrize { get; set; }

        public decimal ThirdPrize { get; set; }

        public List<Referee> Referees { get; set; }
    }
}