using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public abstract class BaseTypeLikeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
    }
}
