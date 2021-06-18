using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHack.WebApi.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<CategoryMaster> CategoryMaster { get; set; }
        public DbSet<EventMaster> EventMaster { get; set; }
        public DbSet<EventCategoryRelation> EventCategoryRelation { get; set; }
        public DbSet<TrainingProgram> TrainingProgram { get; set; }
        public DbSet<TrainingProgramDetail> TrainingProgramDetail { get; set; }
        public DbSet<RawData> RawData { get; set; }


        public DbSet<UspGetAllEvents> UspGetAllEvents { get; set; }
        public DbSet<UspGetAllTrainingProgram> UspGetAllTrainingProgram { get; set; }
        public DbSet<UspGetTrainingProgramDetailByTrainingProgramId> UspGetTrainingProgramDetailByTrainingProgramId { get; set; }
        public DbSet<RawTempData> UspCleanRawData { get; set; }
        
    }
}
