using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class LikeComment:Entity
    {
        public int UserId { get; set; }
        public int CommentId { get; set; }

        public virtual User User { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
