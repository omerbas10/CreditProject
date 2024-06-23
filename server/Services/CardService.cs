using System;
using System.Collections.Generic;
using System.Linq;
using CreditApp.Models;

namespace CreditApp.Services
{
    public class CardService
    {
        private readonly CacheService _cacheService;
        private readonly List<Card> _cards;
        private readonly int _cacheDuration;

        public CardService(CacheService cacheService)
        {
            _cacheService = cacheService;
            _cacheDuration = 15;

            var cacheKey = "cards";
            _cards = _cacheService.Get<List<Card>>(cacheKey);

            if (_cards == null) 
            {
                _cards = CreateCards();
                _cacheService.Set(cacheKey, _cards, _cacheDuration);
            }
        }

        private List<Card> CreateCards()
        {
            return new List<Card>
            {
                new Card { CardNumber = "5326987654321098", IssueDate = DateTime.Now.AddMonths(-4).Date, Image = "/images/1.png", IsBlocked = false, IsDigital = true, CreditLimit = 5000, BankCode = 11 },
                new Card { CardNumber = "5326152923466219", IssueDate = DateTime.Now.AddMonths(-8).Date, Image = "/images/2.png", IsBlocked = true, IsDigital = false, CreditLimit = 10000, BankCode = 12 },
                new Card { CardNumber = "4580432518826543", IssueDate = DateTime.Now.AddMonths(-7).Date, Image = "/images/3.png", IsBlocked = false, IsDigital = true, CreditLimit = 7000, BankCode = 10 },
                new Card { CardNumber = "5326123456784321", IssueDate = DateTime.Now.AddMonths(-1).Date, Image = "/images/4.png", IsBlocked = true, IsDigital = false, CreditLimit = 90000, BankCode = 4 },
                new Card { CardNumber = "4580987654321234", IssueDate = DateTime.Now.AddMonths(-9).Date, Image = "/images/5.png", IsBlocked = true, IsDigital = true, CreditLimit = 11000, BankCode = 20 },
                new Card { CardNumber = "5326345678901234", IssueDate = DateTime.Now.AddMonths(-8).Date, Image = "/images/6.png", IsBlocked = false, IsDigital = false, CreditLimit = 23000, BankCode = 31 },
                new Card { CardNumber = "4580765432198765", IssueDate = DateTime.Now.AddMonths(-5).Date, Image = "/images/7.png", IsBlocked = true, IsDigital = false, CreditLimit = 6000, BankCode = 18 },
                new Card { CardNumber = "5326876543210987", IssueDate = DateTime.Now.AddMonths(-1).Date, Image = "/images/8.png", IsBlocked = false, IsDigital = false, CreditLimit = 40000, BankCode = 52 },
                new Card { CardNumber = "4580654321987654", IssueDate = DateTime.Now.AddMonths(-10).Date, Image = "/images/9.png", IsBlocked = true, IsDigital = false, CreditLimit = 5000, BankCode = 20 },
                new Card { CardNumber = "5326234567890123", IssueDate = DateTime.Now.AddMonths(-11).Date, Image = "/images/10.png", IsBlocked = false, IsDigital = true, CreditLimit = 2000, BankCode = 11 },
                new Card { CardNumber = "4580543210987654", IssueDate = DateTime.Now.AddMonths(-20).Date, Image = "/images/11.png", IsBlocked = true, IsDigital = true, CreditLimit = 1000, BankCode = 17 },
                new Card { CardNumber = "5326123456789012", IssueDate = DateTime.Now.AddMonths(-5).Date, Image = "/images/12.png", IsBlocked = false, IsDigital = false, CreditLimit = 4000, BankCode = 20 },
                new Card { CardNumber = "4580912107876573", IssueDate = DateTime.Now.AddMonths(-2).Date, Image = "/images/13.png", IsBlocked = true, IsDigital = false, CreditLimit = 10000, BankCode = 18 },
                new Card { CardNumber = "4580436106627543", IssueDate = DateTime.Now.AddMonths(-2).Date, Image = "/images/1.png", IsBlocked = true, IsDigital = false, CreditLimit = 10000, BankCode = 18 },
                new Card { CardNumber = "5326543210987654", IssueDate = DateTime.Now.AddMonths(-5).Date, Image = "/images/2.png", IsBlocked = false, IsDigital = true, CreditLimit = 15000, BankCode = 11 },
                new Card { CardNumber = "4580123456789012", IssueDate = DateTime.Now.AddMonths(-8).Date, Image = "/images/3.png", IsBlocked = false, IsDigital = false, CreditLimit = 7000, BankCode = 12 },
                new Card { CardNumber = "5326987654321098", IssueDate = DateTime.Now.AddMonths(-10).Date, Image = "/images/4.png", IsBlocked = true, IsDigital = true, CreditLimit = 12000, BankCode = 10 },
                new Card { CardNumber = "4580765432109876", IssueDate = DateTime.Now.AddMonths(-1).Date, Image = "/images/5.png", IsBlocked = false, IsDigital = false, CreditLimit = 9000, BankCode = 31 },
                new Card { CardNumber = "5326345678901234", IssueDate = DateTime.Now.AddMonths(-6).Date, Image = "/images/6.png", IsBlocked = true, IsDigital = true, CreditLimit = 14000, BankCode = 4 },
                new Card { CardNumber = "4580432198765432", IssueDate = DateTime.Now.AddMonths(-3).Date, Image = "/images/7.png", IsBlocked = false, IsDigital = false, CreditLimit = 11000, BankCode = 52 },
                new Card { CardNumber = "5326123456789012", IssueDate = DateTime.Now.AddMonths(-9).Date, Image = "/images/8.png", IsBlocked = true, IsDigital = true, CreditLimit = 6000, BankCode = 20 },
                new Card { CardNumber = "4580765432198765", IssueDate = DateTime.Now.AddMonths(-12).Date, Image = "/images/9.png", IsBlocked = false, IsDigital = false, CreditLimit = 13000, BankCode = 17 },
                new Card { CardNumber = "5326987612345678", IssueDate = DateTime.Now.AddMonths(-15).Date, Image = "/images/10.png", IsBlocked = true, IsDigital = true, CreditLimit = 8000, BankCode = 14 },
                new Card { CardNumber = "4580123456798765", IssueDate = DateTime.Now.AddMonths(-4).Date, Image = "/images/11.png", IsBlocked = false, IsDigital = false, CreditLimit = 9000, BankCode = 46 },
                new Card { CardNumber = "5326123456789876", IssueDate = DateTime.Now.AddMonths(-7).Date, Image = "/images/12.png", IsBlocked = true, IsDigital = true, CreditLimit = 15000, BankCode = 11 },
                new Card { CardNumber = "4580345678901234", IssueDate = DateTime.Now.AddMonths(-2).Date, Image = "/images/13.png", IsBlocked = false, IsDigital = false, CreditLimit = 10000, BankCode = 12 },
                new Card { CardNumber = "5326876543210987", IssueDate = DateTime.Now.AddMonths(-5).Date, Image = "/images/1.png", IsBlocked = true, IsDigital = true, CreditLimit = 12000, BankCode = 10 },
                new Card { CardNumber = "4580654321098765", IssueDate = DateTime.Now.AddMonths(-8).Date, Image = "/images/2.png", IsBlocked = false, IsDigital = false, CreditLimit = 7000, BankCode = 18 },
                new Card { CardNumber = "5326432109876543", IssueDate = DateTime.Now.AddMonths(-11).Date, Image = "/images/3.png", IsBlocked = true, IsDigital = true, CreditLimit = 14000, BankCode = 31 },
                new Card { CardNumber = "4580765432123456", IssueDate = DateTime.Now.AddMonths(-1).Date, Image = "/images/4.png", IsBlocked = false, IsDigital = false, CreditLimit = 6000, BankCode = 4 },
                new Card { CardNumber = "5326654321098765", IssueDate = DateTime.Now.AddMonths(-6).Date, Image = "/images/5.png", IsBlocked = true, IsDigital = true, CreditLimit = 13000, BankCode = 52 },
                new Card { CardNumber = "4580876543210987", IssueDate = DateTime.Now.AddMonths(-3).Date, Image = "/images/6.png", IsBlocked = false, IsDigital = false, CreditLimit = 11000, BankCode = 20 },
                new Card { CardNumber = "5326345678912345", IssueDate = DateTime.Now.AddMonths(-10).Date, Image = "/images/7.png", IsBlocked = true, IsDigital = true, CreditLimit = 8000, BankCode = 17 }
            };
        }

