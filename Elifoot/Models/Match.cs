using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elifoot.Models
{
    [Serializable]
    public class Match
    {
        public Match() { }
        public Match(Team house, Team visitor)
        {
            House = house;
            HouseName = house.Name;
            Visitor = visitor;
            VisitorName = visitor.Name;
        }

        [Key]
        public int MatchId { get; set; } 
        
        public Team House { get; set; }

        public Team Visitor { get; set; }

        public string HouseName { get; set; }

        public string VisitorName { get; set; }

        public int HouseScore { get; set; }

        public int VisitorScore { get; set; }

        public int Time { get; set; }

        public int HouseBallTime { get; set; }

        public int VisitorBallTime { get; set; }

        public int HouseCorners { get; set; }

        public int VisitorCorners { get; set; }

        public int HouseFaults { get; set; }

        public int VisitorFaults { get; set; }

        public int HouseShots { get; set; }

        public int VisitorShots { get; set; }

        public bool IsHouseHuman { get; set; }

        public bool IsVisitorHuman { get; set; }

        public string HouseForegroundColor { get; set; }
        public string HouseBackgroundColor { get; set; }

        public string VisitorForegroundColor { get; set; }
        public string VisitorBackgroundColor { get; set; }
       
        public Referee referee { get; set; }


        public virtual IList<GameEvent> GameEvents
        {
            get
            {
                if (_GameEvents != null)
                    return _GameEvents;
                else
                {
                    _GameEvents = new List<GameEvent>();
                    return _GameEvents;
                }
                    
            }
            set
            {
                _GameEvents = value;
            }
        }

        private IList<GameEvent> _GameEvents;
    }
}