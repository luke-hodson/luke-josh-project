using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace luke_josh_project.Models
{
    public class ScoreboardModel
    {
        public string Name { get; set; }        
        public double WinPercentage { get; set; }
        public int TotalWins { get; set; }
        public int TotalLosses { get; set; }
        public int GamesPlayed { get; set; }
        public int TotalIncomings { get; set; }
        public int TotalOutgoings { get; set; }
        public int Profit { get; set; }
    }
}