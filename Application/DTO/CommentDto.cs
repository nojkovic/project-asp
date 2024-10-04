using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public IEnumerable<CommentDto> Children { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int? ParentId { get; set; }

    }
}
