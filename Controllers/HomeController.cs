using dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using todo.Data;
using todo.Models;

namespace todo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public IActionResult Privacy()
        {
            if (Request.Method == "POST")
            {
                var tlist = new Todolist
                {
                    Task = Request.Form["task"],
                    Description = Request.Form["description"],
                    Status = Request.Form["status"],
                };
                Console.WriteLine(tlist);
                _context.Tasklist.Add(tlist);
                _context.SaveChanges();
                Console.WriteLine("Form Submitted");
            }
            var tasklist = _context.Tasklist.ToList();
            return View(tasklist);
        }

        public IActionResult Mytasklist()
        {
            var tasklist = _context.Tasklist.ToList();
            return View(tasklist);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _context.Tasklist.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task); // passes Todolist object to the Edit.cshtml
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Todolist updatedTask)
        {
            if (id != updatedTask.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Update(updatedTask);
                _context.SaveChanges();
                return RedirectToAction(nameof(Mytasklist));
            }

            return View(updatedTask);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }

}