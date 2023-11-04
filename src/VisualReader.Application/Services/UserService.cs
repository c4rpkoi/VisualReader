using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace VisualReader
{
    public class UserService : IUserService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;

        public UserService(IAuthenticationService authenticationService, IUnitOfWork unitOfWork, IUserContext userContext)
        {
            _authenticationService = authenticationService;
            _unitOfWork = unitOfWork;
            _userContext = userContext;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
        {
            var response = new LoginResponse(false, null, null);
            var user = await GetUserByEmailAsync(request.UserName);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            var userValid = CheckLoginSuccess(user.Password, request.Password);
            if (userValid)
            {
                var token = _authenticationService.GenerateToken(user.Email, user.Role);
                response.IsSuccess = true;
                response.AccessToken = token.AccessToken;
                response.UrlRedirect = "home";
            }
            return response;
        }

        public bool CheckLoginSuccess(string password, string passwordRequest)
        {
            var passwordHash = GenerateMD5(passwordRequest);
            return passwordHash.Equals(password);
        }

        public async Task<ResponseBase> LogoutAsync(LogoutRequest request, CancellationToken cancellationToken)
        {
            var response = new ResponseBase();
            response.IsSuccess = false;

            var token = _userContext.Token;
            if (string.IsNullOrEmpty(token))
                throw new Exception();

            await _authenticationService.RevokeTokenAsync(token);
            response.IsSuccess = true;

            return response;
        }

        public async Task<User> GetUserByEmailAsync(string userName)
        {
            return await _unitOfWork.Users.AsQueryable().AsNoTracking().FirstOrDefaultAsync(x => !x.Locked && !x.Deleted && x.Email.Equals(userName));
        }

        public string GenerateMD5(string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken)
        {
            var response = new RegisterResponse(false, null);
            var user = RegisterRequest.Create(request);
            try
            {
                var userExists = await GetUserByEmailAsync(request.Email);
                if (userExists != null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }
                user.Password = GenerateMD5(user.Password);
                user.UserDetail = new UserDetail() { Id = user.Id, };
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.CommitAsync();
                response.IsSuccess = true;
                response.UserId = user.Id.ToString();
                await ProcessSendEmailAsync(user.Id, user.Email);
            }
            catch (Exception ex)
            {
                throw;
            }
            return response;
        }

        public async Task<bool> ProcessSendEmailAsync(Guid id, string email)
        {
            try
            {
                string ID = id.ToString();
                byte[] bytesToEncode = Encoding.UTF8.GetBytes(ID);
                string EncodedId = Convert.ToBase64String(bytesToEncode);
                string senderEmailAddress = "hanhng125@gmail.com";
                string appPassword = "ifax pcso kobq ayld";
                string recipientEmail = email;
                string subject = "Verify User";
                string confirmButtonHtml = $"<p><a href='https://localhost:5001/dct/users/verify/{EncodedId}' style='background-color: #008CBA; color: white; padding: 10px 20px; text-decoration: none;'>Xác nhận tài khoản</a></p>";
                string body = $"<html><body><p>Enter this link to verify your account:</p>{confirmButtonHtml}</body></html>";
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential(senderEmailAddress, appPassword);

                    using (MailMessage mailMessage = new MailMessage(senderEmailAddress, recipientEmail, subject, body))
                    {
                        mailMessage.IsBodyHtml = true;
                        mailMessage.Body = body;
                        smtpClient.Send(mailMessage);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> VerifyAccountAsync(VerifyRequest request, CancellationToken cancellationToken)
        {
            string id = request.Id;
            byte[] decodedBytes = Convert.FromBase64String(id);
            string decodedId = Encoding.UTF8.GetString(decodedBytes);
            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(decodedId));
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            user.Verified = true;
            await _unitOfWork.BeginTransactionAsync();
            await _unitOfWork.Users.UpdateAsync(user.Id, user);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> UpdateProfileAsync(UpdateProfileRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var id = request.Id;
                var user = await _unitOfWork.Users.AsQueryable().Include(x => x.UserDetail).FirstOrDefaultAsync(x => x.Id == id);
                if (user == null)
                    throw new EntityNotFoundException();
                user.UserDetail.Address = request.Address;
                user.UserDetail.Avatar = await ConvertImageToBase64Async(request.AvatarFile);
                user.UserDetail.FirstName = request.FirstName;
                user.UserDetail.PhoneNumber = request.PhoneNumber;
                user.UserDetail.LastName = request.LastName;
                user.UserDetail.MiddleName = request.MiddleName;
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Users.UpdateAsync(user.Id, user);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<GetProfileResponse> GetProfileAsync(GetProfileRequest request, CancellationToken cancellationToken)
        {
            var response = new GetProfileResponse(null, null, null, null, null, null);
            var user = await _unitOfWork.Users.AsQueryable().Include(x => x.UserDetail).FirstOrDefaultAsync(x => x.Id == Guid.Parse(request.Id));
            if (user == null)
                throw new EntityNotFoundException();
            else
            {
                response.PhoneNumber = user.UserDetail.PhoneNumber;
                response.FirstName = user.UserDetail.FirstName;
                response.MiddleName = user.UserDetail.MiddleName;
                response.LastName = user.UserDetail.LastName;
                response.Address = user.UserDetail.Address;
                response.Avatar = user.UserDetail.Avatar;
                return response;
            }
        }

        public async Task<string> ConvertImageToBase64Async(IFormFile imageFile)
        {
            if (imageFile == null)
                return null;
            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
    }
}