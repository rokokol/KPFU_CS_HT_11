using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BankTools
{
    public class AccountType
    {
        public static bool operator ==(AccountType first, AccountType second)
        {
            return first.Equals(second);
        }
        
        public static bool operator !=(AccountType first, AccountType second)
        {
            return !first.Equals(second);
        }
        
        #region variables

        private static readonly List<AccountType> accounts = new List<AccountType>();
        public static ulong Index { get; private set; }
        public decimal Balance { get; private set; }
        public ulong AccountNumber { get; private set; }
        public BankAccountType Account { get; private set; }
        public string Host { get; private set; } 
        public readonly Queue<BankTransaction> trans = new Queue<BankTransaction>();
        
        #endregion

        [Conditional("DEBUG")]
        public void DumpToScreen()
        {
            Console.WriteLine($"{Balance}, {AccountNumber}");
        }
        
        public AccountType this[int index]
        {
            set => accounts[index] = value;

            get => accounts[index];
        }
        
        /// <exception cref="ArgumentException">Negative sum</exception>
        public void TransferMoney(AccountType from, decimal sum)
        {
            if (sum < 0)
            {
                throw new ArgumentException("Negative transfer sum");
            }

            if (from.Balance > sum)
            {
                from.Withdraw(sum);
                PutOn(sum);
            }
            else
            {
                Console.WriteLine($"{from.AccountNumber:0000 0000 0000 0000}: There is not enough money to withdraw {sum.ToString("C2")}");
            }

        }
        
        /// <summary>
        /// Gets the type of the account.
        /// </summary>
        /// <returns>The account type.</returns>
        public BankAccountType GetAccountType()
        {
            return Account;
        }

        /// <summary>
        /// Bank account types.
        /// </summary>
        public enum BankAccountType
        {
            Saving,
            Current
        }

        /// <summary>
        /// Withdraw the money fromaccount
        /// </summary>
        /// <param name="sum">The money</param>
        /// <exception cref="ArgumentException">Negative sum</exception>
        public void Withdraw(decimal sum)
        {
            if (sum < 0)
            {
                throw new ArgumentException("Negative sum to withdraw");
            }

            if (Balance > sum)
            {
                Balance -= sum;
                Dispose(new BankTransaction(sum));
                Console.WriteLine($"From {AccountNumber:0000 0000 0000 0000} withdrawed {sum} ₽");
            }
            else
            {
                Console.WriteLine($"{AccountNumber:0000 0000 0000 0000}: There is not enough money to withdraw {sum.ToString("C2")}");
            }
        }

        /// <summary>
        /// Puts on the money.
        /// </summary>
        /// <param name="sum">The money</param>
        /// <exception cref="ArgumentException">Negative sum</exception>
        public void PutOn(decimal sum)
        {
            if (sum < 0)
            {
                throw new ArgumentException("Negative sum to put on");
            }
            Balance += sum;
            Dispose(new BankTransaction(sum));
            Console.WriteLine($"{AccountNumber:0000 0000 0000 0000} was put on with {sum} ₽");
        }

        private void Dispose(BankTransaction transaction)
        {
            GC.SuppressFinalize(this);
            trans.Enqueue(transaction);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tymakov.AccountType"/> class.
        /// </summary>
        /// <param name="account">Type of the account</param>
        internal AccountType(BankAccountType account)
        {
            Balance = 0;
            AccountNumber = Index++;
            this.Account = account;
            accounts.Add(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tymakov.AccountType"/> class.
        /// </summary>
        /// <param name="sum">Sum.</param>
        internal AccountType(int sum)
        {
            PutOn(sum);
            AccountNumber = Index++;
            accounts.Add(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tymakov.AccountType"/> class.
        /// </summary>
        /// <param name="account">Type of the account</param>
        internal AccountType(BankAccountType account, int sum)
        {
            PutOn(sum);
            AccountNumber = Index++;
            this.Account = account;
            accounts.Add(this);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Tymakov.AccountType"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Tymakov.AccountType"/>.</returns>
        public override string ToString()
        {
            return $"Account №{AccountNumber:0000 0000 0000 0000}\n\tAccount type: {Account.ToString()}\n\tBalance: {Balance:C2}";
        }

        protected bool Equals(AccountType other)
        {
            return Balance == other.Balance && AccountNumber == other.AccountNumber && Account == other.Account && Equals(trans, other.trans);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AccountType)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Balance.GetHashCode();
                hashCode = (hashCode * 397) ^ AccountNumber.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)Account;
                hashCode = (hashCode * 397) ^ (trans != null ? trans.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}