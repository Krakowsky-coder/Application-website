using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public IndexModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                Product = await _context.Products.Where(p => p.Name.Contains(SearchString)).ToListAsync();
            }
            else
                Product = await _context.Products.ToListAsync();
        }
    }
}
