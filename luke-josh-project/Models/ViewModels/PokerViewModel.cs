using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace luke_josh_project.Models.ViewModels
{
    public class PokerViewModel
    {
        public List<Data.PokerUser> Users { get; set; }
        public List<Data.PokerMatch> Matches { get; set; }
        public List<ScoreboardModel> Scoreboard { get; set; }
    }
}