using System.ComponentModel.DataAnnotations;

namespace Gorkem_.Context.Entities
{
    public class User : UTBaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }
} 