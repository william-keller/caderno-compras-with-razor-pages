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
    public class DeleteModel : PageModel
    {
        private readonly RIEG.Compras.Caderno.Data.ApplicationDbContext _context;

        public DeleteModel(RIEG.Compras.Caderno.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Priority = await _context.Priority.FindAsync(id);

            if (Priority != null)
            {
                _context.Priority.Remove(Priority);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
