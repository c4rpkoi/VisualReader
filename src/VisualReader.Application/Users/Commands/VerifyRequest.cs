using MediatR;

namespace VisualReader
{
    public class VerifyRequest : IRequest<bool>
    {
        public string Id { get; set; }

        public VerifyRequest(string id)
        {
            Id = id;
        }
    }
}