using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabeNaoSabe.WebAPI.Model;
using SabeNaoSabe.WebAPI.Services;
using System.Net;
using System.Runtime.CompilerServices;

namespace SabeNaoSabe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;   
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [Authorize(Roles = "admin")]
        [HttpPost("AddUserRoles")]
        public async Task<IActionResult> AddUserRoles([FromBody] AddUserModel addUser)
        {
            var result = await _roleService.AddUserRolesAsync(addUser.UserEmail, addUser.Roles);
            if (!result)
            {
                return BadRequest();
            }
            return StatusCode((int)HttpStatusCode.Created, result);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("AddRoles")]
        public async Task<IActionResult> AddRoles(string[] roles)
        {
            var userRole = await _roleService.AddRolesAsync(roles);
            if(userRole.Count == 0) 
            {
                return BadRequest();
            }
            return Ok(userRole);
        }
        [Authorize(Roles = "admin")]
        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var list = await _roleService.GetRolesAsync();
            return Ok(list);
        }

        [Authorize(Roles = "admin, user")]
        [HttpGet("GetUserRole")]
        public async Task<IActionResult> GetUserRole(string userEmail)
        {
            var userClaims = await _roleService.GetUserRolesAsync(userEmail);
            return Ok(userClaims);
        }

    }
}
