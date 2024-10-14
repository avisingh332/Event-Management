using Event_Management.Business.Dtos.RequestDto;
using Event_Management.Business.Dtos.ResponseDto;
using Event_Management.Business.Services.IServices;
using Event_Management.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;

        }
        public async Task<LoginResponseDto?> Login(LoginRequestDto loginRequest)
        {
            LoginResponseDto loginResponse = null;
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginRequest.Password))
            {
                var roles = await _userManager.GetRolesAsync(user);
                var token = _jwtTokenGenerator.GenerateToken(user, roles.ToList());
                loginResponse = new LoginResponseDto
                {
                    UserId = user.Id,
                    Name = user.FullName,
                    Email = user.Email,
                    JwtToken = token,
                    Roles = roles.ToList(),
                    ExpiresIn = DateTime.UtcNow.AddDays(1),
                };
            }
            return loginResponse;
        }
    }
}
