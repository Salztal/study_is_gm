using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleRazorApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string Message { get; set; }
        private string[][] data = new string[][] 
        {
        new string[]{"Taro", "taro@yamada"},
        new string[]{"Hanako", "hanako@flower"},
        new string[]{"Sachiko", "sachiko@happy"}
        };

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public void OnGet()
        {
            Message = "これはMessageプロパティの値です。";
        }

        public string GetData(int id)
        {
            string[] target = data[id];
            return $"[名前：{target[0]}、メール：{target[1]}]";
        }


    }
}
