using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Queries;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Implementation.UseCases.Queries
{
    public class EfGetCommentByIdQuery : EfUseCase, IGetCommentByIdQuery
    {
        public EfGetCommentByIdQuery(AspContext context) : base(context)
        {
        }

        public int Id => 39;

        public string Name => "SeacrhByIdComment";

        public CommentResponsWithChildrenForComments Execute(int search)
        {
            Comment c = Context.Comments.Include(x => x.Children).ThenInclude(x => x.Children).FirstOrDefault(x => x.Id == search);

            if (c == null)
            {
                throw new Exception("NotFound");
            }

            CommentResponsWithChildrenForComments dto = new()
            {
                Id = c.Id,
                ParentId = c.ParentId,
                Text = c.Text,
                UserId = c.UserId,
                PostId = c.PostId
            };

            FillChildrenOfParents(dto);

            return dto;

        }



        private void FillChildrenOfParents(CommentResponsWithChildrenForComments comment)
        {
            int id = comment.Id;

            comment.Childrens = Context.Comments.Where(x => x.ParentId == id).Select(c => new CommentResponsWithChildrenForComments
            {
                Id = c.Id,
                ParentId = c.ParentId,
                Text = c.Text,
                UserId = c.UserId,
                PostId = c.PostId

            }).ToList();

            foreach (CommentResponsWithChildrenForComments child in comment.Childrens)
            {
                FillChildrenOfParents(child);
            }
        }

    }
}

