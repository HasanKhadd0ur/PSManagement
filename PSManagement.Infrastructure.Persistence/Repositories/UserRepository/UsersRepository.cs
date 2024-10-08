﻿using Microsoft.EntityFrameworkCore;
using PSManagement.Domain.Identity.Entities;
using PSManagement.Domain.Identity.Repositories;
using PSManagement.Infrastructure.Persistence.Repositories.Base;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Persistence.Repositories.UserRepository
{
    public class UsersRepository : BaseRepository<User> ,IUsersRepository
    {
        public UsersRepository(AppDbContext context) : base(context)
        {

        }

        public static List<User> Users { get; set; } = new List<User>();
        

        public async Task<User> GetByEmail(string email,ISpecification<User> specification = null)
        {
            return await  ApplySpecification(specification).Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        
    }
    public class RolesRepository : BaseRepository<Role>, IRolesRepository
    {
        public RolesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Role> GetByRoleName(string roleName, ISpecification<Role> specification = null)
        {
            IEnumerable<Role> roles = await this.ListAsync(specification);
            return roles.FirstOrDefault(r => r.Name == roleName);


        }
    }
}
