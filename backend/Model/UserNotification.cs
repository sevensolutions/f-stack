using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Model;

public sealed class UserNotification : IAuditCreate
{
	[Key]
	[Required]
	[DatabaseGenerated( DatabaseGeneratedOption.Identity )]
	public int Id { get; set; } = default!;

	[Required]
	public Guid UserId { get; set; }

	[Required]
	public DateTime CreateDate { get; set; } = DateTime.UtcNow;
	[Required]
	public Guid CreatedBy { get; set; }

	[Required]
	[MaxLength( 128 )]
	public string Title { get; set; } = default!;

	[MaxLength( 256 )]
	public string? Subject { get; set; }

	[MaxLength( 16 )]
	public string? ContentType { get; set; }
	public string? Content { get; set; }

	[Column( TypeName = "jsonb" )]
	public Dictionary<string, object?>? Data { get; set; }
}
