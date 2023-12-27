using Microsoft.AspNetCore.SignalR;

public class TodoService
{
    private readonly IHubContext<TodoHub> _hubContext;
    private readonly Subject<string> _updateStream = new Subject<string>();

    public TodoService(IHubContext<TodoHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public void SendUpdate(string todoItem)
    {
        _updateStream.OnNext(todoItem);
    }

    public void Start()
    {
        _updateStream.Subscribe(async todoItem =>
        {
            await _hubContext.Clients.All.SendAsync("ReceiveUpdate", todoItem);
        });
    }
}

internal class Subject<T>
{
    internal void OnNext(string todoItem)
    {
        throw new NotImplementedException();
    }

    internal void Subscribe(Func<object, Task> value)
    {
        throw new NotImplementedException();
    }
}