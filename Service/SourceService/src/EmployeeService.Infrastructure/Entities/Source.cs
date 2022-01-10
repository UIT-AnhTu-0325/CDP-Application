using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceService.Infrastructure.Entities
{
    public class Source
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string IsActive { get; set; }
    }
}
