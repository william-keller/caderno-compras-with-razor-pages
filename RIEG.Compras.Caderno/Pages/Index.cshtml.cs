using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RIEG.Compras.Caderno.Data;

namespace RIEG.Compras.Caderno.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly RIEG.Compras.Caderno.Data.ApplicationDbContext _context;

        public int QtdBaixas { get; set; }
        public int QtdMedias { get; set; }
        public int QtdAltas { get; set; }

        public int QtdPadaria { get; set; }
        public int QtdMercearia { get; set; }
        public int QtdAcougue { get; set; }
        public int QtdFLV { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

            QtdBaixas = _context.Product.Count(prod => prod.PriorityId == 1);
            QtdMedias = _context.Product.Count(prod => prod.PriorityId == 2);
            QtdAltas = _context.Product.Count(prod => prod.PriorityId == 3);

            QtdPadaria = _context.Product.Count(prod => prod.CategoryId == 1);
            QtdMercearia = _context.Product.Count(prod => prod.CategoryId == 2);
            QtdAcougue = _context.Product.Count(prod => prod.CategoryId == 3);
            QtdFLV = _context.Product.Count(prod => prod.CategoryId == 4);
        }

        public void OnGet()
        {

        }
    }
}
