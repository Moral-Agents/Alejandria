using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alejandria.Entities
{
    public class Answer : EntityBase
    {
        public int CommentId { get; set; }
        public Comment Comment { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
    }
}
