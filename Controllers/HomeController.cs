using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnet.Models;
using todo.Models;

namespace dotnet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        // ViewData["Task"] = "Learn dot net";
        // ViewData["Description"] = "Getting started in web";
        // ViewData["status"] = "Done";

        // ViewBag.Task1 = "Start Project";
        // ViewBag.Description1 = "Start To Do List";
        // ViewBag.status1 = "InProcess";

        // var TaskList = new List<todolist>
        // {
        //     new todolist{Task="learn dot net",
        //     Description="starting my jorney",
        //     status="done"},
        //     new todolist{Task="Build a project",
        //     Description="starting new todo",
        //     status="inprocess"},
        //     new todolist{Task="push to github",
        //     Description="push to git to make publix",
        //     status="todo"}
        // };


        return View(new todolist());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
