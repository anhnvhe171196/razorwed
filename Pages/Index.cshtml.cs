using _12_EntityFramworkEx.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _12_EntityFramworkEx.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MyBlogContext myBlogContext;
        public IndexModel(ILogger<IndexModel> logger, MyBlogContext _myBlogContext)
        {
            _logger = logger;
            myBlogContext = _myBlogContext;
        }

        public void OnGet()
        {
            var posts = myBlogContext.Articles.OrderBy(a => a.Created).ToList();
            ViewData["post"] = posts;
        }
    }
}
