using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Post:Entity
    {
        public string Text { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }=new HashSet<Favorite>();
        public virtual ICollection<Photo> Photos { get; set;}=new HashSet<Photo>();
        public virtual ICollection<LikePost> LikePosts { get; set; } = new HashSet<LikePost>();
        public virtual ICollection<PostTag> PostTags { get; set; } = new HashSet<PostTag>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        
    }
}
