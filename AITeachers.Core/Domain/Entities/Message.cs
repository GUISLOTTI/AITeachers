using System;
using AITeachers.Core.Domain.Enums;

namespace AITeachers.Core.Domain.Entities
{
    public class Message
    {
        public Guid Id { get; private set; }
        public Guid ChatId { get; private set; }
        public MessageRole Role { get; private set; }
        public string Content { get; private set; }
        public int TokenCount { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? EditedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        public string? Metadata { get; private set; } // JSON

        // Navegação
        public virtual Chat Chat { get; private set; }

        protected Message() { } // Para EF Core

        public Message(Guid chatId, MessageRole role, string content, int tokenCount = 0, string? metadata = null)
        {
            if (chatId == Guid.Empty)
                throw new ArgumentException("ChatId é obrigatório.", nameof(chatId));

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Conteúdo não pode ser nulo ou vazio.", nameof(content));

            Id = Guid.NewGuid();
            ChatId = chatId;
            Role = role;
            Content = content;
            TokenCount = tokenCount;
            Metadata = metadata;
            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
        }

        // Métodos de modificação
        public void Delete() => IsDeleted = true;
        public void Edit(string newContent)
        {
            if (string.IsNullOrWhiteSpace(newContent))
                throw new ArgumentException("Conteúdo não pode ser nulo ou vazio.", nameof(newContent));

            Content = newContent;
            EditedAt = DateTime.UtcNow;
        }
    }
}