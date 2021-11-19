using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alejandria.Entities
{
    public class Comment: EntityBase
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
    }
}
