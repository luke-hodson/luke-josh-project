using luke_josh_project.Data;
using luke_josh_project.Models;
using luke_josh_project.Models.Enums;
using luke_josh_project.Models.ViewModels;
using luke_josh_project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace luke_josh_project.Controllers
{
    public class PokerController : Controller
    {
        PokerService _pokerService = new PokerService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Stats()
        {
            ViewBag.Message = "A page to contain stats";

            //grab the data
            List<ScoreboardModel> scoreboard = new List<ScoreboardModel>();

            PokerViewModel viewModel = _pokerService.GetPokerData();
            List<Data.PokerResult> results = _pokerService.GetResults();
            List<Data.PokerMatch> matches = _pokerService.GetMatches();


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
                        if (!currentMatch.IsWinnerTakesAll)
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

        public ActionResult Game()
        {
            GameViewModel model = new GameViewModel();
            PokerService pokerService = new PokerService();
            var data = pokerService.GetPokerData();
            model.Users = data.Users;
            return View(model);
        }


        public void AddGameResult(string order, int buyIn, bool winnerTakes)
        {
            List<int> results = new JavaScriptSerializer().Deserialize<List<int>>(order);
            List<PokerResult> resultsObj = new List<PokerResult>();

            PokerMatch match = new PokerMatch
            {
                Date = DateTime.Now,
                IsWinnerTakesAll = winnerTakes,
                BuyIn = buyIn
            };            

            for (int i = 0; i < results.Count; i++)
            {
                resultsObj.Add(new PokerResult
                {
                    Placing = i + 1,
                    PokerUserId = results[i],
                    PokerMatchId = 0
                });
            }

            _pokerService.AddGameResult(match, resultsObj);
        }
    }
}
