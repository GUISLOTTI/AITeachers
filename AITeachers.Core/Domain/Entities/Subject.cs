using System;
using System.Collections.Generic;

namespace AITeachers.Core.Domain.Entities
{
    public class Subject
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public string? IconUrl { get; private set; }
        public string ColorHex { get; private set; }
        public int Order { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // Navegação
        public virtual ICollection<Topic> Topics { get; private set; }

        protected Subject() { } // Para EF Core

        public Subject(string name, string colorHex, int order, string? description = null, string? iconUrl = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome não pode ser nulo ou vazio.", nameof(name));

            if (string.IsNullOrWhiteSpace(colorHex))
                throw new ArgumentException("Cor não pode ser nula ou vazia.", nameof(colorHex));

            Id = Guid.NewGuid();
            Name = name;
            ColorHex = colorHex;
            Order = order;
            Description = description;
            IconUrl = iconUrl;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            Topics = new List<Topic>();
        }

        // Métodos para modificar o estado (exemplo)
        public void Deactivate() => IsActive = false;
        public void UpdateDetails(string name, string colorHex, int order, string? description, string? iconUrl)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome não pode ser nulo ou vazio.", nameof(name));

            if (string.IsNullOrWhiteSpace(colorHex))
                throw new ArgumentException("Cor não pode ser nula ou vazia.", nameof(colorHex));

            Name = name;
            ColorHex = colorHex;
            Order = order;
            Description = description;
            IconUrl = iconUrl;
        }
    }
}