using Microsoft.JSInterop;

namespace WebUI.Services
{
    public interface ILoadingService
    {
        bool IsLoading { get; }
        string? Title { get; }
        string? Message { get; }
        string? IconClass { get; }
        bool ShowProgress { get; }
        int? ProgressValue { get; }
        
        event Action? OnStateChanged;
        
        void Show(string? title = null, string? message = null, string? iconClass = "fas fa-spinner fa-spin");
        void ShowWithProgress(string? title = null, string? message = null, int progress = 0);
        void UpdateProgress(int progress);
        void UpdateMessage(string message);
        void Hide();
    }

    public class LoadingService : ILoadingService
    {
        public bool IsLoading { get; private set; }
        public string? Title { get; private set; }
        public string? Message { get; private set; }
        public string? IconClass { get; private set; }
        public bool ShowProgress { get; private set; }
        public int? ProgressValue { get; private set; }

        public event Action? OnStateChanged;

        public void Show(string? title = null, string? message = null, string? iconClass = "fas fa-spinner fa-spin")
        {
            IsLoading = true;
            Title = title;
            Message = message;
            IconClass = iconClass;
            ShowProgress = false;
            ProgressValue = null;
            
            OnStateChanged?.Invoke();
        }

        public void ShowWithProgress(string? title = null, string? message = null, int progress = 0)
        {
            IsLoading = true;
            Title = title;
            Message = message;
            IconClass = null;
            ShowProgress = true;
            ProgressValue = progress;
            
            OnStateChanged?.Invoke();
        }

        public void UpdateProgress(int progress)
        {
            if (IsLoading && ShowProgress)
            {
                ProgressValue = Math.Max(0, Math.Min(100, progress));
                OnStateChanged?.Invoke();
            }
        }

        public void UpdateMessage(string message)
        {
            if (IsLoading)
            {
                Message = message;
                OnStateChanged?.Invoke();
            }
        }

        public void Hide()
        {
            IsLoading = false;
            Title = null;
            Message = null;
            IconClass = null;
            ShowProgress = false;
            ProgressValue = null;
            
            OnStateChanged?.Invoke();
        }
    }
}