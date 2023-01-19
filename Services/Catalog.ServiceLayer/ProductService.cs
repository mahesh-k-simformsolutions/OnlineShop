using AutoMapper;
using Catalog.Data.DTO;
using Catalog.Data.Entity;
using Catalog.Data.Repository.Interface;
using Catalog.ServiceLayer.Base;
using Catalog.ServiceLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Catalog.ServiceLayer
{
    public class ProductService : BaseService<ProductService, IProductRepository>, IProductService
    {
        public ProductService(IProductRepository productRepository,
            IHttpContextAccessor httpContext,
            ILogger<ProductService> logger,
            IMapper mapper)
            : base(productRepository, logger, mapper, httpContext)
        {
        }

        public async Task<int> Add(ProductDTO productDTO)
        {
            try
            {
                Product? product = _mapper.Map<Product>(productDTO);
                return await _repository.AddAsync(product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Delete(int productId)
        {
            try
            {
                var product = await _repository.GetFirst<Product>(x => x.Id == productId);
                return await _repository.DestroyAsync(product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            try
            {
                IQueryable<Product>? list = await _repository.Filter<Product>();
                List<ProductDTO>? dtoList = _mapper.Map<List<ProductDTO>>(list);
                return dtoList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductDTO> GetById(int productId)
        {
            try
            {
                Product? product = await _repository.GetFirst<Product>(x => x.Id == productId);
                return _mapper.Map<ProductDTO>(product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Update(ProductDTO productDTO)
        {
            try
            {
                Product? product = _mapper.Map<Product>(productDTO);
                return await _repository.UpdateAsync(product);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
