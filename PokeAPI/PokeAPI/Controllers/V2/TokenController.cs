using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PokeAPI.Models;

namespace PokeAPI.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public TokenController(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        // POST: api/Token
        [HttpPost]
        public async Task<IActionResult> PostToken([FromBody] UserCredentials model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.Users.Include(x => x.RefreshTokens).FirstOrDefaultAsync(x => x.NormalizedUserName == model.UserName.ToUpper());
        
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                //Generate Refresh Token
                var refreshToken = GenerateRefreshToken();
                user.RefreshTokens.Add(new RefreshToken {
                    Expires = DateTime.Now.AddDays(30),
                    Token = refreshToken
                });
                //Save Refresh Token
                await _userManager.UpdateAsync(user);
                //Generate JWT for the user.
                var token = new JwtSecurityTokenHandler().WriteToken(GenerateJwt(model.UserName));
                return Ok(new {
                    accessToken = token,
                    refreshToken = refreshToken,
                    refreshTokenExpires = DateTime.Now.AddDays(30)
                });
            }
            return Unauthorized();
        }


        // POST: api/Token/Refresh
        [HttpPost("Refresh")]
        public async Task<IActionResult> PostRefreshToken([FromBody] RefreshTokenRequestModel model) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.Users.Include(x => x.RefreshTokens).FirstOrDefaultAsync(x => x.RefreshTokens.Any(t => t.Token == model.RefreshToken && t.Expires > DateTime.Now));
            if (user != null)
            {
                //Generate Refresh Token
                var refreshToken = GenerateRefreshToken();
                user.RefreshTokens.Add(new RefreshToken
                {
                    Expires = DateTime.Now.AddDays(30),
                    Token = refreshToken
                });
                //Save Refresh Token
                await _userManager.UpdateAsync(user);
                //Generate JWT for the user.
                var token = new JwtSecurityTokenHandler().WriteToken(GenerateJwt(user.UserName));
                return Ok(new
                {
                    accessToken = token,
                    refreshToken = refreshToken,
                    refreshTokenExpires = DateTime.Now.AddDays(30)
                });

            }
            return Unauthorized();
        }

        private JwtSecurityToken GenerateJwt(string userName)
        {
            var claims = new[]
        {
            new Claim(ClaimTypes.Name, userName)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return token;

        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                
                return Convert.ToBase64String(randomNumber) + Guid.NewGuid().ToString();
            }
        }

    }
}
