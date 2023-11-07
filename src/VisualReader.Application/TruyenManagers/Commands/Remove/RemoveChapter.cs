using MediatR;

namespace VisualReader
{
    public class RemoveChapter : IRequest<bool>//cái bool để trong Irequest là kiểu trả về nhá
    {
        public Guid Id { get; set; }

        public RemoveChapter(Guid id) => Id = id;
    }
}