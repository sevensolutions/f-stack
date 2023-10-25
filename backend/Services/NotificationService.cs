using Backend.Model;
using Backend.SignalR;
using Microsoft.AspNetCore.SignalR;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Services;

public class NotificationService
{
	private readonly IHubContext<NotificationsHub> _hubContext;
	private List<UserNotification> _userNotifications = new List<UserNotification>();

	public NotificationService(IHubContext<NotificationsHub> hubContext)
	{
		_hubContext = hubContext;
	}

	public IEnumerable<UserNotification> GetNotificationsOfUser()
	{
		return _userNotifications;
	}

	public async Task SendNotificationAsync(UserNotification notification)
	{
		_userNotifications.Add(notification);

		await _hubContext.Clients.All.SendAsync("NewNotification", notification);
	}
}
