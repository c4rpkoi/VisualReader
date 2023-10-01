using MediatR;

namespace VisualReader.Application.Users.Commands
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