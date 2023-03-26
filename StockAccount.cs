using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialDataProcessing
{
    public class StockAccount
    {
        
        private List<CompanyShares> companySharesList; //list to hold company shares
        private string fileName; //file name to save account data

        public StockAccount(string fileName)
        {
            this.fileName = fileName;
            companySharesList = new List<CompanyShares>();
        }

        //returns the total value of all stocks in the account
        public double ValueOf()
        {
            double totalValue = 0;

            foreach (CompanyShares companyShares in companySharesList)
            {
                double companyValue = companyShares.NumberOfShares * GetStockPrice(companyShares.Symbol);
                totalValue += companyValue;
            }

            return totalValue;
        }

        //adds shares of stock to the account
        public void Buy(int amount, string symbol)
        {
            //check if the company shares already exist in the list
            CompanyShares companyShares = GetCompanyShares(symbol);

            if (companyShares != null)
            {
                //update the existing company shares
                companyShares.NumberOfShares += amount;
                companyShares.TransactionDateTime = DateTime.Now;
            }
            else
            {
                //create new company shares
                companyShares = new CompanyShares(symbol, amount, DateTime.Now);
                companySharesList.Add(companyShares);
            }

            Console.WriteLine("{0} shares of {1} bought successfully.", amount, symbol);
        }

        //subtracts shares of stock from the account
        public void Sell(int amount, string symbol)
        {
            //check if the company shares exist in the list
            CompanyShares companyShares = GetCompanyShares(symbol);

            if (companyShares == null)
            {
                Console.WriteLine("Error: {0} shares of {1} not found in the account.", amount, symbol);
            }
            else if (companyShares.NumberOfShares < amount)
            {
                Console.WriteLine("Error: Not enough {0} shares available to sell {1}.", symbol, amount);
            }
            else
            {
                //update the existing company shares
                companyShares.NumberOfShares -= amount;
                companyShares.TransactionDateTime = DateTime.Now;

                Console.WriteLine("{0} shares of {1} sold successfully.", amount, symbol);
            }
        }

        //saves account data to a file
        public void Save(string fileName)
        {
            //code to save account data to file
            Console.WriteLine("Account data saved to {0}.", fileName);
        }

        //prints a detailed report of all stocks and their values in the account
        public void PrintReport()
        {
            Console.WriteLine("Stock Report:");
            Console.WriteLine("Symbol\tNumber of Shares\tCurrent Price\tTotal Value");

            foreach (CompanyShares companyShares in companySharesList)
            {
                double companyValue = companyShares.NumberOfShares * GetStockPrice(companyShares.Symbol);
                Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}", companyShares.Symbol, companyShares.NumberOfShares,
                                  GetStockPrice(companyShares.Symbol), companyValue);
            }

            Console.WriteLine("Total value of account: {0}", ValueOf());
        }

        //helper method to get the current price of a stock using its symbol
        private double GetStockPrice(string symbol)
        {
            //code to fetch current price of stock from an external source using the symbol
            return 10; //dummy value for demonstration purposes
        }

        //helper method to get the CompanyShares object for a given stock symbol
        private CompanyShares GetCompanyShares(string symbol)
        {
            // Check if the CompanyShares object already exists for the given symbol
            foreach (CompanyShares shares in companySharesList)
            {
                if (shares.Symbol == symbol)
                {
                    return shares;
                }
            }

            // If the CompanyShares object doesn't exist, create a new one and add it to the list
            CompanyShares newShares = new CompanyShares(symbol);
            companySharesList.Add(newShares);
            return newShares;

        }
    }
}
