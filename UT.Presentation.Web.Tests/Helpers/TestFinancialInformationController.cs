using System;
using System.Collections.Generic;
using System.Web;
using Moq;
using UT.Presentation.Web.Controllers;
using UT.Presentation.Web.Models.ControllerContext;
using UT.Presentation.Web.Tests.Controllers;
using UT.Domain.Entities;

namespace UT.Presentation.Web.Tests.Helpers
{
    public class TestFinancialInformationController : FinancialInformationController
    {
        private MockFinancialInformationControllerContext _context;

        protected TestFinancialInformationController(MockFinancialInformationControllerContext context)
            : base()
        {
            _context = context;
        }

        public static TestFinancialInformationController Create()
        {
            var context = new MockFinancialInformationControllerContext();
            InMemoryDependencyResolver
                .New()
                .AddService<FinancialInformationControllerContext>(context);

            var newTestController = new TestFinancialInformationController(context);
            return newTestController;
        }

        public void ExpectEmptyBankAccountList(int customerNumber)
        {
            ExpectBankAccountList(customerNumber, 0);
        }

        public void ExpectBankAccountList(int customerNumber, int count)
        {
            var list = new List<BankAccount>();
            var bankAccount = new BankAccount();
            for (int i = 0; i < count; i++)
            {
                list.Add(bankAccount);
            }

            _context.MockFinancialInstitutionsRepository
               .Setup(x => x.GetBankAccountList((It.Is<int>(y => y == customerNumber))))
               .Returns(list)
               .Verifiable();
        }

        public void ExpectToStoreInSession(string key, object value)
        {
            _context.MockSession
                .Setup(x => x.Add(key, value))
                .Verifiable();
        }

        public void ExpectGetFromSession(string key, object value)
        {
            _context.MockSession
                .Setup(x => x[key])
                .Returns(value)
                .Verifiable();
        }

        public void ExpectToGetSitecoreField(string fieldName, HtmlString returnValue)
        {
            _context.MockSitecoreContext.MockSitecoreHelper
                .Setup(x => x.Field(fieldName)).Returns(returnValue);
        }

        internal void ExpectExceptionFromGetBankAccountList(Exception ex)
        {
            _context.MockFinancialInstitutionsRepository
                .Setup(x => x.GetBankAccountList(It.IsAny<int>()))
                .Throws(ex);
        }
    }
}
