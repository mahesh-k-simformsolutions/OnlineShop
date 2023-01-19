using Catalog.Data.Entity.Base;

namespace Catalog.Data.Entity
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
