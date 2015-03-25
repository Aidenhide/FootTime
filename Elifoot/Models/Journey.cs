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

        public virtual IList<Match> Matchs
        {
            get
            {
                return _Matchs;
            }
            set
            {
                _Matchs = value;
            }
        }
        private IList<Match> _Matchs;

    }
}