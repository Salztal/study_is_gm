using Microsoft.AspNetCore.Mvc;

namespace SampleMVCApp.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Input your data:";
            ViewData["name"] = "";
            ViewData["mail"] = "";
            ViewData["tel"] = "";
            return View();
        }

        [HttpPost]
        public IActionResult Form(string name, string mail, string tel)
        {
            ViewData["name"] = name;
            ViewData["mail"] = mail;
            ViewData["tel"] = tel;
            ViewData["message"] = ViewData["name"] + ", " +
                    ViewData["mail"] + ",  " + ViewData["tel"];
            return View("Index");
        }
    }
}
