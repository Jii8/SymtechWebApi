using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SymtechBankApi.Models
{
    public class Transaction
    {
        [Key] // primary key
        public Guid Id { get; set; }

        // Changed data type. Decimal is more precise for money/amount
        [Range(-9999999999999999.99, 9999999999999999.99)]
        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        // Reference to Accounts table
        public Guid AccountId { get; set; }


        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
    }
}