using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Commands.PostTags;
using Application.UseCases.Commands.Tags;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;

namespace Implementation.UseCases.Commands.PostTags
{
    public class EfAddPostTagCommand : EfUseCase, IAddPostTagCommand
    {
        AddPostTagValidatorDto _validator;
        public EfAddPostTagCommand(AspContext context, AddPostTagValidatorDto validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 17;

        public string Name => "AddPostTag";

        public void Execute(AddPostTagDto data)
        {
            _validator.ValidateAndThrow(data);
            PostTag postTag = new PostTag
            {
                TagId = data.TagId,
                PostId = data.PostId
            };

            Context.PostTags.Add(postTag);
            Context.SaveChanges();
        }
    }
}
