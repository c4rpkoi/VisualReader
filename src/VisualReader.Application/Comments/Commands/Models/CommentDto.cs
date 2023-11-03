using System.Linq.Expressions;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.Comments.Commands.Models
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public Guid? PostId { get; set; }
        public Guid? ChapterId { get; set; }
        public Guid? BookId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public string Content { get; set; }
        public User? User { get; set; }
        public Chapter? Chapter { get; set; }
        public Book? Book { get; set; }
        public Post? Posts { get; set; }
        private static Func<Comment, CommentDto> Converter = Projection.Compile();

        public static Expression<Func<Comment, CommentDto>> Projection
        {
            get
            {
                return entity => new CommentDto
                {
                    Id = entity.Id,
                    PostId = entity.PostId,
                    ChapterId = entity.ChapterId,
                    BookId = entity.BookId,
                    UserId = entity.UserId,
                    CreatedUtc = entity.CreatedUtc,
                    UpdatedUtc = entity.UpdatedUtc,
                    Content = entity.Content,
                    User = entity.User,
                    Posts = entity.Post,
                    Chapter=entity.Chapter,
                    Book=entity.Book
                };
            }
        }

        public static CommentDto Create(Comment model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }

    }
}
