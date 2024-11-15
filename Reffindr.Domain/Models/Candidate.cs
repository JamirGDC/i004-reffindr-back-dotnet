﻿namespace Reffindr.Domain.Models;

public class Candidate : BaseModel
{
    public int ApplicationId { get; set; } 
    public bool SelectedByTenant { get; set; }

    public virtual Application? Application { get; set; }
}