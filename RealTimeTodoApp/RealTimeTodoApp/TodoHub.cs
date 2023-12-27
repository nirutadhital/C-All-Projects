using Microsoft.AspNetCore.SignalR;

public class TodoHub : Hub
{
    // Your hub implementation here
    private readonly IHubContext<TodoHub> _hubContext;
    private readonly Subject<TodoHub> _updateStream = new  Subject<TodoHub>();
    public TodoHub(IHubContext<TodoHub> hubContext)
    {
        _hubContext = hubContext;
    }
    public void SendUpdate(string data)
    {
        _updateStream.OnNext(data);
    }
    // Subscribe to the updates and send them to clients
    public void Start()
    {
        _updateStream.Subscribe(async data =>
        {
            await _hubContext.Clients.All.SendAsync("ReceiveUpdate", data);
        });
    }
}
