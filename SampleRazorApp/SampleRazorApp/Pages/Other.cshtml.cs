using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleRazorApp.Pages
{
    public enum Gender
    {
        male,
        female
    }

    public enum Platform
    {
        Windows,
        macOS,
        Linux,
        ChromeOS,
        Android,
        iOS
    }

    public class OtherModel : PageModel
    { 
        public string? Message { get; set; }

        public bool Check {  get; set; }
        public Gender Gender { get; set; }
        public Platform Platform { get; set; }
        public Platform[] Platforms { get; set; }

        public void OnGet()
        {
            Message = "check & sekect it!";
        }

        public void OnPost(bool check, string gender, Platform pc, Platform[] pc2)
        {
            Message = "Result: " + check + "," + gender + "," + pc + ", " + pc2.Length;
        }
    }
}
