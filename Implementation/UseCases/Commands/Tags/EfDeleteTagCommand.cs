using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Commands.Tags;
using Application.UseCases.Commands.TypeLikes;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using Microsoft.EntityFrameworkCore;

namespace Implementation.UseCases.Commands.Tags
{
    public class EfDeleteTagCommand : EfUseCase, IDeleteTagCommand
    {
        private DeleteTagDtoValidator _validator;
        public EfDeleteTagCommand(AspContext context,DeleteTagDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 14;

        public string Name => "DeleteTag";

        public void Execute(BaseDTO data)
        {
            _validator.ValidateAndThrow(data);
            Tag tag = Context.Tags.Include(x => x.PostTags)
                                           .First(c => c.Id == data.Id);
            var tagPostTags = tag.PostTags;
            Context.PostTags.RemoveRange(tagPostTags);

            Context.Tags.Remove(tag);
            Context.SaveChanges();
        }
    }
}
