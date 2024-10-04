using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class SearchPhoto : PagedSearch
    {
        public int? PostId { get; set; }
        
    }
}
