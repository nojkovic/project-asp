using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.UseCases.Commands.Comments
{
    public interface IAddCommentCommand : ICommand<AddCommentDto>
    {

    }
}
