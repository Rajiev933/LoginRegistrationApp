using LoginRegistrationApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LoginRegistrationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginRegisterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;

        public LoginRegisterController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("dbcs"));
        }

        // Registration Endpoint
        [HttpPost("Register")]
        public Response Register(Register user)
        {
            if (ModelState.IsValid)
            {
                Response response = new Response();
                DAL dal = new DAL();
                response = dal.Register(user, _connection);
                return response;
            }
            return new Response();
        }

        // Login Endpoint
        [HttpPost("Login")]
        public Response Login(Login user)
        {
            if (!ModelState.IsValid)
            {
                Response response = new Response();
                DAL dal = new DAL();
                response = dal.Login(user, _connection);
                return response;
            }
            return new Response();
        }
    }
}
