using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Commands.LikePosts;
using Application.UseCases.Commands.Tags;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;

namespace Implementation.UseCases.Commands.Tags
{
    public class EfAddTagCommand : EfUseCase, IAddTagCommand
    {
        private AddTagDtoValidator _validator;
        public EfAddTagCommand(AspContext context,AddTagDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "AddTag";

        public void Execute(AddTagDto data)
        {
            _validator.ValidateAndThrow(data);
            Tag tag = new Tag
            {
                Name = data.Name
            };

            Context.Tags.Add(tag);
            Context.SaveChanges();

        }
    }
}
