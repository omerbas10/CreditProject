using System.Collections.Generic;
using CreditApp.Models;

namespace CreditApp.Services
{
    public class BankService
    {
        private readonly CacheService _cacheService;
        private readonly List<Bank> _banks;
        private readonly int _cacheDuration;

        public BankService(CacheService cacheService)
        {
            _cacheService = cacheService;
            _cacheDuration = 10;

            var cacheKey = "banks";
            _banks = _cacheService.Get<List<Bank>>(cacheKey);

            if (_banks == null) 
            {
                _banks = CreateBanks();
                _cacheService.Set(cacheKey, _banks, _cacheDuration);
            }
        }

        private List<Bank> CreateBanks() 
        {
            return new List<Bank>
            {
                new Bank { Code = 11, Name = "בנק דיסקונט", Description = "Discount" },
                new Bank { Code = 12, Name = "בנק הפועלים", Description = "Hapoalim" },
                new Bank { Code = 10, Name = "בנק לאומי", Description = "Leumi" },
                new Bank { Code = 18, Name = "בנק וואן זירו", Description = "Onezero" },
                new Bank { Code = 31, Name = "בנק הבינלאומי", Description = "Binleumi" },
                new Bank { Code = 4, Name = "בנק יהב", Description = "Yahav" },
                new Bank { Code = 52, Name = "בנק פאגי", Description = "Pagi" },
                new Bank { Code = 20, Name = "בנק מזרחי טפחות", Description = "Mizrahi" },
                new Bank { Code = 17, Name = "בנק מרכנתיל", Description = "Markantil" },
                new Bank { Code = 14, Name = "בנק אוצר החייל", Description = "Otzarhaial" },
                new Bank { Code = 46, Name = "בנק מסד", Description = "Massad" },


            };
        }
        public List<Bank> GetBanks()
        {
            return _banks;
        }
    }
}
