using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Infrastructure.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime TimeOfEvent { get; set; }
        public string ActionOfEvent { get; set; }
        public int IdProfile { get; set; }
        public int SourceOfEvent { get; set; }
    }
}
