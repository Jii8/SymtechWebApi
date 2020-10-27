using System;
using System.ComponentModel.DataAnnotations;

namespace SymtechBankApi.Models
{
    public class Account
    {
        [Key] // primary key
        public Guid Id { get; set; }

        // Assumption: Name is required to avoid empty accounts (not just with id)
        [Required]
        public string Name { get; set; }

        // Keeping as character this is an Account Number
        public string Number { get; set; }

        // Changed data type. Decimal is more precise for money/amount
        [Range(-9999999999999999.99, 9999999999999999.99)]
        //[DisplayFormat(DataFormatString = "{0:#,##0.##}")]
        public decimal Amount { get; set; }

    }
}