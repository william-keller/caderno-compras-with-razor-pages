using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RIEG.Compras.Caderno.Data;
using RIEG.Compras.Caderno.Pages.Models;

namespace RIEG.Compras.Caderno.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly RIEG.Compras.Caderno.Data.ApplicationDbContext _context;

        public SelectList Categories { get; set; }
        public SelectList Priorities { get; set; }

        public CreateModel(RIEG.Compras.Caderno.Data.ApplicationDbContext context)
        {
            _context = context;
            Categories = new SelectList(_context.Category.ToList(), nameof(Category.ID), nameof(Category.Description));
            Priorities = new SelectList(_context.Priority.ToList(), nameof(Priority.ID), nameof(Priority.Description));
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
