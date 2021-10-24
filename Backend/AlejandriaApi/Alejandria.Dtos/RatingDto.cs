using System;
using System.Collections.Generic;
using System.Text;

namespace Alejandria.Dtos
{
    public class RatingDto
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
    }
}
