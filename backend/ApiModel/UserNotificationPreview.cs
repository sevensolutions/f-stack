using System;
using System.Text.Json.Serialization;

namespace Backend.ApiModel;

public sealed class UserNotificationPreview
{
	[JsonPropertyName( "id" )]
	public int Id { get; set; } = default!;

	[JsonPropertyName( "createDate" )]
	public DateTime CreateDate { get; set; }
	[JsonPropertyName( "createBy" )]
	public UserInfo CreatedBy { get; set; } = default!;

	[JsonPropertyName( "title" )]
	public string Title { get; set; } = default!;

	[JsonPropertyName( "subject" )]
	public string? Subject { get; set; }
}
