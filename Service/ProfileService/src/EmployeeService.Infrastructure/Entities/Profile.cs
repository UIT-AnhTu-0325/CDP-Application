using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileService.Infrastructure.Entities
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Gender { get; set; }
        //[Required]
        //public string ImageUrl { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        public DateTime FirstActivity { get; set; }
        public DateTime LastActivity { get; set; }
    }
}
