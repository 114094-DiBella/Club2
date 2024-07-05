using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using WebApplication1.Dtos;
using WebApplication1.Entities;
using WebApplication1.Interfaces.IRepository;
using WebApplication1.Interfaces.IService;
using WebApplication1.Mapper;
using WebApplication1.Repositories;
using WebApplication1.Response;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usuarioRepository;
        private readonly IMapper _mapper;


        public UserService(IUserRepository usuarioRepository, IMapper mappingProfile )
        {
            this._usuarioRepository = usuarioRepository;
            this._mapper = mappingProfile;
        }
        public async Task<ApiResponse< UserDtoResponseTokenDto>> ValidateUser(UserDto user)
        {
            UsuarioEntity usuario = _mapper.Map<UsuarioEntity>( user );

            var usuarioValid = await _usuarioRepository.GetUsuario(usuario);
            ApiResponse<UserDtoResponseTokenDto> apiResponse = new ApiResponse<UserDtoResponseTokenDto>();


            if (usuarioValid == null)
            {
                apiResponse.SetError("No Existe el usuario", HttpStatusCode.BadRequest);
                return apiResponse;
            }
            var token = GenerateToken(usuarioValid);

            UserDtoResponseTokenDto userDtoToken = new UserDtoResponseTokenDto();
            userDtoToken.Email = usuarioValid.Email;
            userDtoToken.Role = usuarioValid.Roles.Nombre;
            userDtoToken.Token = token;
            apiResponse.Data = userDtoToken;



            return apiResponse;
        }


        private string GenerateToken(UsuarioEntity usu)
        {
            var claim = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, usu.Id.ToString()),
            new Claim(ClaimTypes.Email, usu.Email),
            new Claim(ClaimTypes.Role, usu.Roles.Nombre)

        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasd"));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claim,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
