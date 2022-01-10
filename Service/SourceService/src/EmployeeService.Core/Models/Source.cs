using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SourceService.Core.Models
{
    public class Source
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string IsActive { get; set; }
    }
}
