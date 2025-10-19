using System;

namespace AITeachers.Core.Domain.Entities
{
    public class Agent
    {
        public Guid Id { get; private set; }
        public Guid TopicId { get; private set; }
        public string Name { get; private set; }
        public string? Avatar { get; private set; }
        public string Personality { get; private set; }
        public string SystemPrompt { get; private set; }
        public string? WelcomeMessage { get; private set; }
        public string? ExampleQuestions { get; private set; } // JSON array
        public decimal Temperature { get; private set; }
        public int MaxTokens { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // Navegação
        public virtual Topic Topic { get; private set; }

        protected Agent() { } // Para EF Core

        public Agent(Guid topicId, string name, string systemPrompt, string personality, string? welcomeMessage = null, string? avatar = null, string? exampleQuestions = null, decimal temperature = 0.7m, int maxTokens = 2000)
        {
            if (topicId == Guid.Empty)
                throw new ArgumentException("TopicId é obrigatório.", nameof(topicId));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome não pode ser nulo ou vazio.", nameof(name));

            if (string.IsNullOrWhiteSpace(systemPrompt))
                throw new ArgumentException("SystemPrompt não pode ser nulo ou vazio.", nameof(systemPrompt));

            if (systemPrompt.Length > 2000)
                throw new ArgumentException("SystemPrompt não pode exceder 2000 caracteres.", nameof(systemPrompt));

            Id = Guid.NewGuid();
            TopicId = topicId;
            Name = name;
            SystemPrompt = systemPrompt;
            Personality = personality ?? "Friendly";
            WelcomeMessage = welcomeMessage;
            Avatar = avatar;
            ExampleQuestions = exampleQuestions;
            Temperature = temperature;
            MaxTokens = maxTokens;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public void Deactivate() => IsActive = false;
    }
}