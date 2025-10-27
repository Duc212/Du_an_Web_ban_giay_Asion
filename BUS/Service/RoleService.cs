using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class RoleService
    {
        private readonly RoleRepository _roleRepo;

        public RoleService(RoleRepository roleRepo)
        {
            _roleRepo = roleRepo;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _roleRepo.GetAllAsync();
        }
        public async Task<Role?> GetRoleByIdAsync(int id)
        {
            return await _roleRepo.GetByIdAsync(id);
        }

        public async Task<Role?> GetRoleByNameAsync(string name)
        {
            return await _roleRepo.GetByNameAsync(name);
        }


    }
}
