﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elifoot.Models
{
    public class Match
    {
        public Match() { }
        public Match(Team house, Team visitor)
        {
            House = house;
            Visitor = visitor;
        }

        [Key]
        public int MatchId { get; set; } 
        
        public Team House { get; set; }

        public Team Visitor { get; set; }

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

        public Referee referee { get; set; }

    }
}