using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alejandria.Entities
{
    public class Teacher: EntityBase
    {
        [Required]
        public string Name { get; set; }
        public string Img { get; set; }
        [Required]
        public string Institution { get; set; }
        public string Description { get; set; }
        [Required]
        public string Course { get; set; }
        public float Rating { get; set; }
    }
}
