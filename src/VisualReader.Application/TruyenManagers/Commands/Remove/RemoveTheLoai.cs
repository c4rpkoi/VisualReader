using MediatR;

namespace VisualReader
{
    public class RemoveTheLoai : IRequest<bool>//cái bool để trong Irequest là kiểu trả về nhá
    {
        public Guid Id { get; set; }

        public RemoveTheLoai(Guid id) => Id = id;
    }
}