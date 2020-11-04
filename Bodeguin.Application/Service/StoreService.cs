using AutoMapper;
using Bodeguin.Application.Communication;
using Bodeguin.Application.Communication.Response;
using Bodeguin.Application.Interface;
using Bodeguin.Domain.Entity;
using Bodeguin.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bodeguin.Application.Service
{
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StoreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<JsonResult<List<StoreResponse>>> GetStores()
        {
            var stores = await _unitOfWork.StoreRepository
                .Find(x => x.IsActive == true)
                .ToListAsync();
            var result = _mapper.Map<List<Store>, List<StoreResponse>>(stores);
            return new JsonResult<List<StoreResponse>>(true, result, "Success", 0);
        }
    }
}
