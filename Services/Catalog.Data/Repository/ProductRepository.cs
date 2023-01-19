using Catalog.Data.Repository.Base;
using Catalog.Data.Repository.Interface;

namespace Catalog.Data.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(CatalogDbContext context) : base(context)
        {

        }
    }
}
