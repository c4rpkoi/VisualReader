using MediatR;
using VisualReader.Application.Users.Commands.Models;

namespace VisualReader.Application.Users.Commands
{
    public class GetProfileRequest : IRequest<GetProfileResponse>
    {
        public String Id { get; set; }

        public GetProfileRequest(string id)
        { Id = id; }
    }
}