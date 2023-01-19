
using Catalog.Data.DTO;
using Catalog.ServiceLayer.Base;

namespace Catalog.ServiceLayer.Interface
{
    public interface IProductService : IBaseService
    {
        public Task<List<ProductDTO>> GetAll();
        public Task<ProductDTO> GetById(int productId);
        public Task<int> Add(ProductDTO productDTO);
        public Task<int> Update(ProductDTO productDTO);
        public Task<int> Delete(int productId);
    }
}
