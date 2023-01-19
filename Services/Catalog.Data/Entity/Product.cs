using Catalog.Data.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Data.Entity
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int AvailableStock { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
