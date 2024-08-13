using BlazorBootstrap;

namespace TodoList.Client.Interfaces
{
    public interface INotificationService
    {
        void AddToastMessage(ToastType level, string title, string message);
    }
}
