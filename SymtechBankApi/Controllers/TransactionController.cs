using SymtechBankApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace SymtechBankApi.Controllers
{
    public class TransactionController : ApiController
    {
        // Used Entity Framework instead of ADO.Net for quicker development, clean and maintainable code
        // Removed unnecessary methods by implementing EF
        // Id in this context is the primary key of Transaction, not Account 

        // Db Context
        private readonly SymtechBankDbContext db = new SymtechBankDbContext();

        #region HttpGet

        [HttpGet, Route("api/Accounts/{accountId}/Transactions")]
        public IHttpActionResult GetTransactions(Guid accountId)
        {
            try
            {
                var transactions = db.Transactions.Where(x => x.AccountId == accountId)
                                           .AsEnumerable().Select(x => new
                                           {
                                               Date = x.Date.ToString("yyyy-MM-dd")
                                               ,
                                               Amount = Decimal.Round(x.Amount, 1)
                                           })
                                           .ToList();

                return Ok(transactions);
            }
            catch (Exception ex)
            {
                //Note: log the detailed error to logger or similar is ideal.  However not implemented in this version
                return BadRequest("Exception occured in the Api: " + ex.Message);
            }
        }

        #endregion

        #region HttpPost

        [HttpPost, Route("api/Accounts/{accountId}/Transactions")]
        public IHttpActionResult AddTransaction(Guid accountId, Transaction transaction)
        {
            try
            {
                // To check whether the transaction has any validation error messages
                if (ModelState.IsValid)
                {
                    #region  Add Transaction
                    // To generate Guid. 
                    //Note: Transactions table contains data. Hence not ideal to recreate table and reconfigure the model [DatabaseGenerated(DatabaseGeneratedOption.Identity)].
                    var id = Guid.NewGuid();
                    transaction.Id = id;

                    // assign account Id to new transaction
                    transaction.AccountId = accountId;

                    // Note: In ideal scenario/system, date time stored with GMT and display the time based on the time zone of the api caller
                    transaction.Date = DateTime.Now;

                    db.Transactions.Add(transaction);

                    #endregion

                    #region Update Account Amount

                    Account account = db.Accounts.Find(accountId);
                    account.Amount += transaction.Amount; // recalculate an update the total Amount in account

                    #endregion

                    db.SaveChanges(); // save the changes to DB
                    return Ok("Transaction added successfully.");
                }
                else
                {
                    // to get the validation messages
                    var errors = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0);

                    StringBuilder errorMsg = new StringBuilder();

                    foreach (var item in errors)
                    {
                        errorMsg.Append(string.IsNullOrEmpty(item.First().ErrorMessage) ? item.First().Exception.ToString() : item.First().ErrorMessage);
                        errorMsg.Append(",");
                    }
                    return BadRequest("Transaction creation unsuccessful due to the following exception(s), " + errorMsg.ToString().TrimEnd(','));
                }
            }
            catch (Exception ex)
            {
                //Note: log the detailed error to logger or similar is ideal.  However not implemented in this version
                return BadRequest("Exception occured in the Api: " + ex.Message);
            }
        }

        #endregion

    }
}