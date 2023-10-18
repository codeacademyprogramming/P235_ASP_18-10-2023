using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using P235FirstApi.DTOs.AuthDTOs;
using P235FirstApi.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace P235FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        public AuthController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            AppUser appUser = new AppUser
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
            };

            IdentityResult identityResult = await _userManager.CreateAsync(appUser,registerDTO.Password);

            if (!identityResult.Succeeded)
            {
                return BadRequest(identityResult.Errors);
            }

            await _userManager.AddToRoleAsync(appUser, "Admin");

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (appUser == null) return BadRequest("Email Or Password InCorrect");

            if(!await _userManager.CheckPasswordAsync(appUser, loginDTO.Password))
            {
                return BadRequest("Email Or Password InCorrect");
            }

            IList<string> identityRoles = await _userManager.GetRolesAsync(appUser);

            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id));
            claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));
            claims.Add(new Claim(ClaimTypes.Email, appUser.Email));

            foreach (string identityRole in identityRoles) 
            {
                claims.Add(new Claim(ClaimTypes.Role, identityRole));
            }

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("JWTSetting:SecretKey").Value));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddHours(4)
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string token = handler.WriteToken(jwtSecurityToken);

            return Ok(new LoginResponseDTO { Token = token});
        }

        //[HttpGet]
        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        //    await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //    await _roleManager.CreateAsync(new IdentityRole("Member"));

        //    return Ok();
        //}
    }
}
