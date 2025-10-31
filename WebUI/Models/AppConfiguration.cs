namespace WebUI.Models
{
    public class AppConfiguration
    {
        public GoogleAuthSettings GoogleAuth { get; set; } = new();
        public ApiSettings ApiSettings { get; set; } = new();
        public AppSettings AppSettings { get; set; } = new();
    }

    public class GoogleAuthSettings
    {
        public string ClientId { get; set; } = "";
        public string ClientSecret { get; set; } = "";
        public string AuthUrl { get; set; } = "";
        public string TokenUrl { get; set; } = "";
        public string UserInfoUrl { get; set; } = "";
    }

    public class ApiSettings
    {
        public string BaseUrl { get; set; } = "";

        public string GetFullUrl(string endpoint)
        {
            return $"{BaseUrl.TrimEnd('/')}{endpoint}";
        }
    }

    public class AppSettings
    {
        public string AppName { get; set; } = "";
        public string Version { get; set; } = "";
        public string Environment { get; set; } = "";
    }
}