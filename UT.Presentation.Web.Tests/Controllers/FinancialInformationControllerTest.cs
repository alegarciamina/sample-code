using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT.Presentation.Web.Constants;
using UT.Presentation.Web.Models.ViewModels;
using UT.Presentation.Web.Tests.Helpers;

namespace UT.Presentation.Web.Tests.Controllers
{
    [TestClass]
    public class FinancialInformationControllerTest
    {

        private TestFinancialInformationController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _controller = TestFinancialInformationController.Create();
        }

        [TestMethod]
        public void BankInstitutions_ServiceException()
        {
            // Arrange
            Exception ex = new Exception("Test");
            _controller.ExpectGetFromSession(SessionKeys.CustomerNumber, "123");
            _controller.ExpectExceptionFromGetBankAccountList(ex);

            // Act
            ViewResult view = (ViewResult)_controller.Index();

            // Assert [Debug path]
            Assert.AreEqual(view.ViewBag.Error,"Test");
        }

        [TestMethod]
        public void BankInstitutions_NoResults()
        {
            _controller.ExpectGetFromSession(SessionKeys.CustomerNumber, "123456");
            _controller.ExpectEmptyBankAccountList(123456);

            ViewResult view = (ViewResult)_controller.Index();
            var model = (BankInstitutionsViewModel)view.Model;
            Assert.AreEqual(model.BankInstitutions.Count, 0);

        }

        [TestMethod]
        public void BankInstitutions_ExistingList()
        {
            _controller.ExpectGetFromSession(SessionKeys.CustomerNumber, "123456");
            _controller.ExpectBankAccountList(123456, 4);

            ViewResult view = (ViewResult)_controller.Index();
            var model = (BankInstitutionsViewModel)view.Model;
            Assert.AreEqual(model.BankInstitutions.Count, 4);
        }
    }
}
