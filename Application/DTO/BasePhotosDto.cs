using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public abstract class BasePhotosDto
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int PostId { get; set; }
    }
}
