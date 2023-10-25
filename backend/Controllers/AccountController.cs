using Backend.ApiModel;
using Backend.Model;
using Backend.Services;
using Backend.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers;

[ApiController]
[Route( "api/account" )]
public class AccountController : ControllerBase
{
	private readonly IConfiguration _configuration;
	private readonly NotificationService _notificationService;

	public AccountController ( IConfiguration configuration, NotificationService notificationService )
	{
		_configuration = configuration;
		_notificationService = notificationService;
	}

	[HttpGet("notifications")]
	public IEnumerable<UserNotificationPreview> GetNotifications ()
	{
		return _notificationService.GetNotificationsOfUser().Select(x =>
		{
			return new UserNotificationPreview()
			{
				Title = x.Title,
				Subject = x.Subject,
				CreateDate = x.CreateDate
			};
		});
	}

	[HttpPost("notifications/send")]
	public async Task<IActionResult> SendNotification(string message)
	{
		var notification = new UserNotification()
		{
			Title = "New Resource Created",
			Subject = message,
			CreateDate = DateTime.UtcNow
		};

		await _notificationService.SendNotificationAsync(notification);

		return Ok();
	}
}
