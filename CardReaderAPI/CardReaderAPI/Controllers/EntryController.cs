using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CardReaderAPI.Models;
using CardReaderAPI.Utility;

namespace CardReaderAPI.Controllers
{
    [Route("api/Entry")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        EntryHelper helper = new EntryHelper();
        // GET: api/Entry
        [HttpGet]
        public IEnumerable<Entry> Get()
        {
            return helper.Get();
        }

        // GET: api/Entry/5
        [HttpGet("{id}")]
        public IEnumerable<Entry> Get(string id)
        {
            return helper.Get(id);
        }

        // POST: api/Entry
        [HttpPost("{id}")]
        public IActionResult Post(string id)
        {
            User user = helper.GetUser(id);
            Entry logEntry;
            if (user == null)
            {
                logEntry = new Entry(id, "Failed Attempt", "Failed Attempt", DateTime.Now);
                helper.Insert(logEntry);
                return Unauthorized();
            }
            logEntry = new Entry(id, user.Name, user.Rank, DateTime.Now);
            helper.Insert(logEntry);
            return Ok();
        }
    }
}
