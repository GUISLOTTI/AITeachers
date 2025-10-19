using System;

namespace AITeachers.Core.Domain.Entities
{
    public class MindMap
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ChatId { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; } // JSON 
        public string? ThumbnailUrl { get; private set; }
        public decimal FileSizeMB { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ExpiresAt { get; private set; }
        public bool IsPublic { get; private set; }
        public int ViewCount { get; private set; }
        public string? Tags { get; private set; } // JSON array

        // Navegação
        public virtual Chat Chat { get; private set; }

        protected MindMap() { } // Para EF Core

        public MindMap(Guid userId, Guid chatId, string title, string content, string? thumbnailUrl = null, decimal fileSizeMB = 0, DateTime? expiresAt = null, string? tags = null)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("UserId é obrigatório.", nameof(userId));

            if (chatId == Guid.Empty)
                throw new ArgumentException("ChatId é obrigatório.", nameof(chatId));

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Título não pode ser nulo ou vazio.", nameof(title));

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Conteúdo (JSON) não pode ser nulo ou vazio.", nameof(content));

            Id = Guid.NewGuid();
            UserId = userId;
            ChatId = chatId;
            Title = title;
            Content = content;
            ThumbnailUrl = thumbnailUrl;
            FileSizeMB = fileSizeMB;
            CreatedAt = DateTime.UtcNow;
            ExpiresAt = expiresAt;
            IsPublic = false;
            ViewCount = 0;
            Tags = tags;
        }

        // Métodos de modificação
        public void MakePublic() => IsPublic = true;
        public void MakePrivate() => IsPublic = false;
        public void IncrementViewCount() => ViewCount++;
        public void UpdateContent(string newContent)
        {
            if (string.IsNullOrWhiteSpace(newContent))
                throw new ArgumentException("Conteúdo (JSON) não pode ser nulo ou vazio.", nameof(newContent));
            Content = newContent;
        }
    }
}