using AutoMapper;
using Bodeguin.Application.Communication;
using Bodeguin.Application.Communication.Response;
using Bodeguin.Application.Interface;
using Bodeguin.Domain.Entity;
using Bodeguin.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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
            var categories = await _unitOfWork.CategoryRepository.Find(x => x.IsActive == true).Include(x => x.Products).ToListAsync();
            var response = _mapper.Map<List<Category>, List<CategoryResponse>>(categories);
            return new JsonResult<List<CategoryResponse>>(true, response, "success", 0);
        }
    }
}
