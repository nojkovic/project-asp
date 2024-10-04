using Application.UseCases.Commands.Users;
using Application.UseCases.Queries;
using Application;
using Implementation.Logging.UseCases;
using Implementation.UseCases.Commands.Users;
using Implementation.UseCases.Queries;
using Implementation.Validators;
using Implementation;
using System.IdentityModel.Tokens.Jwt;
using Application.UseCases.Commands.LikePosts;
using Application.UseCases.Commands.Tags;
using Application.UseCases.Commands.TypeLikes;
using Implementation.UseCases.Commands.LikePosts;
using Implementation.UseCases.Commands.Tags;
using Implementation.UseCases.Commands.TypeLikes;
using Application.UseCases.Commands.PostTags;
using Implementation.UseCases.Commands.PostTags;
using Application.UseCases.Commands.Comments;
using Implementation.UseCases.Commands.Comments;
using Application.UseCases.Commands.LikeComments;
using Implementation.UseCases.Commands.LikeComments;
using Implementation.UseCases.Commands.Posts;
using Application.UseCases.Commands.Posts;
using Application.UseCases.Commands.Favorites;
using Implementation.UseCases.Commands.Favorites;
using Application.UseCases.Commands.Photos;
using Implementation.UseCases.Commands.Photos;
namespace API.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<IUseCaseLogger, SPUseCaseLogger>();
            services.AddTransient<RegisterUserDtoValidator>();
            services.AddTransient<DeleteUserDtoValidator>();
            services.AddTransient<IDeleteUsersCommand, EfDeleteUserCommand>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<UpdateUserDtoValidator>();
            services.AddTransient<IUpdateUsersCommand, EfUpdateUserCommand>();
            services.AddTransient<AddTypeLikeDtoValidator>();
            services.AddTransient<IAddTypeLikeCommand, EfAddTypeLikeCommand>();
            services.AddTransient<DeleteTypeLikeDtoValidator>();
            services.AddTransient<IDeleteTypeLikeCommand, EfDeleteTypeLikeCommand>();
            services.AddTransient<IGetTypeLikeQuery, EfGetTypeLikeQuery>();
            services.AddTransient<UpdateTypeLikeDtoValidator>();
            services.AddTransient<IUpdateTypeLikeCommand, EfUpdateTypeLikeCommand>();
            services.AddTransient<AddLikePostDtoValidator>();
            services.AddTransient<IAddLikePostCommand, EfAddLikePostCommand>();
            services.AddTransient<DeleteLikePostDtoValidator>();
            services.AddTransient<IDeleteLikePostCommand, EfDeleteLikePostCommand>();
            services.AddTransient<IGetLikePostQuery, EfGetLikePostQuery>();
            services.AddTransient<UpdateLikePostDtoValidator>();
            services.AddTransient<IUpdateLikePostCommand, EfUpdateLikePostCommand>();
            services.AddTransient<AddTagDtoValidator>();
            services.AddTransient<IAddTagCommand, EfAddTagCommand>();
            services.AddTransient<DeleteTagDtoValidator>();
            services.AddTransient<IDeleteTagCommand, EfDeleteTagCommand>();
            services.AddTransient<IGetTagQuery, EfGetTagQuery>();
            services.AddTransient<UpdateTagDtoValidator>();
            services.AddTransient<IUpdateTagCommand, EfUpdateTagCommand>();
            services.AddTransient<AddPostTagValidatorDto>();
            services.AddTransient<IAddPostTagCommand, EfAddPostTagCommand>();
            services.AddTransient<DeletePostTagValidatorDto>();
            services.AddTransient<IDeletePostTagCommand, EfDeletePostTagCommand>();
            services.AddTransient<AddCommentValidatorDto>();
            services.AddTransient<IAddCommentCommand, EfAddCommentCommand>();
            services.AddTransient<DeleteCommentValidatorDto>();
            services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();
            services.AddTransient<UpdateCommentValidatorDto>();
            services.AddTransient<IUpdateCommentComand, EfUpdateCommentCommand>();
            services.AddTransient<AddLikeCommentValidatorDto>();
            services.AddTransient<IAddLikeCommentCommand, EfAddLikeCommentCommand>();
            services.AddTransient<DeleteLikeCommentValidatorDto>();
            services.AddTransient<IDeleteLikeCommentCommand, EfDeleteLikeCommentCommand>();
            services.AddTransient<UpdateLikeCommentValidatorDto>();
            services.AddTransient<IUpdateLikeCommentCommand, EfUpdateLikeCommentCommand>();
            services.AddTransient<AddPostValidatorDto>();
            services.AddTransient<IAddPostCommand, EfAddPostCommand>();
            services.AddTransient<DeletePostValidatorDto>();
            services.AddTransient<IDeletePostCommand, EfDeletePostCommand>();
            services.AddTransient<UpdatePostValidatorDto>();
            services.AddTransient<IUpdatePostCommand, EfUpdatePostCommand>();
            services.AddTransient<AddFavoriteValidatorDto>();
            services.AddTransient<IAddFavoriteCommand, EfAddFavoriteCommand>();
            services.AddTransient<DeleteFavoriteValidatorDto>();
            services.AddTransient<IDeleteFavoriteCommand, EfDeleteFavoriteCommand>();
            services.AddTransient<AddPhotoValidatorDto>();
            services.AddTransient<IAddPhotoCommand, EfAddPhotoCommand>();
            services.AddTransient<DeletePhotoValidatorDto>();
            services.AddTransient<IDeletePhotoCommand, EfDeletePhotoCommand>();
            services.AddTransient<UpdatePhotoValidatorDto>();
            services.AddTransient<IUpdatePhotoCommand, EfUpdatePhotoCommand>();
            services.AddTransient<IGetPhotoQuery, EfGetPhotoQuery>();
            services.AddTransient<IGetLikeCommentQuery, EfGetLikeCommentQuery>();
            services.AddTransient<IGetPostTagQuery, EfGetPostTagQuery>();
            services.AddTransient<IGetFavoriteQuery, EfGetFavoriteQuery>();
            services.AddTransient<IGetCommentQuery, EfGetCommentQuery>();
            services.AddTransient<IGetCommentByIdQuery, EfGetCommentByIdQuery>();
            services.AddTransient<IGetPostQuery, EfGetPostQuery>();
            services.AddTransient<IGetPostByIdQuery, EfGetPostByIdQuery>();
            services.AddTransient<IGetLogErrorsQuery, EfGetLogErrorByIdQuery>();
            services.AddTransient<IGetAuditLogQuery, EfGetAuditLogQuery>();


        }

        public static Guid? GetTokenId(this HttpRequest request)
        {
            if (request == null || !request.Headers.ContainsKey("Authorization"))
            {
                return null;
            }

            string authHeader = request.Headers["Authorization"].ToString();

            if (authHeader.Split("Bearer ").Length != 2)
            {
                return null;
            }

            string token = authHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var tokenGuid = Guid.Parse(claim);

            return tokenGuid;
        }
    }
}
