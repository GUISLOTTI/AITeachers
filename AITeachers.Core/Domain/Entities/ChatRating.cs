using System;

namespace AITeachers.Core.Domain.Entities
{
    public class ChatRating
    {
        public Guid Id { get; private set; }
        public Guid ChatId { get; private set; }
        public Guid UserId { get; private set; }
        public int Rating { get; private set; } // 1-5
        public string? Feedback { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // Navegação
        public virtual Chat Chat { get; private set; }

        protected ChatRating() { } // Para EF Core

        public ChatRating(Guid chatId, Guid userId, int rating, string? feedback = null)
        {
            if (chatId == Guid.Empty)
                throw new ArgumentException("ChatId é obrigatório.", nameof(chatId));

            if (userId == Guid.Empty)
                throw new ArgumentException("UserId é obrigatório.", nameof(userId));

            if (rating < 1 || rating > 5)
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating deve estar entre 1 e 5.");

            Id = Guid.NewGuid();
            ChatId = chatId;
            UserId = userId;
            Rating = rating;
            Feedback = feedback;
            CreatedAt = DateTime.UtcNow;
        }
    }
}