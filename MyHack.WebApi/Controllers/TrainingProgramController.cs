using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHack.WebApi.Models;

namespace MyHack.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TrainingProgramController : Controller
    {
        private readonly DatabaseContext _context;

        public TrainingProgramController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<UspGetAllTrainingProgram> Get()
        {
            List<UspGetAllTrainingProgram> result = new List<UspGetAllTrainingProgram>();
            try
            {
                result = _context.Set<UspGetAllTrainingProgram>().FromSql("dbo.UspGetAllTrainingProgram").ToList();
            }
            catch (Exception ex)
            { }
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<UspGetTrainingProgramDetailByTrainingProgramId> Get(int id)
        {
            List<UspGetTrainingProgramDetailByTrainingProgramId> result = new List<UspGetTrainingProgramDetailByTrainingProgramId>();
            try
            {
                result = _context.Set<UspGetTrainingProgramDetailByTrainingProgramId>().FromSql("dbo.UspGetTrainingProgramDetailByTrainingProgramId  @TrainingProgramId = {0}", id).ToList();
            }
            catch (Exception ex)
            { }
            return result;
        }
    }
}
