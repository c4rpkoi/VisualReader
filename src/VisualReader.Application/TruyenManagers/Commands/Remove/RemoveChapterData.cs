using MediatR;

namespace VisualReader
{
    public class RemoveChapterData : IRequest<bool>//cái bool để trong Irequest là kiểu trả về nhá
    {
        public Guid Id { get; set; }

        public RemoveChapterData(Guid id) => Id = id;
    }
}