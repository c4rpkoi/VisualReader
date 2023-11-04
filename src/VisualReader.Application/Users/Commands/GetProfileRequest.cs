using MediatR;

namespace VisualReader
{
    public class GetProfileRequest : IRequest<GetProfileResponse>
    {
        public String Id { get; set; }

        public GetProfileRequest(string id)
        { Id = id; }
    }
}