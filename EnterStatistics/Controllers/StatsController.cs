using System;
using System.Collections.Generic;
using System.Linq;
using EnterStatistics.Database;
using EnterStatistics.Models;
using EnterStatistics.ViewedModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Action = EnterStatistics.Models.Action;

namespace EnterStatistics.Controllers
{
    public class StatsController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [HttpPost]
        public IActionResult Redirect([FromForm]User enteredUser)
        {
            User user = db.Users.Where(x => x.Name == enteredUser.Name).FirstOrDefault();
            bool contains = user == null ? false : true;
            if (contains)
            {
                db.Actions.Add(new Action() {Date = DateTime.Now.ToString(), UserId = user.Id});
            }
            else
            {
                db.Users.Add(new User() {Name = enteredUser.Name, Created = DateTime.Now.ToString(), Email = enteredUser.Email});
            }
            db.SaveChanges();
            return Redirect("/stats/index");
        }

        public IActionResult Index()
        {
            var users = db.Users.Select(x => x);
            return View(users.ToList());
        }
        
        public IActionResult UserStats(int id)
        {
            User user = db.Users.Where(x => x.Id == id).First();
            List<Action> actions = db.Actions.Where(x => x.UserId == id).ToList();
            return View(new ViewedUser(user, actions));
        }
        
    }
}