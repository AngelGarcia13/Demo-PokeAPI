using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PokeAPI.Models;

namespace PokeAPI.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager) {
            _userManager = userManager;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCredentials model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);

            if (userExists != null)
                return BadRequest("User already exists!");

            User user = new User()
            {
                Email = model.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return BadRequest("User creation failed! Please check user details and try again.");

            return Ok(user);
        }

    }
}
