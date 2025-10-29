using DAL.Entities;
using Helper.Utils.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace API.Extensions
{
    public class BAuthorizeAttribute : TypeFilterAttribute
    {
        public BAuthorizeAttribute() : base(typeof(AuthorizeAttributeImpl))
        {
        }

        private class AuthorizeAttributeImpl : IAsyncActionFilter
        {
            private readonly ITokenUtils _utils;

            public AuthorizeAttributeImpl(ITokenUtils utils)
            {
                _utils = utils;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (!CheckUserPermission(context))
                    return;

                await next();
            }

            #region Private methods
            private bool CheckUserPermission(ActionExecutingContext context)
            {
                var httpRequest = context.HttpContext.Request;

                var bearerToken = httpRequest.Headers["Authorization"].FirstOrDefault();
                string? token = null;

                if (!string.IsNullOrWhiteSpace(bearerToken))
                {
                    var match = Regex.Match(bearerToken, @"^Bearer\s+(.*)$", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        token = match.Groups[1].Value.Trim();
                    }
                }

                var userId = _utils.ValidateToken(token);
                if (userId == null)
                {
                    var res = new CommonResponse<object>
                    {
                        Success = false,
                        Message = "Unauthorized: Token không hợp lệ hoặc đã hết hạn.",
                        Data = null
                    };

                    context.Result = new UnauthorizedObjectResult(res);
                    return false;
                }

                context.HttpContext.Items["UserId"] = userId;

                return true;
            }
            #endregion
        }
    }
}
