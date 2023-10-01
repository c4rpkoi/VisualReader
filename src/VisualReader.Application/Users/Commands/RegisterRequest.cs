using MediatR;
using System.Linq.Expressions;
using VisualReader.Application.Users.Commands.Models;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.Users.Commands
{
    public class RegisterRequest : IRequest<RegisterResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        private static Func<RegisterRequest, User> Converter = Projection.Compile();

        public static Expression<Func<RegisterRequest, User>> Projection
        {
            get
            {
                return entity => new User
                {
                    Email = entity.Email,
                    Password = entity.Password,
                };
            }
        }

        public static User Create(RegisterRequest model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}