using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class LikePost:Entity
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int TypeLikeId { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public virtual TypeLike TypeLike { get; set; }
    }
}
