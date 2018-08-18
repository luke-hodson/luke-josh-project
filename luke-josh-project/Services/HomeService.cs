using luke_josh_project.Data;
using luke_josh_project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace luke_josh_project.Services
{
    public class HomeService
    {
        public HomeViewModel GetHomeData()
        {
            using (var db = new EFContext())
            {
                return (from p in db.Persons
                        select new HomeViewModel
                        {
                            Age = p.Age != null ? p.Age.Value : 0,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            Id = p.ID
                        }).FirstOrDefault();
            };
        }
    }
}