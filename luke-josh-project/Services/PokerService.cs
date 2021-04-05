using luke_josh_project.Data;
using luke_josh_project.Models;
using luke_josh_project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace luke_josh_project.Services
{
    public class PokerService
    {
        public PokerViewModel GetPokerData()
        {
            PokerViewModel model = new PokerViewModel();
            using (var db = new EFContext())
            {
                model.Matches = db.PokerMatches.ToList();
                model.Users = db.PokerUsers.ToList();
            };

            return model;
        }

        public List<Data.PokerMatch> GetScoreboardData()
        {
            ScoreboardModel scoreboard = new ScoreboardModel();
            using (var db = new EFContext())
            {
                var data = from matches in db.PokerMatches
                           join results in db.PokerResults on matches.Id equals results.PokerMatchId
                           join users in db.PokerUsers on results.PokerUserId equals users.Id
                           select matches;                

                return data.ToList();
            };          
        }

        public List<Data.PokerResult> GetResults()
        {
            using (var db = new EFContext())
            {
                var data = from results in db.PokerResults.Include("PokerMatches")
                           join users in db.PokerUsers on results.PokerUserId equals users.Id
                           join matches in db.PokerMatches on results.PokerMatchId equals matches.Id
                           select results;

                return data.ToList();
            };
        }

        public List<Data.PokerMatch> GetMatches()
        {
            using (var db = new EFContext())
            {
                var data = from matches in db.PokerMatches
                           select matches;

                return data.ToList();
            };
        }

        public void AddGameResult(PokerMatch match, List<PokerResult> results)
        {
            using (var db = new EFContext())
            {
                db.PokerMatches.Add(match);
                db.SaveChanges();
                var matchId = match.Id;

                for (int i = 0; i < results.Count; i++)
                {
                    results[i].PokerMatchId = matchId;
                }

                db.PokerResults.AddRange(results);

                db.SaveChanges();
            };
        }
    }
}