using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RIEG.Compras.Caderno.Pages.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace RIEG.Compras.Caderno.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly RIEG.Compras.Caderno.Data.ApplicationDbContext _context;


        [BindProperty, DataType(DataType.Date)] 
        public DateTime DataDe { get; set; }


        [BindProperty, DataType(DataType.Date)] 
        public DateTime DataAte { get; set; }


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

        public async Task OnGetAsync([FromQuery] int? category, [FromQuery] int? priority,  [FromQuery] DateTime? dataDe, [FromQuery] DateTime? dataAte)
        {
            category ??= 0;
            priority ??= 0;
            dataDe ??= DateTime.Now.AddDays(-30);
            dataAte ??= DateTime.Now;
            
            DataDe = dataDe.Value;
            DataAte = dataAte.Value;

            var productsBetweenDates = await _context.Product
                .Where(p => p.InsertDate >= dataDe && p.InsertDate <= dataAte)
                .ToListAsync();

            if (category <= 0 && priority <= 0)
            {
                SelectedCategory = 0;
                SelectedPriority = 0;

                Product = productsBetweenDates;
                return;
            }

            if (category > 0 && priority > 0)
            {
                SelectedCategory = (category ?? 0);
                SelectedPriority = (priority ?? 0);

                Product = productsBetweenDates
                    .Where(product =>
                        product.CategoryId == category
                        && product.PriorityId == priority
                    )
                    .ToList();
                return;
            }

            if (category > 0)
            {
                SelectedCategory = (category ?? 0);
                SelectedPriority = 0;

                Product = productsBetweenDates
                    .Where(product => product.CategoryId == category)
                    .ToList();
                return;
            }

            if (priority > 0)
            {
                SelectedCategory = 0;
                SelectedPriority = (priority ?? 0);

                Product = productsBetweenDates
                    .Where(product => product.PriorityId == priority)
                    .ToList();
            }
        }
    }
}
