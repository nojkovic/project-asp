using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class SearchPostDto:PagedSearch
    {
        public int? Id { get; set; }
        public string Text { get; set; }
        public int? UserId { get; set; }
    }
    public class PostByIdDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int CountOfLikes { get; set; }

        public ICollection<AddPhotoDto> Photos { get; set; }
        public ICollection<PostTagDto> PostTags { get; set; }
        public ICollection<FavoriteDto> Favorites { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public ICollection<LikePostDto> LikePosts { get; set; }
    }

    public class PostDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }

        public string Username { get; set; }
        public int LikeCount { get; set; }
    }


}
