using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSManagement.Api.Controllers.ApiBase;
using PSManagement.Application.Contracts.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSManagement.Api.Controllers.Roles
{
    [Route("api/[controller]")]
    public class RolesController : APIController
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoleAsync()
        {
            var getRoles = await _roleService.GetRolesAsync();
            return Ok(getRoles);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleByIdAsync(int id)
        {
            var getRolesById = await _roleService.GetRoleByIdAsync(id);
            return HandleResult(getRolesById);
        }

        [Authorize( Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateRoleAsync(string roleName)
        {
            var roleCreated = await _roleService.CreateRoleAsync(roleName);
            return HandleResult(roleCreated);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteRoleAsync(int id)
        {
            var deleteRole = await _roleService.DeleteRoleAsync(id);
            return HandleResult(deleteRole);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> UpdateRoleAsync(int id, string roleName)
        {
            var updateRole = await _roleService.UpdateRole(id, roleName);
            return HandleResult(updateRole);
        }
    }
}
