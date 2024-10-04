using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CommentWithoutChildsDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int? ParentId { get; set; }
        public int PostId { get; set; }
    }

    public class SearchCommentsDTO : PagedSearch
    {
        public int? Id { get; set; }
        public int? ParentId { get; set; }
        public string Text { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }
    }
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int? ParentId { get; set; }
        public ICollection<CommentDTO> Childrens { get; set; }
    }

    public class CommentResponsWithChildren : CommentDTO
    {
        public ICollection<CommentResponsWithChildren> Childrens;
    }

    public class CommentResponsWithChildrenForComments
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int? ParentId { get; set; }
        public int PostId { get; set; }

        public IEnumerable<CommentResponsWithChildrenForComments> Childrens { get; set; }

    }
}
