using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elifoot.Models
{
    [Serializable]
    public class Player
    {
        public Player() { }
        public Player(string name)
        {
            Name = name;
        }

        [Key]
        public int PlayerId { get; set; } 
        
        public string Name { get; set; }

        public PlayerPosition Position { get; set; }

        public PlayerDefenderRole DefenderRole { get; set; }

        public PlayerForwardRole ForwardRole { get; set; }

        public PlayerMidFielderRole MidFielderRile { get; set; }

        public decimal Salary { get; set; }

        public decimal MarketValue { get; set; }

        public int Age { get; set; }

        public Nationality Nationality { get; set; }

        public bool Injured { get; set; }

        public decimal Stamina { get; set; }

        public decimal Strength { get; set; }

        public decimal Technick { get; set; }

        public decimal Experience { get; set; }

        public decimal OverallPower { get; set; }

        public bool Selected { get; set; }

        public bool SubSelected { get; set; }
    }



    public enum PlayerPosition { GoalKeeper, Defender, Midfielder, Forward };

    public enum PlayerDefenderRole {None=0, CenterBack, CenterHalf, CentralDefender , LeftFullBack, RightFullBack, LeftWingBack, RightWingBack };

    public enum PlayerMidFielderRole { None=0, Defending, Central, Playmaker, LeftWinger, RightWinger };

    public enum PlayerForwardRole { None=0, Striker, WithdrawnStriker};

    public enum Nationality { Portugal, England, France, Spain, Italy, Usa, Holand, Russia, Germany };
}