using System.Security.Cryptography.X509Certificates;

namespace AITeachers.Core.Domain.Entities
{
    public class UserQuota
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public int DailyChatsUsed { get; private set; }
        public int DailyChatsLimit { get; private set; }
        public int DailyMindMapsUsed { get; private set; }
        public int DailyMindMapsLimit { get; private set; }
        public decimal StorageUsedMB { get; private set; }
        public decimal StorageQuotaMB { get; private set; }
        public DateTime LastResetDate { get; private set; }
        public long MonthlyTokensUsed { get; private set; }

        public UserQuota(Guid userId, int dailyChatsUsed, int dailyChatsLimit, int dailyMindMapsUsed, int dailyMindMapsLimit, decimal storageUsedMB, decimal storageQuotaMB, DateTime lastResetDate, long monthlyTokensUsed)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            DailyChatsUsed = dailyChatsUsed;
            DailyChatsLimit = dailyChatsLimit;
            DailyMindMapsUsed = dailyMindMapsUsed;
            DailyMindMapsLimit = dailyMindMapsLimit;
            StorageUsedMB = storageUsedMB;
            StorageQuotaMB = storageQuotaMB;
            LastResetDate = lastResetDate;
            MonthlyTokensUsed = monthlyTokensUsed;

            if (dailyChatsUsed < 0)
            {
                throw new ArgumentException("A quantidade de chats iniciados no dia não pode ser um número negativo");
            }
            if (dailyMindMapsUsed < 0)
            {
                throw new ArgumentException("A quantidade de mapas mentais iniciados no dia não pode ser um número negativo");
            }
            if (dailyChatsLimit < 0)
            {
                throw new ArgumentException("O limite de chats diários não pode ser um número negativo");
            }
            if (dailyMindMapsLimit < 0)
            {
                throw new ArgumentException("O limite de mapas mentais diários não pode ser um número negativo");
            }
            if (storageUsedMB < 0)
            {
                throw new ArgumentException("O armazenamento não pode ser negativo");
            }
            if (storageQuotaMB < 0)
            {
                throw new ArgumentException("O armazenamento não pode ser negativo");
            }
            if (monthlyTokensUsed < 0)
            {
                throw new ArgumentException("Não é possivel utilizar um número negativo de tokens");
            }
        }
        protected UserQuota() {}
    }
}