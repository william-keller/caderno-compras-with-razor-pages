using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RIEG.Compras.Caderno.Data;
using RIEG.Compras.Caderno.Pages.Models;

namespace RIEG.Compras.Caderno.Pages.Priorities
{
    public class EditModel : PageModel
    {
        private readonly RIEG.Compras.Caderno.Data.ApplicationDbContext _context;

        public EditModel(RIEG.Compras.Caderno.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Priority).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriorityExists(Priority.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PriorityExists(int id)
        {
            return _context.Priority.Any(e => e.ID == id);
        }
    }
}
