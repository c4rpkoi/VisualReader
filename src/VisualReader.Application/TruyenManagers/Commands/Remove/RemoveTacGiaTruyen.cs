using MediatR;

namespace VisualReader
{
    public class RemoveTacGiaTruyen : IRequest<bool>//cái bool để trong Irequest là kiểu trả về nhá
    {
        public Guid Id { get; set; }

        public RemoveTacGiaTruyen(Guid id) => Id = id;
    }
}