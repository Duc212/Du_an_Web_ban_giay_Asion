using Microsoft.AspNetCore.Http;

namespace Helper.Utils
{
    public static class HttpContextHelper
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static int GetUserId()
        {
            if (_httpContextAccessor?.HttpContext == null)
            {
                return 0;
            }

            return (int)(_httpContextAccessor.HttpContext.Items["UserId"] ?? 0);
        }
    }
}
