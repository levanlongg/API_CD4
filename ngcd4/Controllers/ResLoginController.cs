using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ngcd4.Models;
using ngcd4.Services.Client.User;
using ngcd4.ViewModels.Client.User;

namespace ngcd4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResLoginController : ControllerBase
    {
        private readonly IUserService _context;

        public ResLoginController(IUserService context)
        {
            _context = context;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel user)
        {
            var us = await _context.Login(user);
            return Ok(us);
        }

        // POST api/<UsersController>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterViewModel user)
        {
            var res = await _context.Register(user);
            if (res == 0)
                return BadRequest();
            return Ok(res);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
