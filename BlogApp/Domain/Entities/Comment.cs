using Domain.Entities.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment : BaseCommonEntity
    {
        public string Text { get; set; } = "";
        public int PostId { get; set; }
        public virtual Post? Post { get; set; }
    }
}
