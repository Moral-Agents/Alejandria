using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alejandria.Entities
{
    public class User: EntityBase
    {        
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [Range(0, 1)]
        public int Role { get; set; }
        [Required]
        public string Institution { get; set; }     
        [Required]
        public string Name { get; set; }
    }
}
