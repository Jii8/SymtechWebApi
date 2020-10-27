using System;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SymtechBankApi.Controllers;
using SymtechBankApi.Models;

namespace SymtechBankApi.Tests
{
    [TestClass]
    public class AccountTest
    {
        #region HttpGet
        // Action returns 200 (OK) with response body

        [TestMethod]
        public void GetAccountsById()
        {
            // Arrange  

            // Act 

            // Assert
        }


        // Action returns 404 (Not Found)
        [TestMethod]
        public void GetAccountsNotFound()
        {
            // Arrange  

            // Act 

            // Assert
        }

        #endregion

        #region HttpPost

        // HttpPost controllers test methods

        #endregion

        #region HttpPut

        // HttpPut controllers test methods


        #endregion

        #region HttpDelete
        // HttpPut controllers test methods
        //  Action returns 200 (OK) with no response body

        #endregion
    }
}
