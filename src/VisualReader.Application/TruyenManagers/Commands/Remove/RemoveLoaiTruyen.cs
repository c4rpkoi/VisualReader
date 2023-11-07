using MediatR;

namespace VisualReader
{
    public class RemoveLoaiTruyen : IRequest<bool>//cái bool để trong Irequest là kiểu trả về nhá
    {
        public Guid Id { get; set; }

        public RemoveLoaiTruyen(Guid id) => Id = id;
    }
}