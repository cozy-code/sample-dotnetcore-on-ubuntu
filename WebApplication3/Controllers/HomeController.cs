using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new Models.BloggingContext()){
                var blogs = db.Blogs.OrderBy(b => b.Url).ToList();
                return View(blogs);
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            using (var db = new Models.BloggingContext()){
                var blog = new Models.Blog { Url = "http://sample.com/"+DateTime.UtcNow.ToString("yyyyMMdd_hhmmssms") };
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