        public List<Card> GetCards(bool? isBlocked = null, string cardNumber = null, int? bankCode = null)
        {
            var query = _cards.AsQueryable();

            if (isBlocked.HasValue){
                query = query.Where(c => c.IsBlocked == isBlocked.Value);
            }

            if (!string.IsNullOrEmpty(cardNumber)){
                query = query.Where(c => c.CardNumber == cardNumber);
            }

            if (bankCode.HasValue){
                query = query.Where(c => c.BankCode == bankCode.Value);
            }

            return query.ToList();
        }

public bool IncreaseCreditLimit(string cardNumber, decimal requestedLimit, string occupation, decimal monthlyIncome)
{
    var card = _cards.FirstOrDefault(c => c.CardNumber == cardNumber);

    if (card == null)
    {
        Console.WriteLine("כרטיס לא נמצא.");
        return false;
    }

    if (card.IssueDate > DateTime.Now.AddMonths(-3))
    {
        Console.WriteLine("כרטיס הונפק לפני פחות מ 3 חודשים.");
        return false;
    }
    if (monthlyIncome < 12000)
    {
        Console.WriteLine("הכנסה קטנה מ 12 אלף.");
        return false;
    }

    if (requestedLimit > 100000)
    {
        Console.WriteLine("מסגרת מקסימלית לכרטיס היא עד 100 אלף.");
        return false;
    }

    decimal maxLimit = occupation switch
    {
        "שכיר" => monthlyIncome / 2,
        "עצמאי" => monthlyIncome / 3,
        _ => 0
    };

    if (requestedLimit > maxLimit)
    {
        Console.WriteLine($"המסגרת המבוקשת לא תואמת להכנסה עבור {occupation}");
        return false;
    }

    card.CreditLimit = requestedLimit;
    Console.WriteLine($"מסגרת כרטיס מספר {cardNumber} עודכנה ל {requestedLimit}");
    
    var updatedCard = _cards.FirstOrDefault(c => c.CardNumber == cardNumber);
    Console.WriteLine($"מסגרת כרטיס מעודכנת: {updatedCard.CreditLimit}");

    return true;
}

    }
}
