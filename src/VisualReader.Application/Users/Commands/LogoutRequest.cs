using MediatR;
using VisualReader.Application.Models.Bases;

namespace VisualReader.Application.Users.Commands
{
    public class LogoutRequest : IRequest<ResponseBase>
    {
    }
}