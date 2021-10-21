using System.Threading.Tasks;
using DotNet5MvcJwtAuth.Models;
using DotNet5MvcJwtAuth.Repositories;
using DotNet5MvcJwtAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet5MvcJwtAuth.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
        {
            var user = UserRepository.Get(model.UserName, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário não encontrado"});

            var token = TokenService.GenerateToken(user);

            return new
            {
                user = user,
                token = token
            };
        } 
    }
}