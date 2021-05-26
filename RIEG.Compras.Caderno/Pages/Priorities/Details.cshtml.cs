using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RIEG.Compras.Caderno.Data;
using RIEG.Compras.Caderno.Pages.Models;

namespace RIEG.Compras.Caderno.Pages.Priorities
{
    public class DetailsModel : PageModel
    {
        private readonly RIEG.Compras.Caderno.Data.ApplicationDbContext _context;

        public DetailsModel(RIEG.Compras.Caderno.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Priority Priority { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Priority = await _context.Priority.FirstOrDefaultAsync(m => m.ID == id);

            if (Priority == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
