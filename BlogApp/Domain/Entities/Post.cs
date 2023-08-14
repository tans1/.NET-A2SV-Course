using Domain.Entities.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Post : BaseCommonEntity
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
