using System;

namespace BankTools
{
    /// <summary>
    /// Bank transaction class.
    /// </summary>
    public class BankTransaction
    {
        /// <summary>
        /// Transaction's time
        /// </summary>
        public DateTime Time { get; private set; }
        public decimal Sum { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tymakov.BankTransaction"/> class.
        /// </summary>
        /// <param name="sum">Sum.</param>
        public BankTransaction(decimal sum)
        {
            this.Sum = sum;
            Time = DateTime.Now;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Tymakov.BankTransaction"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Tymakov.BankTransaction"/>.</returns>
        public override string ToString()
        {
            return $"A transaction with {Sum:C2}";
        }
    }
}