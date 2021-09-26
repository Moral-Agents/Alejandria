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
        public string Email { get; set; }
        [Required]
        [StringLength(25)]
        public string Password { get; set; }
        [Required]
        public int Role { get; set; }
        [Required]
        public string Institution { get; set; }     
        
        public string Name { get; set; }

    }
}
