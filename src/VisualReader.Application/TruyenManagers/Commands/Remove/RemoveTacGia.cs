using MediatR;

namespace VisualReader
{
    public class RemoveTacGia : IRequest<bool>//cái bool để trong Irequest là kiểu trả về nhá
    {
        public Guid Id { get; set; }

        public RemoveTacGia(Guid id) => Id = id;
    }
}