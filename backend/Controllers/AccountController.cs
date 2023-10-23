using Backend.ApiModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Backend.Controllers;

[ApiController]
[Route( "api/account" )]
public class AccountController : ControllerBase
{
	private readonly IConfiguration _configuration;

	public AccountController ( IConfiguration configuration )
	{
		_configuration = configuration;
	}

	[HttpGet("notifications")]
	public IEnumerable<UserNotificationPreview> GetNotifications ()
	{
		return new UserNotificationPreview[]
		{
			new UserNotificationPreview()
			{
				Title = "New Resource Created",
				Subject = "A new resource has been created in namespace brs.",
				CreateDate = DateTime.Now.Subtract(TimeSpan.FromMinutes(5))
			}
		};
	}
}
