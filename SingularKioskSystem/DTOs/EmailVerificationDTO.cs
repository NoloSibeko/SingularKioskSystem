using System.ComponentModel.DataAnnotations;

namespace SingularKioskSystem.DTOs;

public class EmailVerificationDTO
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Token { get; set; }
}