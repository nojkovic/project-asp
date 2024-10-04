using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Queries;
using DataAccess;
using Domain;
using Implementation.Exceptions;




namespace Implementation.UseCases.Queries
{
    public class EfGetLogErrorByIdQuery : EfUseCase, IGetLogErrorsQuery
    {
        public EfGetLogErrorByIdQuery(AspContext context) : base(context)
        {
        }

        public int Id => 41;

        public string Name => "Search error logs by id";

        public ResponseLogErrorDto Execute(string data)
        {
            LogError errorLog = Context.LogErrors.FirstOrDefault(x => data.ToLower() == x.ErrorId.ToString().ToLower());

            if (errorLog == null)
            {
                throw new NotFoundException();

            }

            return new ResponseLogErrorDto
            {
                Id = errorLog.ErrorId,
                Message = errorLog.Message,
                StrackTrace = errorLog.StrackTrace,
                Time = errorLog.Time
            };

        }
    }
}
