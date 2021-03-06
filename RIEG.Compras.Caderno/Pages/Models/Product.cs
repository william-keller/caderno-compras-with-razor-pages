using System;
using System.ComponentModel.DataAnnotations;

namespace RIEG.Compras.Caderno.Pages.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public decimal? Quantity { get; set; }

        [DataType(DataType.Date)]
        public DateTime InsertDate { get; set; }

        public int CategoryId { get; set; }
        public int PriorityId { get; set; }
    }
}
