using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace VisualReader
{
    public class SystemMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;
        private readonly IList<string> AuthenIngorePath = new List<string>() { "/token", "/revoke", "/dct/users/login", "/dct/users/logout", "/dct/users/register", "/dct/users/verify" };

        public SystemMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (IsAttributeAuthen(context))
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (!await IsRequestAuthenticated(context.Request.Path.Value, token))
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.WriteAsync("Unauthorize");
                    return;
                }
                else if (!string.IsNullOrEmpty(token))
                {
                    var isValidUser = await SetUserContextAsync(context, token);
                    if (!isValidUser)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        await context.Response.WriteAsync("Unauthorize");
                        return;
                    }
                }
            }
            await _next(context);
        }

        private async Task<bool> SetUserContextAsync(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwt = tokenHandler.ReadJwtToken(token);
                var userClaim = jwt.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name));
                if (userClaim != null)
                {
                    var userName = userClaim.Value;
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var _userService = scope.ServiceProvider.GetRequiredService<IUserService>();
                        var user = await _userService.GetUserByEmailAsync(userName);
                        var userContext = context.RequestServices.GetService(typeof(IUserContext)) as IUserContext;
                        userContext.SetId(user.Id);
                        userContext.SetUserName(user.Email);
                        userContext.SetName(user.UserDetail?.FirstName, user.UserDetail?.MiddleName, user.UserDetail?.LastName);
                        userContext.SetRole(user.Role);
                        userContext.SetTokenRequest(token);
                    }
                }
                else
                {
                    var userContext = context.RequestServices.GetService(typeof(IUserContext)) as IUserContext;
                    userContext.SetUserName("System");
                    userContext.SetTokenRequest(token);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> IsRequestAuthenticated(string requestPath, string token)
        {
            if (AuthenIngorePath.Any(x => requestPath.ToLower().Contains(x)))
                return true;

            if (string.IsNullOrEmpty(token))
                return false;

            using (var scope = _serviceProvider.CreateScope())
            {
                var _authenticationService = scope.ServiceProvider.GetRequiredService<IAuthenticationService>();

                var tokenRevoked = await _authenticationService.IsTokenRevoke(token);

                if (tokenRevoked)
                    return false;
            }

            return true;
        }

        private bool IsAttributeAuthen(HttpContext context)
        {
            var authorizeAttribute = context.GetEndpoint()?.Metadata.GetMetadata<AuthorizeAttribute>();

            if (authorizeAttribute == null)
                return false;

            if (authorizeAttribute != null && !context.User.Identity.IsAuthenticated)
            {
                return true;
            }
            return true;
        }
    }
}