using System.Collections.Generic;
using UT.Domain.Entities;
using UT.Domain.Interfaces;

namespace UT.Domain.Repositories.Fake
{
    class FinantialInstitutionsRepositoryFake : IFinancialInstitutionsRepository
    {
        public IEnumerable<BankAccount> GetBankAccountList(int customerNumber)
        {
            var list = new List<BankAccount>
            {
                new BankAccount()
                {
                    AccountId = "0001",
                    AccountNickname = "Home",
                    AccountNumber= "7426549Z",
                    FinancialInstitution = "New Bank of America",
                    IsAutoPayEnrolled = true,
                    IsEditable = false
                },
                new BankAccount()
                {
                    AccountId = "0002",
                    AccountNickname = "Business 1",
                    AccountNumber= "9060413A",
                    FinancialInstitution = "Bank of Chicago",
                    IsAutoPayEnrolled = false,
                    IsEditable = true
                },
                new BankAccount()
                {
                    AccountId = "0003",
                    AccountNickname = "Business 2",
                    AccountNumber= "0471327B",
                    FinancialInstitution = "ICBC",
                    IsAutoPayEnrolled = false,
                    IsEditable = false
                },
                new BankAccount()
                {
                    AccountId = "0004",
                    AccountNickname = "Business 3",
                    AccountNumber= "8274610A",
                    FinancialInstitution = "ICBC",
                    IsAutoPayEnrolled = true,
                    IsEditable = true
                }
            };

            return list;
        }

    }
}

