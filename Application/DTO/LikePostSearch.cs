﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class LikePostSearch:PagedSearch
    {
        public int? UserId{ get; set; }
        public int? PostId { get; set; }
        public int? TypeLikeId { get; set; }
    }
}
