using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.CommentDTO
{
    public class CommentCreateDTO
    {
        public int PostId { get; set; }
        public string Text { get; set; }
    }
}
