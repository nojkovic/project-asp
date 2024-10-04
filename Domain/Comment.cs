using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Comment:Entity
    {
        public int UserId { get; set; }
        public string Text { get; set; }
        public int PostId { get; set; }
        public int? ParentId { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public virtual Comment Parent { get; set; }

        public virtual ICollection<Comment> Children { get; set;}=new HashSet<Comment>();
        public virtual ICollection<LikeComment> LikeComments { get; set; } = new HashSet<LikeComment>();
    }
}
