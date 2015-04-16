using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elifoot.Models
{
    [Serializable]
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

        public int CurrentJourney { get; set; }

        public virtual IList<Journey> Journeys
        {
            get
            {
                if(_Journey != null)
                    return _Journey;
                else
                {
                    _Journey = new List<Journey>();
                    return _Journey;
                }
                    
            }
            set
            {
                _Journey = value;
            }
        }

        private IList<Journey> _Journey;

        public virtual IList<Team> Teams
        {
            get
            {
                if (_Teams != null)
                    return _Teams;
                else
                {
                    _Teams = new List<Team>();
                    return _Teams;
                }
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

        public virtual IList<Referee> Referees
        {
            get
            {
                if (_Referees != null)
                    return _Referees;
                else
                {
                    _Referees = new List<Referee>();
                    return _Referees;
                }
            }
            set
            {
                _Referees = value;
            }
        }

        private IList<Referee> _Referees;
    }
}