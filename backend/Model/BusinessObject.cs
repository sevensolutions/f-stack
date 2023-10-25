using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model;

public interface IBusinessObject
{
}

public interface IAuditCreate : IBusinessObject
{
	[Required]
	DateTime CreateDate { get; set; }
	[Required]
	Guid CreatedBy { get; set; }
}

public interface IAuditChange : IBusinessObject
{
	[Required]
	DateTime ChangeDate { get; set; }
	[Required]
	Guid ChangedBy { get; set; }
}

public abstract class AuditableEntity : IAuditCreate, IAuditChange
{
	[Required]
	public DateTime CreateDate { get; set; } = DateTime.UtcNow;
	[Required]
	public Guid CreatedBy { get; set; }

	[Required]
	public DateTime ChangeDate { get; set; }
	[Required]
	public Guid ChangedBy { get; set; }
}

public interface ITypesenseEntity
{

}
