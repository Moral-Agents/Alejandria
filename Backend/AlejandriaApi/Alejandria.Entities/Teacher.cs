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
        [Range(0, 5)]
        public float Rating { get; set; }
        [Range(0, 100)]
        public int Attribute1 { get; set; }
        [Range(0, 100)]
        public int Attribute2 { get; set; }
        [Range(0, 100)]
        public int Attribute3 { get; set; }
        [Range(0, 100)]
        public int Attribute4 { get; set; }
    }
}
