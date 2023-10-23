using System.Text.Json.Serialization;

namespace Backend.ApiModel;

public sealed class UserInfo
{
	[JsonPropertyName( "fullName" )]
	public string FullName { get; set; } = default!;
	[JsonPropertyName( "initials" )]
	public string Initials { get; set; } = default!;
	[JsonPropertyName( "email" )]
	public string Email { get; set; } = default!;
	[JsonPropertyName( "profileImage" )]
	public string ProfileImage { get; set; } = default!;
}
