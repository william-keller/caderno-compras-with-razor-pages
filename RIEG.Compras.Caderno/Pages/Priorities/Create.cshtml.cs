using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RIEG.Compras.Caderno.Data;
using RIEG.Compras.Caderno.Pages.Models;

namespace RIEG.Compras.Caderno.Pages.Priorities
{
    public class CreateModel : PageModel
    {
        private readonly RIEG.Compras.Caderno.Data.ApplicationDbContext _context;

        public CreateModel(RIEG.Compras.Caderno.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Priority Priority { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Priority.Add(Priority);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
