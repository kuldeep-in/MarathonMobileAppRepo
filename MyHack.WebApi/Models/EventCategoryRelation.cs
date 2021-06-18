using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyHack.WebApi.Models
{
    public class EventCategoryRelation
    {
        [Key]
        public int EventCategoryRelationId { get; set; }
    }
}
