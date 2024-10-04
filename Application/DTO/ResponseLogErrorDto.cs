using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ResponseLogErrorDto
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public string StrackTrace { get; set; }
    }
}
