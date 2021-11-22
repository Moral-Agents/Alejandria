using System;
using System.Collections.Generic;
using System.Text;

namespace Alejandria.Dtos
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
    }
}
