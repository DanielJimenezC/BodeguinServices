using Bodeguin.Application.Communication;
using Bodeguin.Application.Communication.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bodeguin.Application.Interface
{
    public interface ICategoryService
    {
        Task<JsonResult<List<CategoryResponse>>> GetCategories();
        Task<JsonResult<List<ProductResponse>>> GetProductsByCategory(int id);
    }
}
