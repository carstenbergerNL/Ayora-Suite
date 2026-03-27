using System.ComponentModel.DataAnnotations;

namespace Ayora.Application.Auth.DTOs;

public sealed record ForgotPasswordRequest(
    [property: Required, EmailAddress, MaxLength(320)] string Email
);

