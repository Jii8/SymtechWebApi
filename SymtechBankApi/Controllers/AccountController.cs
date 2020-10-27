using SymtechBankApi.Models;
using System;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace SymtechBankApi.Controllers
{
    public class AccountController : ApiController
    {
        // Used Entity Framework instead of ADO.Net for quicker development, clean and maintainable code
        // Removed unnecessary methods by implementing EF

        // Db Context
        private readonly SymtechBankDbContext db = new SymtechBankDbContext();

        #region HttpGet

        [HttpGet, Route("api/Accounts/{id}")]
        public IHttpActionResult GetAccountById(Guid id)
        {
            try
            {
                // Amount shows one decimal number after decimal point eventhough data has two. Hence cannot display directly binded to the model
                var account = db.Accounts.Where(x => x.Id == id).AsEnumerable().Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Number,
                    Amount = Decimal.Round(x.Amount, 1)
                });

                return Ok(account);
            }
            catch (Exception ex)
            {
                //Note: log the detailed error to logger or similar is ideal.  However not implemented in this version
                return BadRequest("Exception occured in the Api: " + ex.Message);
            }
        }

        [HttpGet, Route("api/Accounts")]
        public IHttpActionResult GetAllAccounts()
        {
            try
            {
                //return Ok(db.Accounts.ToList()); // Display the data as it is. Not in specific format as required

                var accounts = db.Accounts.AsEnumerable().Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Number,
                    Amount = Decimal.Round(x.Amount, 1)
                }).ToList();

                return Ok(accounts);
            }
            catch (Exception ex)
            {
                //Note: log the detailed error to logger or similar is ideal.  However not implemented in this version
                return BadRequest("Exception occured in the Api: " + ex.Message);
            }
        }

        #endregion

        #region HttpPost

        [HttpPost, Route("api/Accounts")]
        public IHttpActionResult AddAccount(Account account)
        {
            /* Note: Model validation with specific error message based on the validation is ideal. 
               However not implemented in this version */

            try
            {
                if (ModelState.IsValid)
                {
                    // To generate Guid.                     
                    //Note: Accounts table contains data. Hence not ideal to recreate table and reconfigure the model [DatabaseGenerated(DatabaseGeneratedOption.Identity)].
                    var id = Guid.NewGuid();
                    account.Id = id;

                    db.Accounts.Add(account);
                    db.SaveChanges();
                    return Ok("Account added successfully.");
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
                    return BadRequest("Account creation unsuccessful due to the following exception(s), " + errorMsg.ToString().TrimEnd(','));
                }
            }
            catch (Exception ex)
            {
                //Note: log the detailed error to logger or similar is ideal.  However not implemented in this version
                return BadRequest("Exception occured in the Api: " + ex.Message);
            }

        }

        #endregion

        #region HttpPut

        [HttpPut, Route("api/Accounts/{id}")]
        public IHttpActionResult UpdateAccount(Guid id, Account account)
        {
            try
            {
                var acc = db.Accounts.Find(id);
                acc.Name = account.Name; // only updating the 'Name'
                db.Entry(acc).Property(x => x.Name).IsModified = true;
                db.SaveChanges();
                return Ok("Account updated successfully.");
            }
            catch (Exception ex)
            {
                //Note: log the detailed error to logger or similar is ideal.  However not implemented in this version
                return BadRequest("Exception occured in the Api: " + ex.Message);
            }
        }

        #endregion

        #region HttpDelete

        [HttpDelete, Route("api/Accounts/{id}")]
        public IHttpActionResult DeleteAccount(Guid id)
        {
            try
            {
                db.Accounts.Remove(db.Accounts.Find(id));
                db.SaveChanges();
                return Ok("Account deleted successfully.");
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