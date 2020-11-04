using AutoMapper;
using Bodeguin.Application.Communication;
using Bodeguin.Application.Communication.Request;
using Bodeguin.Application.Interface;
using Bodeguin.Application.Validators;
using Bodeguin.Domain.Entity;
using Bodeguin.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Bodeguin.Application.Service
{
    public class ShopService : IShopService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ShopService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<JsonResult<string>> SaveShopCart(ShopCartRequest shopCartRequest)
        {
            var voucher = _mapper.Map<ShopCartRequest, Voucher>(shopCartRequest);
            var time = DateTime.Now;
            voucher.CreateAt = time;
            voucher.IsActive = true;
            voucher.ModifiedAt = time;
            var result = await _unitOfWork.VoucherRepository.AddAsync(voucher, new CartValidator());
            if (!result.IsValid)
                return new JsonResult<string>(false, null, "Register Error", 4);
            await _unitOfWork.SaveChangesAsync();
            foreach (var item in shopCartRequest.Detail)
            {
                var detail = _mapper.Map<DetailRequest, Detail>(item);
                detail.Discount = 0;
                detail.VoucherId = voucher.Id;
                var inventory = await _unitOfWork.InventoryRepository.Find(x => x.Id == item.InventoryId).Include(x => x.Product).FirstOrDefaultAsync();
                var invetoryUpdate = await _unitOfWork.InventoryRepository.Find(x => x.Id == item.InventoryId).FirstOrDefaultAsync();
                if (item.Quantity > inventory.Quantity)
                {
                    var resutl = await _unitOfWork.VoucherRepository.DeleteAsync(voucher, new CartValidator());
                    await _unitOfWork.SaveChangesAsync();
                    return new JsonResult<string>(false, inventory.Product.Name , "Register Error", 4);
                }
                invetoryUpdate.Quantity -= detail.Quantity;
                invetoryUpdate.ModifiedAt = time;
                var resultUpdate = await _unitOfWork.InventoryRepository.UpdateAsync(invetoryUpdate, new InventoryValidator());
                var resultDetail = await _unitOfWork.DetailRepository.AddAsync(detail, new CartDetailValidator());
                if (!resultDetail.IsValid)
                    return new JsonResult<string>(false, null, "Register Error", 4);
            }
            await _unitOfWork.SaveChangesAsync();
            return new JsonResult<string>(true, "Success", "Success", 0);
        }
    }
}
