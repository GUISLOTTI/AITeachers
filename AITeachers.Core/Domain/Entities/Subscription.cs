using AITeachers.Core.Domain.Enums;

namespace AITeachers.Core.Domain.Entities

{
    public class Subscription
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Type Type { get; private set; }
        public Status Status { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public string? PaymentMethod { get; private set; }
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }
        public bool AutoRenew { get; private set; }

        public Subscription(Guid userId, Type type, Status status, DateTime startDate, DateTime? endDate, string? paymentMethod, decimal amount, string currency = "BRL", bool autoRenew = true)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Type = type;
            Status = status;
            StartDate = startDate;
            EndDate = endDate;
            PaymentMethod = paymentMethod;
            Amount = amount;
            Currency = currency;
            AutoRenew = autoRenew;

            if (endDate.HasValue && endDate < startDate)
            {
                throw new ArgumentException("Data de fim não pode ser menor que a data de ínicio");
            }
            if (amount < 0)
            {
                throw new ArgumentException("A quantidade não pode ser negativa.");
            }
            
        }
        protected Subscription() { }
    }
}
