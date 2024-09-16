using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _12_EntityFramworkEx.Models;
using Microsoft.AspNetCore.Authorization;

namespace _12_EntityFramworkEx.Pages_Blog
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly _12_EntityFramworkEx.Models.MyBlogContext _context;

        public IndexModel(_12_EntityFramworkEx.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; } = default!;
        public const int ITEM_PER_PAGE = 10;
        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { get; set; }
        public int countPages { get; set; }

        public async Task OnGetAsync(string SearchString)
        {
            int totalArticle = _context.Articles.Count();
            countPages = (int)Math.Ceiling((double)totalArticle / ITEM_PER_PAGE);

            if (currentPage < 1) currentPage = 1;
            if (currentPage > countPages) currentPage = countPages;

            var list = _context.Articles.OrderByDescending(a => a.Created).Skip((currentPage - 1) * 10)
                .Take(ITEM_PER_PAGE);
            if (!string.IsNullOrEmpty(SearchString))
            {
                Article = await list.Where(a => a.Title.Contains(SearchString)).ToListAsync();
            }
            else
                Article = await list.ToListAsync();
        }
    }
}
