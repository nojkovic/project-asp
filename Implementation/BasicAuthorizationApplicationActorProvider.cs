using Application;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Implementation
{
    public class BasicAuthorizationApplicationActorProvider : IApplicationActorProvider
    {
        private string _authorizationHeader;
        private AspContext _context;

        public BasicAuthorizationApplicationActorProvider(string authorizationHeader, AspContext context)
        {
            _authorizationHeader = authorizationHeader;
            _context = context;
        }

        public IApplicationActor GetActor()
        {
            //if (_authorizationHeader == null || !_authorizationHeader.Contains("Basic"))
            //{
            //    return new UnauthorizedActor();
            //}

            //var base64Data = _authorizationHeader.Split(" ")[1];

            //var bytes = Convert.FromBase64String(base64Data);

            //var decodedCredentials = System.Text.Encoding.UTF8.GetString(bytes);

            //if (decodedCredentials.Split(":").Length < 2)
            //{
            //    throw new InvalidOperationException("Invalid Basic authorization header.");
            //}

            //string username = decodedCredentials.Split(":")[0];
            //string password = decodedCredentials.Split(":")[1];

            User u = _context.Users.FirstOrDefault(x => x.Username == "lastuser" && x.Password=="user123");
            
            if(u == null)
            {
                return new UnauthorizedActor();
            }

            var useCases = _context.UserUseCases.Select(x => x.UseCaseId).ToList();

            return new Actor
            {
                Email = u.Email,
                FirstName = u.Name,
                Id = u.Id,
                LastName = u.LastName,
                Username = u.Username,
                AllowedUseCases = useCases
            };
        }
    }
}
