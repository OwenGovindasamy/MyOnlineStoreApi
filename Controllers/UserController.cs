using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyOnlineStoreAPI.Configuration;
using MyOnlineStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyOnlineStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Login(string Email, string Password)
        {
            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
            {
                throw new Exception("Unauthorized");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, Password, false);

            if (result.Succeeded)
            {
                return new UserToken
                {
                    Token = _tokenService.CreateToken(user)
                };
            }
            throw new Exception("Unauthorized");
        }
    }
}
