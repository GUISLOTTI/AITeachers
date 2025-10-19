using System;
using System.Collections.Generic;
using AITeachers.Core.Domain.Enums;

namespace AITeachers.Core.Domain.Entities
{
    public class Topic
    {
        public Guid Id { get; private set; }
        public Guid SubjectId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public DifficultyLevel DifficultyLevel { get; private set; }
        public int EstimatedHours { get; private set; }
        public int Order { get; private set; }
        public string? Tags { get; private set; } // JSON array
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // Navegação
        public virtual Subject Subject { get; private set; }
        public virtual ICollection<Agent> Agents { get; private set; }

        protected Topic() { } // Para EF Core

        public Topic(Guid subjectId, string name, DifficultyLevel difficultyLevel, int order, string? description = null, int estimatedHours = 0, string? tags = null)
        {
            if (subjectId == Guid.Empty)
                throw new ArgumentException("SubjectId é obrigatório.", nameof(subjectId));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome não pode ser nulo ou vazio.", nameof(name));

            Id = Guid.NewGuid();
            SubjectId = subjectId;
            Name = name;
            DifficultyLevel = difficultyLevel;
            Order = order;
            Description = description;
            EstimatedHours = estimatedHours;
            Tags = tags;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            Agents = new List<Agent>();
        }

        public void Deactivate() => IsActive = false;
    }
}