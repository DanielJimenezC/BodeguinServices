using AutoMapper;
using Bodeguin.Application.Communication;
using Bodeguin.Application.Communication.Request;
using Bodeguin.Application.Communication.Response;
using Bodeguin.Application.Interface;
using Bodeguin.Application.Security.Encript;
using Bodeguin.Application.Security.JsonWebToken;
using Bodeguin.Application.Validators;
using Bodeguin.Domain.Entity;
using Bodeguin.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Bodeguin.Application.Service
{
    public class LoginService : ILoginService
    {
        private readonly IJWTFactory _jWTFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LoginService (IJWTFactory jWTFactory, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _jWTFactory = jWTFactory;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<JsonResult<LoginResponse>> SignIn(LoginRequest loginRequest)
        {
            User user = new User();
            user = await _unitOfWork.UserRepository.Find(x => x.Email.Equals(loginRequest.Email)).FirstOrDefaultAsync();
            string pass = Encript.EncriptText("123456");
            if (user is null || user.IsActive == false)
                return new JsonResult<LoginResponse>(false, null, "The user doesn't exist", 1);
            if (user.Password.Trim() != Encript.EncriptText(loginRequest.Password.Trim()))
                return new JsonResult<LoginResponse>(false, null, "Wrong Password", 2);
            var token = await _jWTFactory.GetJWT(loginRequest.Email);
            var loginResponse = _mapper.Map<User, LoginResponse>(user);
            loginResponse.Token = token;
            return new JsonResult<LoginResponse>(true, loginResponse, "Success", 0);
        }

        public async Task<JsonResult<LoginResponse>> SignUp(SignUpRequest signUpRequest)
        {
            var userExist = await _unitOfWork.UserRepository.Find(x => x.Email.Equals(signUpRequest.Email)).ToListAsync();
            if (userExist.Count > 0)
                return new JsonResult<LoginResponse>(false, null, "The user already exist", 3);
            var actualTime = DateTime.Now;
            var user = _mapper.Map<SignUpRequest, User>(signUpRequest);
            user.IsActive = true;
            user.IsAdmin = false;
            user.Direction = "-";
            user.Dni = "-";
            user.CreateAt = actualTime;
            user.ModifiedAt = actualTime;
            var result = await _unitOfWork.UserRepository.AddAsync(user, new UserValidator());
            if (!result.IsValid)
                return new JsonResult<LoginResponse>(false, null, "Register Error", 4);
            await _unitOfWork.SaveChangesAsync();
            var responseUser = await _unitOfWork.UserRepository.Find(x => x.Email.Equals(signUpRequest.Email)).FirstOrDefaultAsync();
            var loginResponse = _mapper.Map<User, LoginResponse>(responseUser);
            return new JsonResult<LoginResponse>(true, loginResponse, "Success", 0);
        }
    }
}
