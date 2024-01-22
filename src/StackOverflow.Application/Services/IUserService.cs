using StackOverflowClone.Application.Entity;
using StackOverflowClone.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowClone.Application.Services
{
    public interface IUserService
    {
        Task<User?> GetByIdAsync(Guid id);
    }
}
