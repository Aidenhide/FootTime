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
                if (_Players != null)
                    return _Players;
                else
                {
                    _Players = new List<Player>();
                    return _Players;
                }
            }
            set
            {
                _Players = value;
            }
        }

        private IList<Player> _Players;

        public virtual IList<Player> SelectedPlayers
        {
            get
            {
                if (_SelectedPlayers != null)
                    return _SelectedPlayers;
                else
                {
                    _SelectedPlayers = new List<Player>();
                    return _SelectedPlayers;
                }
            }
            set
            {
                _SelectedPlayers = value;
            }
        }

        private IList<Player> _SelectedPlayers;

        public virtual IList<Player> SelectedSubsPlayers
        {
            get
            {
                if (_SelectedSubsPlayers != null)
                    return _SelectedSubsPlayers;
                else
                {
                    _SelectedSubsPlayers = new List<Player>();
                    return _SelectedSubsPlayers;
                }
            }
            set
            {
                _SelectedSubsPlayers = value;
            }
        }

        private IList<Player> _SelectedSubsPlayers;

        public int ManagerId { get; set; }

        public int StadiumId { get; set; }

        public decimal Moral { get; set; }

        public decimal Money { get; set; }

        public bool humanControl { get; set; }


    }
}