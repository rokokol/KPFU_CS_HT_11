using BankTools;
using System.Collections.Generic;

namespace BankTools
{
    public class AccountTypeFabric
    {
        private readonly Dictionary<ulong, AccountType> accounts = new Dictionary<ulong, AccountType>();

        public ulong CreateAccount(int sum)
        {
            return CreateAccount(0, sum);
        }

        public ulong CreateAccount(AccountType.BankAccountType type)
        {
            return CreateAccount(type, 0);
        }

        public ulong CreateAccount(AccountType.BankAccountType type, int sum)
        {
            AccountType accountType = new AccountType(type, sum);
            accounts.Add(accountType.AccountNumber, accountType);
            return accountType.AccountNumber;
        }

        public AccountType GetAccount(ulong index)
        {
            return accounts[index];
        }

        public void RemoveAccount(ulong index)
        {
            accounts.Remove(index);
        }
    }
}
