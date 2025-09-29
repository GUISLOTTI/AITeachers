namespace AITeachers.Core.Domain.Entities
{
    public class UserProfile
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string? AvatarUrl { get; private set; }
        public string? Bio { get; private set; }
        public string PreferredLanguage { get; private set; }
        public string TimeZone { get; private set; }
        public string? StudyGoals { get; private set; }
        public User User { get; private set; }

        public UserProfile(Guid userId, string? avatarUrl, string? bio, string? studyGoals)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            AvatarUrl = avatarUrl;
            Bio = bio;
            StudyGoals = studyGoals;

            PreferredLanguage = "pt-BR";
            TimeZone = "America/Sao_Paulo";
        }

        protected UserProfile() { }
    }
}
