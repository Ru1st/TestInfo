using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TestInfoTecs.Models;

namespace TestInfoTecs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var users = new UsersRepos().GetAll();
            return View(users);
        }

        [HttpGet]
        public ActionResult AddUser() => View();
        [HttpPost]
        public ActionResult AddUser(User book)
        {
            if (ModelState.IsValid)
            {
                new UsersRepos().Add(book);
                return Redirect("/Home/Index");
            }
            return View(book);
        }

        public ActionResult GetCities(string prefix)
        {
            var cities = new CitiesRepos().GetAll()
                .Where(x => x.Name.Contains(prefix))
                .Select(x => new { label = x.Name, cityId = x.Id })
                .ToList();
            return Json(cities);
        }
        public ActionResult GetUsers(string filter)
        {
            var repos = new UsersRepos();
            if (filter == null) return View("_GetUsers", new UsersRepos().GetAll());
            var split = filter.Split(' ');
            var filteredUsers = new List<User>();
            foreach (string value in split)
            {
                filteredUsers.AddRange(repos.GetAll()
                    .Where(x =>
                    {
                        var text = value.ToLower();
                        return (x.Name.ToLower().Contains(text) 
                        || x.SecondName.ToLower().Contains(text) 
                        || x.City.Name.ToLower().Contains(text))
                        && !filteredUsers.Contains(x);
                    }));
            }
            return View("_GetUsers", filteredUsers);
        }

        public ActionResult DeleteUser(int? id)
        {
            var repos = new UsersRepos();
            var user = repos.Find(id);
            repos.Delete(user);
            return Redirect("/Home/Index");
        }
    }
}