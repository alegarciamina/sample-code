using System.Collections.Generic;
using UT.Domain.Entities;

namespace UT.Domain.Interfaces
{
    public interface IFinancialInstitutionsRepository
    {
        IEnumerable<BankAccount> GetBankAccountList(int customerNumber);
    }
}
