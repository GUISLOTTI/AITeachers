using AITeachers.Core.Domain.Enums;

namespace AITeachers.Core.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string PasswordSalt { get; private set; }
        public UserType UserType { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastLoginAt { get; private set; }
        public bool EmailConfirmed { get; private set; }
        public string? EmailConfirmationToken { get; private set; }
        public bool IsActive { get; set; }

        public User(string name, string email, string passwordHash, string passwordSalt, UserType userType)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            UserType = userType;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
            EmailConfirmed = false;
        }
    }
}