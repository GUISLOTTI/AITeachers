using System;
using System.Collections.Generic;

namespace AITeachers.Core.Domain.Entities
{
    public class Chat
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid AgentId { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastMessageAt { get; private set; }
        public DateTime? ExpiresAt { get; private set; }
        public bool IsArchived { get; private set; }
        public bool IsPinned { get; private set; }
        public int TokensUsed { get; private set; }
        public int MessageCount { get; private set; }

        // Navegação
        public virtual Agent Agent { get; private set; }
        public virtual ICollection<Message> Messages { get; private set; }
        public virtual ICollection<ChatRating> Ratings { get; private set; }
        public virtual MindMap? MindMap { get; private set; } // Chat pode ter 0 ou 1 MindMap

        protected Chat() { } // Para EF Core

        public Chat(Guid userId, Guid agentId, string title, DateTime? expiresAt = null)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("UserId é obrigatório.", nameof(userId));

            if (agentId == Guid.Empty)
                throw new ArgumentException("AgentId é obrigatório.", nameof(agentId));

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Título não pode ser nulo ou vazio.", nameof(title));

            Id = Guid.NewGuid();
            UserId = userId;
            AgentId = agentId;
            Title = title;
            ExpiresAt = expiresAt;
            CreatedAt = DateTime.UtcNow;
            IsArchived = false;
            IsPinned = false;
            TokensUsed = 0;
            MessageCount = 0;
            Messages = new List<Message>();
            Ratings = new List<ChatRating>();
        }

        // Métodos de modificação
        public void UpdateLastMessage(DateTime timestamp) => LastMessageAt = timestamp;
        public void Archive() => IsArchived = true;
        public void Unarchive() => IsArchived = false;
        public void Pin() => IsPinned = true;
        public void Unpin() => IsPinned = false;
        public void AddTokens(int count) => TokensUsed += count;
        public void IncrementMessageCount() => MessageCount++;
        public void ChangeTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Título não pode ser nulo ou vazio.", nameof(newTitle));
            Title = newTitle;
        }
    }
}