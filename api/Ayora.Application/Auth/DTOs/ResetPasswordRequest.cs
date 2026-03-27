using System.ComponentModel.DataAnnotations;

namespace Ayora.Application.Auth.DTOs;

public sealed record ResetPasswordRequest(
    [property: Required, MinLength(32), MaxLength(2048)] string ResetToken,
    [property: Required, MinLength(8), MaxLength(128)] string NewPassword
);

