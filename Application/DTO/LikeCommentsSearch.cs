﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class LikeCommentsSearch : PagedSearch
    {
        public int? UserId { get; set; }
        public int? CommentId { get; set; }
    }
}
