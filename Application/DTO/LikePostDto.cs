using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class LikePostDto:BaseLikesPostDto
    {
        public string Username { get; set; }
        public string NameTypeLike { get; set; }


    }
}
