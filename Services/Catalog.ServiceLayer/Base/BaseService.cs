using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Catalog.ServiceLayer.Base
{
    public class BaseService<T, TIRepo> : IBaseService where T : class
    {
        protected TIRepo _repository;
        protected ILogger<T> _logger;
        protected IMapper _mapper;
        protected IHttpContextAccessor _httpContext;

        public BaseService(TIRepo repository, ILogger<T> logger, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _httpContext = httpContext;
        }
    }
}
