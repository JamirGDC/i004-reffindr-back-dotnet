﻿using Microsoft.AspNetCore.Http;

namespace Reffindr.Shared.DTOs.Response.User;

public class UserUpdateRequestDto
{
    public int? CountryId { get; set; }
    public int? StateId { get; set; }
    public string? Email { get; set; } = default!;
    public string? Name { get; set; } = default!;
    public string? LastName { get; set; } = default!;
    public string? Dni { get; set; } = default;
    public string? Phone { get; set; } = default!;
    public string? Address { get; set; }
    public DateTime? BirthDate { get; set; }
    public IFormFile? ProfileImage { get; set; }
}
