using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elifoot.Models
{
    [Serializable]
    public class Stadium
    {
        public Stadium() { }
        public Stadium(string name)
        {
            Name = name;
        }

        [Key]
        public int StadiumId { get; set; } 
        
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int TicketPrice { get; set; }
    }
}