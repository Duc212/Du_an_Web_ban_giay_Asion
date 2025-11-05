using Microsoft.JSInterop;
using System.Text.Json;
using WebUI.Models;

namespace WebUI.Services
{
    public class ConfigurationService
    {
        private readonly HttpClient _httpClient;
        private AppConfiguration? _configuration;
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        public ConfigurationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AppConfiguration> GetConfigurationAsync()
        {
            if (_configuration != null)
                return _configuration;

            await _semaphore.WaitAsync();
            try
            {
                if (_configuration != null)
                    return _configuration;

                var response = await _httpClient.GetAsync("appsettings.json");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    _configuration = JsonSerializer.Deserialize<AppConfiguration>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new AppConfiguration();
                }
                else
                {
                    _configuration = new AppConfiguration();
                }

                return _configuration;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ConfigService] Error loading configuration: {ex.Message}");
                return new AppConfiguration();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<GoogleAuthSettings> GetGoogleAuthSettingsAsync()
        {
            var config = await GetConfigurationAsync();
            return config.GoogleAuth;
        }

        public async Task<ApiSettings> GetApiSettingsAsync()
        {
            var config = await GetConfigurationAsync();
            return config.ApiSettings;
        }

        public async Task<AppSettings> GetAppSettingsAsync()
        {
            var config = await GetConfigurationAsync();
            return config.AppSettings;
        }

        public async Task<string> GetApiBaseUrlAsync()
        {
            var apiSettings = await GetApiSettingsAsync();
            return apiSettings.BaseUrl ?? "https://localhost:7134";
        }
    }
}