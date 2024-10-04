using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TypeLike:NamedEntity
    {
        public string Photo { get; set; }
        public virtual ICollection<LikePost> LikePosts { get; set; } = new HashSet<LikePost>();
    }
}
