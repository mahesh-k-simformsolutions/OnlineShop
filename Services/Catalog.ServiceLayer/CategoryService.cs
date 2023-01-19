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
    public class CategoryService : BaseService<CategoryService, ICategoryRepository>, ICategoryService
    {
        public CategoryService(ICategoryRepository categoryRepository,
            IHttpContextAccessor httpContext,
            ILogger<CategoryService> logger,
            IMapper mapper)
            : base(categoryRepository, logger, mapper, httpContext)
        {
        }

        public async Task<int> Add(CategoryDTO categoryDTO)
        {
            try
            {
                Category? category = _mapper.Map<Category>(categoryDTO);
                return await _repository.AddAsync(category);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Delete(int categoryId)
        {
            try
            {
                var category = await _repository.GetFirst<Category>(x => x.Id == categoryId);
                return await _repository.DestroyAsync(category);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CategoryDTO>> GetAll()
        {
            try
            {
                IQueryable<Category>? list = await _repository.Filter<Category>();
                List<CategoryDTO>? dtoList = _mapper.Map<List<CategoryDTO>>(list);
                return dtoList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CategoryDTO> GetById(int categoryId)
        {
            try
            {
                Category? category = await _repository.GetFirst<Category>(x => x.Id == categoryId);
                return _mapper.Map<CategoryDTO>(category);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Update(CategoryDTO categoryDTO)
        {
            try
            {
                Category? category = _mapper.Map<Category>(categoryDTO);
                return await _repository.UpdateAsync(category);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
