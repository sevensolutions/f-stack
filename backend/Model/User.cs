using System;
using System.ComponentModel.DataAnnotations;
using UUIDNext;

namespace Backend.Model;

public sealed class User
{
	[Key]
	[Required]
	public Guid Id { get; set; } = Uuid.NewSequential();

	[MaxLength(128)]
	public string? IdentityProviderId { get; set; }

	[MaxLength( 64 )]
	public string Username { get; set; } = default!;

	[MaxLength( 64 )]
	public string? FirstName { get; set; }
	[MaxLength( 64 )]
	public string? LastName { get; set; }
	[MaxLength( 256 )]
	public string? FullName { get; set; }
	[MaxLength( 2 )]
	public string? Initials { get; set; }
	[MaxLength( 128 )]
	public string? EmailAddress { get; set; }
}
