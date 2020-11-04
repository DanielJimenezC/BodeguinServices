using AutoMapper;
using Bodeguin.Application.Communication;
using Bodeguin.Application.Communication.Response;
using Bodeguin.Application.Interface;
using Bodeguin.Domain.Entity;
using Bodeguin.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bodeguin.Application.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<JsonResult<List<CategoryResponse>>> GetCategories()
        {
            var categories = await _unitOfWork.CategoryRepository
                .Find(x => x.IsActive == true)
                .Include(x => x.Products)
                .ToListAsync();
            var response = _mapper.Map<List<Category>, List<CategoryResponse>>(categories);
            return new JsonResult<List<CategoryResponse>>(true, response, "success", 0);
        }

        public async Task<JsonResult<List<ProductResponse>>> GetProductsByCategory(int id)
        {
            var products = await _unitOfWork.ProductRepository
                .Find(x => x.CategoryId == id && x.IsActive == true)
                .Include(x => x.Inventories)
                .OrderBy(x => x.Name)
                .ToListAsync();
            var response = _mapper.Map<List<Product>, List<ProductResponse>>(products);
            return new JsonResult<List<ProductResponse>>(true, response, "Success", 0);
        }
    }
}
