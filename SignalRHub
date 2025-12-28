    public interface ITaskNotificationHub
    {
        Task Status(string message,string TaskID);
        Task Progress(string progress, string TaskID);
    }
    [Authorize]
    public sealed class TaskNotificationHub:Hub<ITaskNotificationHub>
    {
    }
