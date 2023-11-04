using MediatR;

namespace VisualReader
{
    public class GetCommentById : IRequest<CommentDto>
    {
        public Guid Id { get; set; }

        public GetCommentById(Guid id) => Id = id;
    }
}