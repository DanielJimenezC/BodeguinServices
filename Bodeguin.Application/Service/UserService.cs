using AutoMapper;
using Bodeguin.Application.Communication;
using Bodeguin.Application.Communication.Request;
using Bodeguin.Application.Communication.Response;
using Bodeguin.Application.Interface;
using Bodeguin.Application.Validators;
using Bodeguin.Domain.Entity;
using Bodeguin.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Bodeguin.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<JsonResult<UserResponse>> GetUser(int id)
        {
            var user = await _unitOfWork.UserRepository.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (user is null || user.IsActive == false)
                return new JsonResult<UserResponse>(false, null, "The user doesn't exist", 1);
            var result = _mapper.Map<User, UserResponse>(user);
            return new JsonResult<UserResponse>(true, result, "Success", 0);
        }

        public async Task<JsonResult<UserResponse>> UpdateUser(int id, UserUpdateRequest userUpdateRequest)
        {
            var user = await _unitOfWork.UserRepository.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (user is null || user.IsActive == false)
                return new JsonResult<UserResponse>(false, null, "The user doesn't exist", 1);
            var updateUser = _mapper.Map(userUpdateRequest, user);
            updateUser.ModifiedAt = DateTime.Now;
            var result = await _unitOfWork.UserRepository.UpdateAsync(updateUser, new UserValidator());
            if (!result.IsValid)
                return new JsonResult<UserResponse>(false, null, "Update Error", 5);
            await _unitOfWork.SaveChangesAsync();
            var response = _mapper.Map<User, UserResponse>(updateUser);
            return new JsonResult<UserResponse>(true, response, "Success", 0);
        }
    }
}
