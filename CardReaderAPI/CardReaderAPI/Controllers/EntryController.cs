using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CardReaderAPI.Models;
using CardReaderAPI.Utility;

namespace CardReaderAPI.Controllers
{
    [Route("api/[controller]")]
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
        public Entry Get(int id)
        {
            return helper.Get(id);
        }

        // POST: api/Entry
        [HttpPost]
        public bool Post([FromBody] int id)
        {
            User user = helper.GetUser(id);
            Entry logEntry = new Entry();
            if(user == null)
            {
                logEntry.Id = id;
                logEntry.Name = "Failed Attempt";
                logEntry.Rank = "Failed Attempt";
                logEntry.Time = DateTime.Now;
                helper.Insert(logEntry);
                return false;
            }
            logEntry.Id = id;
            logEntry.Name = user.Name;
            logEntry.Rank = user.Rank;
            logEntry.Time = DateTime.Now;
            helper.Insert(logEntry);
            return true;
        }

        // PUT: api/Entry/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
