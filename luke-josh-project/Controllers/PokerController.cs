using luke_josh_project.Models;
using luke_josh_project.Models.Enums;
using luke_josh_project.Models.ViewModels;
using luke_josh_project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace luke_josh_project.Controllers
{
    public class PokerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Stats()
        {
            ViewBag.Message = "A page to contain stats";

            //grab the data
            PokerService pokerService = new PokerService();
            List<ScoreboardModel> scoreboard = new List<ScoreboardModel>();

            PokerViewModel viewModel = pokerService.GetPokerData();
            List<Data.PokerResult> results = pokerService.GetResults();
            List<Data.PokerMatch> matches = pokerService.GetMatches();
            

            //loop through data and map it to model
            foreach (var user in viewModel.Users)
            {                
                int totalIncoming = 0;
                int totalOutgoings = 0;
                int totalWins = 0;
                var userResults = results.Where(x => x.PokerUserId == user.Id).ToList();

                foreach (var result in userResults)
                {
                    var currentMatch = matches.Where(x => x.Id == result.PokerMatchId).FirstOrDefault();
                    var matchResults = results.Where(x => x.PokerMatchId == currentMatch.Id);   
                    totalOutgoings += currentMatch.BuyIn;

                    //if this user won
                    if (result.Placing == (int)Enums.Placing.First)
                    {
                        totalWins += 1;
                        totalIncoming += (currentMatch.BuyIn * matchResults.Count());
                        if(!currentMatch.IsWinnerTakesAll)
                        {
                            //second place gets money back
                            totalIncoming -= currentMatch.BuyIn;
                        }                              
                    }
                }

                ScoreboardModel userScore = new ScoreboardModel();
                userScore.Name = user.Name;
                userScore.GamesPlayed = userResults.Count;
                userScore.TotalWins = totalWins;
                userScore.TotalIncomings = totalIncoming;
                userScore.TotalOutgoings = totalOutgoings;
                userScore.Profit = totalIncoming - totalOutgoings;
                userScore.TotalLosses = userResults.Count - totalWins;
                userScore.WinPercentage = Math.Round((totalWins * 100.0) / userResults.Count);  

                scoreboard.Add(userScore);                
            }

            viewModel.Scoreboard = scoreboard;

            return View(viewModel);
        }

        public void GetScoreboard()
        {
            ScoreboardModel scoreboard = new ScoreboardModel();

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}