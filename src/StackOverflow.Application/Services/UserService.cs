using StackOverflowClone.Application.Entity;
using StackOverflowClone.Application.Repositories;
using StackOverflowClone.Application.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowClone.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            return _unitOfWork.User.GetSingleAsync(id);
        }
    }
}
