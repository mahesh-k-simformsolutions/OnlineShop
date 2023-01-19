using Catalog.Data.DTO;
using Catalog.ServiceLayer.Base;

namespace Catalog.ServiceLayer.Interface
{
    public interface ICategoryService : IBaseService
    {
        public Task<List<CategoryDTO>> GetAll();
        public Task<CategoryDTO> GetById(int categoryId);
        public Task<int> Add(CategoryDTO categoryDTO);
        public Task<int> Update(CategoryDTO categoryDTO);
        public Task<int> Delete(int categoryId);
    }
}
