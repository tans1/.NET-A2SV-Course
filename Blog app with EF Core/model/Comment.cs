using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_app_with_EF_Core.model
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; } = "";

        public DateTime CreatedAt { get; set; } =  DateTime.UtcNow;

        public int PostId { get; set; }
        
        public virtual Post? Post { get; set; }
    }
}
