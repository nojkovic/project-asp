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

namespace Implementation.UseCases.Commands.Tags
{
    public class EfUpdateTagCommand : EfUseCase, IUpdateTagCommand
    {
        private UpdateTagDtoValidator _validator;
        public EfUpdateTagCommand(AspContext context,UpdateTagDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 16;

        public string Name => "UpdateTag";

        public void Execute(UpdateTagDto data)
        {
            _validator.ValidateAndThrow(data);
            Tag tag = Context.Tags.First(x => x.Id == data.Id);
            tag.Name = data.Name;
            
            Context.SaveChanges();
        }
    }
}
