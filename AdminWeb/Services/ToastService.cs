namespace AdminWeb.Services;

public class ToastService
{
    public event Action<string,string,string>? OnShow; // (type, message, icon)

    public void Success(string message) => Show("success", message, "fas fa-check-circle");
    public void Error(string message) => Show("error", message, "fas fa-times-circle");
    public void Info(string message) => Show("info", message, "fas fa-info-circle");

    private void Show(string type, string message, string icon)
    {
        OnShow?.Invoke(type, message, icon);
    }
}
