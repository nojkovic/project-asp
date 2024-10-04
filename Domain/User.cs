using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User:NamedEntity
    {
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Photo {  get; set; }
       

        public virtual ICollection<Post> Posts { get; set; }=new HashSet<Post>();
        public virtual ICollection<Favorite> Favorites { get; set; } =new HashSet<Favorite>();

        public virtual ICollection<LikePost> LikePosts { get; set; } =new HashSet<LikePost>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<LikeComment> LikeComments { get; set; } = new HashSet<LikeComment>();
        public virtual ICollection<UserUseCase> UseCases { get; set; } = new HashSet<UserUseCase>();

    }
}
