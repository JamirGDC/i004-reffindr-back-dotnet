﻿using Microsoft.AspNetCore.Http;
using Reffindr.Shared.DTOs.Request.Requirement;

namespace Reffindr.Shared.DTOs.Request.Property;

public class PropertyPostRequestDto
{
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public string Title { get; set; } = default!;
    public string Address { get; set; } = default!;
    public int Environments { get; set; }
    public int Bathrooms { get; set; }
    public int Bedrooms { get; set; }
    public int Seniority { get; set; }
    public bool Water { get; set; }
    public bool Gas { get; set; }
    public bool Surveillance { get; set; }
    public bool Electricity { get; set; }
    public bool Internet { get; set; }
    public bool Pool { get; set; }
    public bool Garage { get; set; }
    public bool Pets { get; set; }
    public bool Grill { get; set; }
    public bool Elevator { get; set; }
    public bool Terrace { get; set; }
    public string Description { get; set; } = default!;
    public List<IFormFile>? Images { get; set; } 
    public string OwnerEmail { get; set; } = default!;
    public decimal Price { get; set; } = default!;

    public virtual RequirementPostRequestDto? RequirementPostRequestDto { get; set; }
}
