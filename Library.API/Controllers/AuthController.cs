using Library.API.Core.Models;
using Library.API.DTOs;
using Library.API.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [Route("api/auth")]
    public class AuthController : BaseApiController
    {
        private readonly IAuthRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IBookshelfRepository _bookshelfRepository;
        public AuthController(IAuthRepository repository, IConfiguration configuration, IBookshelfRepository bookshelfRepository)
        {
            _bookshelfRepository = bookshelfRepository;
            _configuration = configuration;
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userDto)
        {
            userDto.UserName = userDto.UserName.ToLower();

            if (await _repository.UserExists(userDto.UserName))
                return BadRequest("Username already exists");

            var userToCreate = new User { UserName = userDto.UserName };
            var createdUser = await _repository.Register(userToCreate, userDto.Password);
            await _bookshelfRepository.CreateInitialBookshelves(createdUser.Id);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repository.Login(userForLoginDto.UserName.ToLower(), userForLoginDto.Password);
            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.UserName)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}