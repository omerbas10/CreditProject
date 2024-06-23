using System;

namespace CreditApp.Models
{
    public class Card
    {
        public string CardNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public string Image { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsDigital { get; set; }
        public decimal CreditLimit { get; set; }
        public int BankCode { get; set; }
    }
}
