namespace Blog_app_with_EF_Core.model;
public class Comment
{
    public int Id { get; set; }

    public string Text { get; set; } = "";

    public DateTime CreatedAt { get; set; }

    public int PostId { get; set; } // foreign key
    public virtual Post? Post {get; set; }
}
