using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elifoot.Models
{
    public class Journey
    {
        public Journey() { }
        public Journey(string name)
        {
            Name = name;
        }
        [Key]
        public int JourneyId { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public virtual IList<Match> Matchs
        {
            get
            {
                if (_Matchs != null)
                    return _Matchs;
                else
                {
                    _Matchs = new List<Match>();
                    return _Matchs;
                }
            }
            set
            {
                _Matchs = value;
            }
        }
        private IList<Match> _Matchs;

        public int Time { get; set; }
    }
}