using System;

namespace Gorkem_.Contracts.User;

public class UserResponse
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public bool IsActive { get; set; }
    public string Token { get; set; }
}
