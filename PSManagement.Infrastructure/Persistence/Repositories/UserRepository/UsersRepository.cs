using PSManagement.Application.Contracts.Authentication;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Persistence.Repositories.UserRepository
{
    public class UsersRepository : IUsersRepository
    {
        public static List<User> Users { get; set; } = new List<User>();
        public async Task<User> AddAsync(User entity)
        {
            Users.Add(entity);
            return entity;
        }

        public async  Task DeleteAsync(User entity)
        {
            Users.Remove(entity);
        }

        public async Task<User> GetByEmail(string email)
        {
            return Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public async Task<User> GetByIdAsync(int id, ISpecification<User> specification = null)
        {
            return Users.Where(u=>u.Id == id).FirstOrDefault();
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return Users;
        }

        public async Task<IEnumerable<User>> ListAsync(ISpecification<User> spec)
        {
            return new List<User>();
        }

        public async Task<User> UpdateAsync(User entity)
        {
            return entity;
        }

    }
}
