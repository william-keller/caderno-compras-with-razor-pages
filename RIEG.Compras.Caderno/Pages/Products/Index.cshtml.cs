using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RIEG.Compras.Caderno.Pages.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RIEG.Compras.Caderno.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly RIEG.Compras.Caderno.Data.ApplicationDbContext _context;

        public List<Category> Categories { get; set; }
        public List<Priority> Priorities { get; set; }

        public SelectList CategorySelectList { get; set; }
        public SelectList PrioritySelectList { get; set; }

        [BindProperty] public int SelectedCategory { get; set; } = 0;
        [BindProperty] public int SelectedPriority { get; set; } = 0;

        public IndexModel(RIEG.Compras.Caderno.Data.ApplicationDbContext context)
        {
            _context = context;
            Categories = _context.Category.ToList();
            Priorities = _context.Priority.ToList();

            var CategoriesForSelectList = new List<Category>()
            {
                new()
                {
                    ID = 0,
                    Color = "#ffffff",
                    Description = "Selecione"
                }
            };
            CategoriesForSelectList.AddRange(Categories);

            var PriorityForSelectList = new List<Priority>()
            {
                new ()
                {
                    ID = 0,
                    Color = "#ffffff",
                    Description = "Selecione"
                }
            };
            PriorityForSelectList.AddRange(Priorities);

            CategorySelectList = new SelectList(CategoriesForSelectList, nameof(Category.ID), nameof(Category.Description));
            PrioritySelectList = new SelectList(PriorityForSelectList, nameof(Priority.ID), nameof(Priority.Description));
        }

        public IList<Product> Product { get; set; } = new List<Product>();

        public async Task OnGetAsync([FromQuery] int? category, [FromQuery] int? priority)
        {
            category ??= 0;
            priority ??= 0;

            if (category <= 0 && priority <= 0)
            {
                SelectedCategory = 0;
                SelectedPriority = 0;

                Product = await _context.Product.ToListAsync();
                return;
            }

            if (category > 0 && priority > 0)
            {
                SelectedCategory = (category ?? 0);
                SelectedPriority = (priority ?? 0);

                Product = await _context
                    .Product
                    .Where(product =>
                        product.CategoryId == category
                        && product.PriorityId == priority
                    )
                    .ToListAsync();
                return;
            }

            if (category > 0)
            {
                SelectedCategory = (category ?? 0);
                SelectedPriority = 0;

                Product = await _context
                    .Product
                    .Where(product => product.CategoryId == category)
                    .ToListAsync();
                return;
            }

            if (priority > 0)
            {
                SelectedCategory = 0;
                SelectedPriority = (priority ?? 0);

                Product = await _context
                    .Product
                    .Where(product => product.PriorityId == priority)
                    .ToListAsync();
            }
        }
    }
}
