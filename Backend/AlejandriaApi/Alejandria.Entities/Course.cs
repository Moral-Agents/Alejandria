using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alejandria.Entities
{
    public class Course: EntityBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string TeacherName { get; set; }
        [Required]        
        public bool TeacherLink { get; set; }

        public int TeacherCode { get; set; }
        public string TeacherMessage { get; set; }
    }
}
