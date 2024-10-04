using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PostTag
    {
        public int TagId { get; set; }
        public int PostId { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Post Post { get; set; }
        
    }
}
