﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class TagSearch:PagedSearch
    {
        public string Keyword { get; set; }
    }
}
