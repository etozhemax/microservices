using Microservices.Authentication.Api.Data;
using Microservices.Authentication.Api.Data.Context;
using Microservices.Authentication.Api.Dtos;
using Microservices.Authentication.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Authentication.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly AppDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(
            ITokenService tokenService,
            AppDbContext dbContext,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _tokenService = tokenService;
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ExecutionResult<bool>> AssignRole(RegisterRequestDto request)
        {
            var currentUser = _dbContext.AppUsers.FirstOrDefault(x => x.Email == request.Email);

            if (currentUser != null)
            {
                var isRoleExist = await _roleManager.RoleExistsAsync(request.Role);

                if (!isRoleExist)
                {
                    var identityResult = await _roleManager.CreateAsync(new IdentityRole(request.Role));
                
                    if (identityResult.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(currentUser, request.Role);
                        
                        return new ExecutionResult<bool>
                        {
                            Success = true,
                            Data = true
                        };
                    }
                }
                else
                {
                    await _userManager.AddToRoleAsync(currentUser, request.Role);

                    return new ExecutionResult<bool>
                    {
                        Success = true,
                        Data = true
                    };
                }
            }

            return new ExecutionResult<bool>
            {
                Success = false,
                Data = false
            };
        }

        public async Task<ExecutionResult<LoginResponseDto>> Login(LoginRequestDto request)
        {
            var user = await _dbContext.AppUsers.FirstOrDefaultAsync(x => x.UserName.ToLower() == request.UserName.ToLower());

            if (user != null)
            {
                var isValid = await _userManager.CheckPasswordAsync(user, request.Password);

                if (isValid)
                {
                    var userDto = new UserDto()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Name = user.Name,
                        Phone = user.PhoneNumber
                    };

                    var userRoles = await _userManager.GetRolesAsync(user);

                    return new ExecutionResult<LoginResponseDto>
                    {
                        Success = true,
                        Data = new LoginResponseDto
                        {
                            User = userDto,
                            Token = _tokenService.GetToken(user, userRoles.ToList())
                        }
                    };
                }
            }

            return new ExecutionResult<LoginResponseDto>
            {
                Success = false
            };
        }

        public async Task<ExecutionResult<RegisterResponseDto>> Register(RegisterRequestDto request)
        {
            var newUser = new AppUser()
            {
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.Phone,
                Name = request.UserName,
                NormalizedEmail = request.Email.ToUpper()
            };

            try
            {
                var identityResult = await _userManager.CreateAsync(newUser, request.Password);

                if (identityResult.Succeeded)
                {
                    var addedUser = await _dbContext.AppUsers.FirstOrDefaultAsync(x => x.UserName == request.Email);
                
                    if (addedUser != null)
                    {
                        var userDto = new UserDto()
                        {
                            Id = addedUser.Id,
                            Email = addedUser.Email,
                            Name = addedUser.Name,
                            Phone = addedUser.PhoneNumber
                        };

                        return new ExecutionResult<RegisterResponseDto>
                        {
                            Success = true,
                            Data = new RegisterResponseDto
                            {
                                User = userDto
                            }
                        };
                    }
                }
            }
            catch(Exception ex) 
            {
                return new ExecutionResult<RegisterResponseDto>
                {
                    Success = false,
                    Message = ex.Message
                };
            }

            return new ExecutionResult<RegisterResponseDto>
            {
                Success = false
            };
        }
    }
}
