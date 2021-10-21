using System;
using System.Collections.Generic;
using System.Text;

namespace Alejandria.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
    }
}
