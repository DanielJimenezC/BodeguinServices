using AutoMapper;
using Bodeguin.Application.Communication;
using Bodeguin.Application.Communication.Response;
using Bodeguin.Application.Interface;
using Bodeguin.Domain.Entity;
using Bodeguin.Domain.Interface;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bodeguin.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<JsonResult<List<ProductResponse>>> GetSearchProduct(string search)
        {
            var predicate = PredicateBuilder.New<Product>(true);
            predicate.And(x => x.IsActive == true);
            if (!string.IsNullOrEmpty(search)) predicate.And(x => x.Name.ToLower().Contains(search));
            var products = await _unitOfWork.ProductRepository.Find(predicate).Include(x => x.Inventories).ToListAsync();
            var response = _mapper.Map<List<Product>, List<ProductResponse>>(products);
            return new JsonResult<List<ProductResponse>>(true, response, "Success", 0);
        }
    }
}
