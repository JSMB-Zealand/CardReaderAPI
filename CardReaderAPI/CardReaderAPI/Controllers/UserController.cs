using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CardReaderAPI.Models;
using CardReaderAPI.Utility;

namespace CardReaderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/User
        UserHelper helper = new UserHelper();
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return helper.GetUsers();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public User Get(string id)
        {
            return helper.GetUser(id);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            if (Get(value.Id) != null) return Unauthorized();
            helper.Insert(value);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            helper.Delete(id);
        }
    }
}
