using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialDataProcessing
{
    internal class Program
    {
        static void Main()
        {
            // Create a new StockAccount instance
            StockAccount account = new StockAccount("account_data.txt");

            // Add 100 shares of MSFT stock to the account
            account.Buy(100, "MSFT");

            // Add 50 shares of AAPL stock to the account
            account.Buy(50, "AAPL");

            // Print the current value of the account
            double totalValue = account.ValueOf();
            Console.WriteLine("Total value of account: {0}", totalValue);

            // Print a detailed report of the account
            account.PrintReport();

            // Save the account to a file
            account.Save("account_data.txt");









        }
    }
}


