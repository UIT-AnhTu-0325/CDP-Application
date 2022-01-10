using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EventService.Core.Models
{
    public class Event
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime TimeOfEvent { get; set; }
        public string ActionOfEvent { get; set; }
        public int IdProfile { get; set; }
        public int SourceOfEvent { get; set; }
    }
}
