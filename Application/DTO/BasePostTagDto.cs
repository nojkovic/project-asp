using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public abstract class BasePostTagDto
    {
        public int TagId { get; set; }
        public int PostId { get; set; }
    }
}
