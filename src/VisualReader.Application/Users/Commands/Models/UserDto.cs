using System.Linq.Expressions;

namespace VisualReader
{
    /// <summary>
    /// chưa chuẩn cột trong database
    /// </summary>
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserTypeCode { get; set; }
        public string Role { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public bool Locked { get; set; }
        public bool Deleted { get; set; }

        private static Func<User, UserDto> Converter = Projection.Compile();

        public static Expression<Func<User, UserDto>> Projection
        {
            get
            {
                return entity => new UserDto
                {
                    Id = entity.Id,
                    Email = entity.Email,
                    PhoneNumber = entity.UserDetail.PhoneNumber,
                    Password = entity.Password,
                    FirstName = entity.UserDetail.FirstName,
                    MiddleName = entity.UserDetail.MiddleName,
                    LastName = entity.UserDetail.LastName,
                    UserTypeCode = entity.UserTypeCode,
                    Role = entity.Role,
                    CreatedUtc = entity.CreatedUtc,
                    UpdatedUtc = entity.UpdatedUtc,
                    Locked = entity.Locked,
                    Deleted = entity.Deleted,
                };
            }
        }

        public static UserDto Create(User model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}