﻿namespace Reffindr.Domain.Models;

public class Property : BaseModel
{
	public int OwnerId { get; set; }
    public int TenantId { get; set; }
	public int RequirementId { get; set; }
	public int CountryId { get; set; }
	public int StateId { get; set; }
    public string Title { get; set; } = default!;
	public string Address { get; set; } = default!;
	public string Description { get; set; } = default!;

	#region Navigation Properties

	public virtual Requirement? Requirement { get; set; }
	public virtual Country? Country { get; set; }
	public virtual State? State { get; set; }
	public virtual List<Application>? Application { get; set; }

	#endregion Navigation Properties
}