using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AtmContext;

namespace WithdrwaMoney
{
    public class Withdrawal
    {
        static void Main(string[] args)
        {
            
            var context = new ATMEntities();
            Console.WriteLine("Transaction started");
            Console.WriteLine("Enter CardNumber: ");
            var cardNumber = Console.ReadLine();
            Console.WriteLine("Enter PIN: ");
            var pinNumber = Console.ReadLine();

            var account = context.CardAccounts
                .Where(c =>
                    c.CardNumber == cardNumber &&
                    c.CardPin == pinNumber)
                .Take(1);
            var userAccount = account.ToList();
            if (!userAccount.Any())
            {
                throw new ArgumentException("Invalid card number or pin!");
            }

            var accountMoney = userAccount.First().CardCash;
            Console.WriteLine("Available: {0:F2}", accountMoney);
            Console.WriteLine("You want to withdraw: ");
            var moneyToWithdraw = decimal.Parse(Console.ReadLine());

            if (moneyToWithdraw > accountMoney)
            {
                throw new ArgumentException("Not enough money!");
            }

            var moneyLeft = accountMoney - moneyToWithdraw;
            account.First().CardCash = moneyLeft;

            Console.WriteLine("After the transaction the money in your account is: {0:F2}$", moneyLeft);

        }
    }
}
