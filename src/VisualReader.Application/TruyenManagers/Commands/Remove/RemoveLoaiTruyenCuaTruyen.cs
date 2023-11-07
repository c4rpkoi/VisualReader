using MediatR;

namespace VisualReader
{
    public class RemoveLoaiTruyenCuaTruyen : IRequest<bool>//cái bool để trong Irequest là kiểu trả về nhá
    {
        public Guid Id { get; set; }

        public RemoveLoaiTruyenCuaTruyen(Guid id) => Id = id;
    }
}