using System;

namespace AITeachers.Core.Domain.Entities
{
    public class ResponseCache
    {
        public Guid Id { get; private set; }
        public Guid TopicId { get; private set; }
        public string QuestionHash { get; private set; }
        public string Question { get; private set; }
        public string Answer { get; private set; }
        public int UsageCount { get; private set; }
        public DateTime LastUsedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsApproved { get; private set; }

        // Navegação
        public virtual Topic Topic { get; private set; }

        protected ResponseCache() { } // Para EF Core

        public ResponseCache(Guid topicId, string questionHash, string question, string answer)
        {
            if (topicId == Guid.Empty)
                throw new ArgumentException("TopicId é obrigatório.", nameof(topicId));

            if (string.IsNullOrWhiteSpace(questionHash))
                throw new ArgumentException("QuestionHash não pode ser nulo ou vazio.", nameof(questionHash));

            if (string.IsNullOrWhiteSpace(question))
                throw new ArgumentException("Question não pode ser nula ou vazia.", nameof(question));

            if (string.IsNullOrWhiteSpace(answer))
                throw new ArgumentException("Answer não pode ser nula ou vazia.", nameof(answer));

            Id = Guid.NewGuid();
            TopicId = topicId;
            QuestionHash = questionHash;
            Question = question;
            Answer = answer;
            UsageCount = 1;
            LastUsedAt = DateTime.UtcNow;
            CreatedAt = DateTime.UtcNow;
            IsApproved = false; // Requisição de aprovação manual
        }

        // Métodos de modificação
        public void IncrementUsage()
        {
            UsageCount++;
            LastUsedAt = DateTime.UtcNow;
        }

        public void Approve() => IsApproved = true;
        public void Disapprove() => IsApproved = false;
    }
}