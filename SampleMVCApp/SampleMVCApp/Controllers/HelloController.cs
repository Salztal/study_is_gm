using Microsoft.AspNetCore.Mvc;

namespace SampleMVCApp.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet("Hello/{id?}/{name?}")]
        public IActionResult Index(int id, string name)
        {
            ViewData["message"] = "※セッションにIDとNameを保存しました。";
            HttpContext.Session.SetInt32("id", id);
            HttpContext.Session.SetString("name", name);
            return View();
        }

        [HttpGet("Other")]
        public IActionResult Other()
        {
            ViewData["id"] = HttpContext.Session.GetInt32("id");
            ViewData["name"] = HttpContext.Session.GetString("name");
            ViewData["message"] = "保存されたセッションの値を表示します。";
            return View("Index");
        }
    }
}
