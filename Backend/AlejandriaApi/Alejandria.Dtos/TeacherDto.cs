using System;
using System.Collections.Generic;
using System.Text;

namespace Alejandria.Dtos
{
    public class TeacherDto
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Institution { get; set; }
        public string Description { get; set; }
        public string Course { get; set; }
        public float Rating { get; set; }
        public int Attribute1 { get; set; }
        public int Attribute2 { get; set; }
        public int Attribute3 { get; set; }
        public int Attribute4 { get; set; }
    }
}
