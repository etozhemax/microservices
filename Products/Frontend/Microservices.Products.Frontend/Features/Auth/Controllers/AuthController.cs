using Microservices.Products.Frontend.Features.Auth.Dtos;
using Microservices.Products.Frontend.Features.Auth.Enums;
using Microservices.Products.Frontend.Features.Auth.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Microservices.Products.Frontend.Features.Auth.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ICookieTokenProvider _cookieTokenProvider;

        public AuthController(
            IAuthService authService,
            ICookieTokenProvider cookieTokenProvider)
        {
            _authService = authService;
            _cookieTokenProvider = cookieTokenProvider;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var loginRequest = new LoginRequestDto();

            return View(loginRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                InitializeRoleDropdown();

                return View();
            }

            var responseDto = await _authService.Login(request);

            if (responseDto == null || !responseDto.Success)
            {
                ModelState.AddModelError("CustomError", responseDto?.Message ?? "test");
                return View();
            }

            await SignIn(responseDto.Data?.Token);
            _cookieTokenProvider.SetToken(responseDto.Data?.Token);

            return RedirectToAction("Index", "Home");
        }

        private async Task SignIn(string? token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var jwtToken = jwtSecurityTokenHandler.ReadJwtToken(token);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            var emailTokenValue = jwtToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Email)?.Value;
            
            if (emailTokenValue != null)
            {
                identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, emailTokenValue));
            }

            var subTokenValue = jwtToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub)?.Value;

            if (subTokenValue != null)
            {
                identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, subTokenValue));
            }

            var nameTokenValue = jwtToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Name)?.Value;

            if (nameTokenValue != null)
            {
                identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name, nameTokenValue));
                identity.AddClaim(new Claim(ClaimTypes.Name, nameTokenValue));
            }

            var rolesTokenValue = jwtToken.Claims.Where(x => x.Type == "role").ToList();

            if (!rolesTokenValue.IsNullOrEmpty())
            {
                identity.AddClaims(rolesTokenValue.Select(role => new Claim(ClaimTypes.Role, role.Value)));
            }

            var claimPrincipal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _cookieTokenProvider.ClearToken();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            var registerRequest = new RegisterRequestDto();

            InitializeRoleDropdown();

            return View(registerRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                InitializeRoleDropdown();

                return View();
            }

            var responseDto = await _authService.Register(request);

            if (responseDto == null || !responseDto.Success)
            {
                InitializeRoleDropdown();

                return View();
            }

            var isAssignedRole = await _authService.AssignRole(request);

            if (isAssignedRole == null || !isAssignedRole.Success)
            {
                InitializeRoleDropdown();

                return View();
            }

            return RedirectToAction("Login");
        }

        private void InitializeRoleDropdown()
        {
            var roleList = new List<SelectListItem>
            {
                new(RoleType.Admin, RoleType.Admin),
                new(RoleType.User, RoleType.User)
            };

            ViewBag.RoleList = roleList;
        }
    }
}
