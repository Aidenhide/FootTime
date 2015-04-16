using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elifoot.Models
{
    [Serializable]
    public class GameEvent
    {
        public GameEvent() { }
        public GameEvent(GameEventType type)
        {
            Type = type;
        }
        [Key]
        public int GameEventId { get; set; }

        public GameEventType Type { get; set; }

        public string Icon { get; set; }

        public int Time { get; set; }

        public string PlayerName { get; set; }

        public string SecondPlayerName { get; set; }

        public string Team { get; set; }

        public string OtherTeam { get; set; }

        public GameEventLocation Location { get; set; }
    }

    public enum GameEventType { Goal, Fault, Penalty, Substitution, YellowCard, RedCard };

    public enum GameEventLocation { House, Visitor }
}