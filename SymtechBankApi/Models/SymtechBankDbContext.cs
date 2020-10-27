using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SymtechBankApi.Models
{
    public class SymtechBankDbContext : DbContext
    {
        public SymtechBankDbContext() : base("SymtechBankDbConnection")
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}