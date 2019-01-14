using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASPEntityCore_05_Movie.Models;
using SPEntityCore_05_Movie.Models;

namespace ASPEntityCore_05_Movie.Pages.Models
{
    public class IndexModel : PageModel
    {
        private readonly ASPEntityCore_05_Movie.Models.ASPEntityCore_05_MovieContext _context;

        public IndexModel(ASPEntityCore_05_Movie.Models.ASPEntityCore_05_MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
