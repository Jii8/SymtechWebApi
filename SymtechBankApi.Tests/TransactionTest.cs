using System;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SymtechBankApi.Controllers;
using SymtechBankApi.Models;

namespace SymtechBankApi.Tests
{
    [TestClass]
    public class TransactionTest
    {
        #region HttpGet
        // Action returns 200 (OK) with response body

        [TestMethod]
        public void GetTransactionById()
        {
            // Arrange  

            // Act 

            // Assert

        }


        // Action returns 404 (Not Found)
        [TestMethod]
        public void GetTransactionNotFound()
        {
            // Arrange  

            // Act 

            // Assert
        }

        #endregion

        #region HttpPost

        // HttpPost controllers test methods

        #endregion
    }
}
