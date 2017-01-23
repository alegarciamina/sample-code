using System;
using System.Collections.Generic;
using UT.Domain.Entities;
using UT.Domain.Interfaces;

namespace UT.Domain.Repositories
{
    class FinancialInstitutionsRepository : IFinancialInstitutionsRepository
    {
        public IEnumerable<BankAccount> GetBankAccountList(int customerNumber)
        {
            throw new NotImplementedException();
        }
    }
}
