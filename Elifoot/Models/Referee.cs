using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elifoot.Models
{
    public class Referee
    {
        public Referee() { }
        public Referee(string name)
        {
            Name = name;
        }

        [Key]
        public int RefereeId { get; set; } 
        
        public string Name { get; set; }

        public List<Team> Favorits { get; set; }

        public List<Team> Hated { get; set; }
    }
}