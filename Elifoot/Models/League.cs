using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elifoot.Models
{
    public class League
    {
        public League() { }
        public League(string name)
        {
            Name = name;
        }

        [Key]
        public int LeagueId { get; set; }

        public int Division { get; set; }
        
        public string Name { get; set; }

        public int CurrentJourney { get; set; }

        public virtual IList<Journey> Journeys
        {
            get
            {
                if(_Journey != null)
                    return _Journey;
                else
                {
                    _Journey = new List<Journey>();
                    return _Journey;
                }
                    
            }
            set
            {
                _Journey = value;
            }
        }

        private IList<Journey> _Journey;

        public virtual IList<Team> Teams
        {
            get
            {
                if (_Teams != null)
                    return _Teams;
                else
                {
                    _Teams = new List<Team>();
                    return _Teams;
                }
            }
            set
            {
                _Teams = value;
            }
        }

        private IList<Team> _Teams;

        public decimal FirstPrize { get; set; }

        public decimal SecondPrize { get; set; }

        public decimal ThirdPrize { get; set; }

        public virtual IList<Referee> Referees
        {
            get
            {
                if (_Referees != null)
                    return _Referees;
                else
                {
                    _Referees = new List<Referee>();
                    return _Referees;
                }
            }
            set
            {
                _Referees = value;
            }
        }

        private IList<Referee> _Referees;


        public Classification GetClassification()
        {
            return new Classification(this);
        }
    }

    public class Classification
    {
        private League _league;

        public Classification(League l)
        {
            _league = l;
            this.CalculateMatches();
        }

        private void CalculateMatches()
        {
            List<Journey> _playedJourneys = _league.Journeys.Where(x => (x.Number <= _league.CurrentJourney)).ToList();

            Dictionary<Team, ClassificationItem> _classificationByTeam = new Dictionary<Team, ClassificationItem>();

            foreach(Team t in _league.Teams)
            {
                _classificationByTeam[t] = new ClassificationItem();
            }

            foreach (Journey j in _playedJourneys)
            {
                foreach(Match m in j.Matchs)
                {
                    _classificationByTeam[m.House].UpdateClassification(m);
                    _classificationByTeam[m.Visitor].UpdateClassification(m);
                }
            }
        }
    }


    public class ClassificationItem
    {
        private Team _team;
        private int _points=0;
        private int _matchesWon=0;
        private int _matchesLost=0;
        private int _matchesDrawn=0;
        private int _scoredGoals=0;
        private int _againstGoals=0;


        public ClassificationItem()
        {
        }

        public void UpdateClassification(Match m)
        {
            if (m.HouseScore == m.VisitorScore) //DRAW
            {
                _matchesDrawn++;
                _points++;
            }

            if (m.House.TeamId == _team.TeamId)
            {
                _scoredGoals += m.HouseScore;
                _againstGoals += m.VisitorScore;                

                if (m.HouseScore > m.VisitorScore)  //WIN
                {
                    _matchesWon++;
                    _points += 3;
                    return;
                }
                
                if (m.HouseScore < m.VisitorScore)  //LOST
                {
                    _matchesLost++;
                    return;
                }
            }
            else
            {
                _scoredGoals += m.VisitorScore;
                _againstGoals += m.HouseScore;
            }
        }
    }
}