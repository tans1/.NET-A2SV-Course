using Application.DTO.CommentDTO;

namespace Application.DTO.PostDTO
{
       
    public class PostResponseDTO :IPostBaseDTO
    {
        public int Id { get; set; }
        public List<CommentResponseDTO> comments { get; set; }
        public string Title { get ; set ; }
        public string Content { get ; set ; }
    }
}
