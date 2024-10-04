using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Commands.PostTags;
using Application.UseCases.Commands.Users;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;

namespace Implementation.UseCases.Commands.PostTags
{
    public class EfDeletePostTagCommand : EfUseCase, IDeletePostTagCommand
    {
        DeletePostTagValidatorDto _validator;

        public EfDeletePostTagCommand(AspContext context, DeletePostTagValidatorDto validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 18;

        public string Name => "DeletePostTag";

        public void Execute(BasePostTagDto data)
        {
            _validator.ValidateAndThrow(data);
            PostTag postTag = Context.PostTags.FirstOrDefault(x => x.TagId == data.TagId && x.PostId == data.PostId);


            Context.PostTags.Remove(postTag);

            Context.SaveChanges();
        }
    }
}
