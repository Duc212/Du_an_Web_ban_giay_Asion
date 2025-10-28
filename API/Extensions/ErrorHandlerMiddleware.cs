using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using DAL.Entities;

namespace API.Extensions
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly string _langCode;

        public ErrorHandlerMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
        {
            _langCode = configuration["ProjectSettings:LanguageCode"] ?? "vi";
            _next = next;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException vex)
            {
                if (context.Response.HasStarted) return;

                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest;

                var res = new CommonResponse<object>
                {
                    Success = false,
                    Message = vex.Message, 
                    Data = null
                };

                var json = JsonSerializer.Serialize(res, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                await response.WriteAsync(json);
            }
            catch (Exception error)
            {
                if (context.Response.HasStarted) return;

                var response = context.Response;
                response.ContentType = "application/json";

                int statusCode = (int)HttpStatusCode.InternalServerError;
                string message = "Đã xảy ra lỗi trong hệ thống.";

                if (error is KeyNotFoundException)
                {
                    statusCode = (int)HttpStatusCode.NotFound;
                    message = "Không tìm thấy dữ liệu.";
                }

                // Ghi log lỗi
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<ErrorHandlerMiddleware>>();
                    logger.LogError(error, "Unhandled exception occurred");
                }

                var res = new CommonResponse<object>
                {
                    Success = false,
                    Message = message,
                    Data = null
                };

                response.StatusCode = statusCode;

                var json = JsonSerializer.Serialize(res, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                await response.WriteAsync(json);
            }
        }
    }
}
