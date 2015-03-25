using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elifoot.Models
{
    public class Team
    {
        public Team() { }

        public Team(string name)
        {
            Name = name;
        }

        [Key]
        public int TeamId { get; set; }

        public string Name { get; set; }

        public virtual IList<Player> Players
        {
            get
            {
                return _Players;
            }
            set
            {
                _Players = value;
            }
        }

        private IList<Player> _Players;
  
        public int ManagerId { get; set; }

        public int StadiumId { get; set; }

        public decimal Moral { get; set; }

        public decimal Money { get; set; }

    }
}