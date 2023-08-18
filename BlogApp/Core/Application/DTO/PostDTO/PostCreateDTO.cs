
namespace Application.DTO.PostDTO
{
    public class PostCreateDTO : IPostBaseDTO
    {
        public string Title { get; set; }
        public string Content { get ; set; }
    }
}
