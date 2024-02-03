using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleRazorApp.Pages
{
    public class OtherModel : PageModel
    {
        public string Message { get; set; }

        public void OnPost()
        {
            Message = "you typed:" + Request.Form["msg"];
        }
    }
}
