using Microsoft.AspNetCore.Mvc;
using Msdotnetexam.Models;
using System.Diagnostics;


namespace Msdotnetexam.Controllers
{
    public class HomeController : Controller
    {
        TrainingDbContext context = null;

        public HomeController(TrainingDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        
        public IActionResult AfterLogin(Institute institute)
        {
            String message = "Invalid credentials";
            foreach (var ins in context.Institute)
            {
                if (ins.Code.Equals(institute.Code) && institute.Pin.Equals(ins.Pin))
                {
                    return View("Create");
                }
            }

            return View("Login", message);
        }


        [HttpGet]
                public IActionResult Edit()
                {
                   return View("Edit");
                }

                [HttpPost]
                public IActionResult Edit(Courses course, int? id)
                {


            Courses productDelete = context.Courses.Find(id);

                        context.Courses.Update(course);

                        context.SaveChanges();
           

                   return Redirect("/home/Course");
                }


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
