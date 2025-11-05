using WebUI.Components;

namespace WebUI.Services
{
    public interface IToastService
    {
        void RegisterToast(ToastNotification toast);
        Task ShowSuccess(string message);
        Task ShowError(string message);
        Task ShowWarning(string message);
        Task ShowInfo(string message);
    }

    public class ToastService : IToastService
    {
        private ToastNotification? _toastComponent;

        public void RegisterToast(ToastNotification toast)
        {
            _toastComponent = toast;
        }

        public async Task ShowSuccess(string message)
        {
            if (_toastComponent != null)
            {
                await _toastComponent.ShowSuccess(message);
            }
        }

        public async Task ShowError(string message)
        {
            if (_toastComponent != null)
            {
                await _toastComponent.ShowError(message);
            }
        }

        public async Task ShowWarning(string message)
        {
            if (_toastComponent != null)
            {
                await _toastComponent.ShowWarning(message);
            }
        }

        public async Task ShowInfo(string message)
        {
            if (_toastComponent != null)
            {
                await _toastComponent.ShowInfo(message);
            }
        }
    }
}
