using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Photo:Entity
    {
        public int PostId { get; set; }
        public string Path { get; set; }

        public virtual Post Post { get; set; }
    }
}
