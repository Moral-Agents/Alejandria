using System;
using System.Collections.Generic;
using System.Text;

namespace Alejandria.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }        
        public string Password { get; set; }        
        public int Role { get; set; }        
        public string Institution { get; set; }
        public string Name { get; set; }
    }
}
