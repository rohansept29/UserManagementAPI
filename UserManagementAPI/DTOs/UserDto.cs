using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserManagementAPI.DTOs
{
    public class UserDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Username { get; set; } = string.Empty;
        public string? Email { get;set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OldPassword { get; set; } = string.Empty;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [StringLength(8, MinimumLength = 4)]
        public string? NewPassword { get; set; } = string.Empty;
    }
}
