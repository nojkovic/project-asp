using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Application;

namespace Implementation
{
    public class DefaultActorProvider : IApplicationActorProvider
    {
        public IApplicationActor GetActor()
        {
            return new Actor
            {
                Username = "lastuser",
                Email = "user@gmail.com",
                Id =2,
                FirstName = "User1",
                LastName = "Lastname"
            };
        }
    }
}
