using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RealTimeTodoApp.Controllers
{
    [Route("[controller]")]
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;
        private readonly TodoService _todoService;


        public TodoController(ILogger<TodoController> logger, TodoService todoService)
        {
            _logger = logger;
            _todoService=todoService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }

    public class TodoService
    {
        
    }
}