using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class AddCommentDto
    {
        public string Text { get; set; }
        public int? ParentId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        public List<int> ChildIds { get; set; }

    }
}
