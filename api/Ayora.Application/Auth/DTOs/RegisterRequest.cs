using System.ComponentModel.DataAnnotations;

namespace Ayora.Application.Auth.DTOs;

public sealed record RegisterRequest(
    [property: Required, EmailAddress, MaxLength(320)] string Email,
    [property: Required, MinLength(8), MaxLength(128)] string Password
);

