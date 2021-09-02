using BlazorNews.Core.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorNews.Core.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Shared.Security;

namespace BlazorNews.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private UserManager<IdentityUser> _userManager;
        private IUserServices _userServices;
        private AuthenticationStateProvider _authenticationStateProvider;

        public AccountController(IAuthorizationService authorizationService, UserManager<IdentityUser> userManager, IUserServices userServices, AuthenticationStateProvider authenticationStateProvider)
        {
            _authorizationService = authorizationService;
            _userManager = userManager;
            _userServices = userServices;
            _authenticationStateProvider = authenticationStateProvider;
        }
        

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginAndRegisterDTO login)
        {
            var fullUser = await _userServices.GetUserByUserName(login.UserName);
            
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, fullUser.UserName),
                new Claim(ClaimTypes.Email, fullUser.Email),
                new Claim("UserId", fullUser.Id),
            };


            var identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = true
            };


            await HttpContext.SignInAsync(principal, properties);

            return Ok();
        }
    }
}
