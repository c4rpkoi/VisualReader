using MediatR;

namespace VisualReader
{
    public class RemoveTheLoaiTruyen : IRequest<bool>//cái bool để trong Irequest là kiểu trả về nhá
    {
        public Guid Id { get; set; }

        public RemoveTheLoaiTruyen(Guid id) => Id = id;
    }
}