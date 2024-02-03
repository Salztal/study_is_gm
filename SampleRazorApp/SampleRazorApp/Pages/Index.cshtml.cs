using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace SampleRazorApp.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; } = "no message";

        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Tel {  get; set; }

        public void OnGet()
        {
            Message = "入力してください";
        }

        public void OnPost(string name, string password, string mail, string tel)
        {
            Message = "[Name: " + name + ", password:(" + password.Length
                + " chars), mail:" + mail + " <" + tel + ">]";
        }
    }
}