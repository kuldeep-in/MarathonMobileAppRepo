using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHack.WebApi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyHack.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RawDataController : Controller
    {
        private readonly DatabaseContext _context;

        public RawDataController(DatabaseContext context)
        {
            _context = context;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]List<RawData> value)
        {
            var result = _context.Set<RawTempData>().FromSql("dbo.UspCleanRawData").ToList();

            _context.RawData.AddRange(value.OrderBy(x => x.EventDate));
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
