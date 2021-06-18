using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHack.WebApi.Models;

namespace MyHack.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly DatabaseContext _context;

        public EventController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<UspGetAllEvents> Get()
        {
            List<UspGetAllEvents> result = new List<UspGetAllEvents>();
            try
            {
                result = _context.Set<UspGetAllEvents>().FromSql("dbo.UspGetAllEvents").ToList();
            }
            catch (Exception ex)
            { }
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
