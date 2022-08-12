using BackEnd_Zahri.DTO;
using BackEnd_Zahri.Helpers;
using BackEnd_Zahri.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackEnd_Zahri.DAL
{
    public class UserDAL : IUser
    {
        private readonly UserManager<IdentityUser> _userManager;
        private AppSettings _appsettings;

        public UserDAL(UserManager<IdentityUser> userManager,
            IOptions<AppSettings> appsettings)
        {
            _userManager = userManager;
            _appsettings = appsettings.Value;

        }
        public async Task<ReadUserDTO> Authenticate(string username, string password)
        {
            var authUser = await _userManager.FindByNameAsync(username);
            var cekUser = await _userManager.CheckPasswordAsync(authUser, password);
            if (!cekUser)
                throw new Exception("Authentikasi Tidak Berhasil !!.....");
            var user = new ReadUserDTO
            {
                Username = username
            };
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, username));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }

        public Task<IEnumerable<ReadUserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Registration(CreateUserDTO createUserDTO)
        {
            try
            {
                var newUser = new IdentityUser
                {
                    UserName = createUserDTO.Username,
                    Email = createUserDTO.Username
                };
                var result = await _userManager.CreateAsync(newUser, createUserDTO.Password);
                if (!result.Succeeded)
                {
                    StringBuilder sb = new StringBuilder();
                    var errors = result.Errors;
                    foreach (var error in errors)
                    {
                        sb.Append($"{error.Code} - {error.Description} \n");
                    }
                    throw new Exception($"Error: {sb.ToString()}");
                }
       
            }
            catch (Exception ex)
            {

                throw new Exception($"Error: {ex.Message}");

            }
        }

        public Task<CreateUserDTO> Update(CreateUserDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
