using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;
using Data.Entities;

namespace Business.Abstraction
{
    public interface IUserService
    {
        Task<object> Login(LoginModel model);

        Task<object> Register(UserRegistrationModel model);
    }
}