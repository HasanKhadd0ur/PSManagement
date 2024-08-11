﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    public class UserRolesController : APIController
    {
        private readonly IUserRoleService _userRoleService;

        public UserRolesController(
            IUserRoleService userRoleService) : base()
        {
            _userRoleService = userRoleService;
        }

        [HttpGet("GetUserRolesAsync")]
        public async Task<ActionResult> GetUserRolesAsync(string email)
        {
            var userRoles = await _userRoleService.GetUserRolesAsync(email);
            return Ok(userRoles);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AssignUserToRoles")]
        public async Task<ActionResult> AssignUserToRolesAsync(string email, string roleName)
        {
            var roleAssigned = await _userRoleService.AssignUserToRole(email, roleName);
            return Ok(roleAssigned);
        }

        [HttpGet("IsInRole")]
        public async Task<ActionResult> IsInRoleAsync(int id, string role)
        {
            var IsInRole = await _userRoleService.IsInRoleAsync(id, role);
            return Ok(IsInRole);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteUserRole")]
        public async Task<IActionResult> RemoveUserFromRole(string email, string roleName)
        {
            var deleteUserFromRole = await _userRoleService.RemoveUserFromRole(email, roleName);
            return Ok(deleteUserFromRole);
        }


    }
}
