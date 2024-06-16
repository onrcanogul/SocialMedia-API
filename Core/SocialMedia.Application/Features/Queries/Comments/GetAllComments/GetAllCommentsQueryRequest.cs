using MediatR;

namespace SocialMedia.Application.Features.Queries.Comments.GetAllComments
{
    public class GetAllCommentsQueryRequest : IRequest<GetAllCommentsQueryResponse>
    {
    }
}