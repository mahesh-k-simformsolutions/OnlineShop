using Catalog.Data.Repository.Base;
using Catalog.Data.Repository.Interface;

namespace Catalog.Data.Repository
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(CatalogDbContext context) : base(context)
        {

        }
    }
}
