using System;
using System.Collections.Generic;
using System.Text;

namespace Alejandria.Entities
{
    public class Characteristic: EntityBase
    {
        public int Atributo1 { get; set; }
        public int Atributo2 { get; set; }
        public int Atributo3 { get; set; }
        public int Atributo4 { get; set; }
        public int Atributo5 { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
