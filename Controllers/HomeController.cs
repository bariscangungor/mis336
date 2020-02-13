using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models; 
using System.Text.Json;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public Object Get() /** https://localhost:5001/home/test **/
        {
            return Json("{'code':'mis 336', 'description':'Business Program Development'}");
        }

        [HttpPost]
        public Object Post([FromBody] Student[] students) /** https://localhost:5001/home/post **/
        {
            return Json($@"
            {{
                ""message"":""students received successfully, length: {students.Length}"",
                ""receivedStudents"": {JsonSerializer.Serialize(students)}    
            }}
            ");
        }

        [HttpPost]
        public Object InsertStudents([FromBody] Student[] students) /** https://localhost:5001/home/post **/
        {
            return new ServiceResponse(){
                message=$"students received successfully, length: {students.Length}",
                result=students
            };
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "My n-tier web application page.";
            
            var students = new Student[]{
                new Student("Kemal","BIS"),
            };
            
            ViewData["Students"] = students;

            return View();
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
