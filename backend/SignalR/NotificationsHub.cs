using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Backend.SignalR;

public class NotificationsHub : Hub
{
	public override Task OnConnectedAsync ()
	{
		return base.OnConnectedAsync();
	}
}
