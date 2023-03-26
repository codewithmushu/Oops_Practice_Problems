using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAccountManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            StockPortfolio portfolio = new StockPortfolio();
            Console.Write("Enter the number of stocks: ");
            int numStocks = int.Parse(Console.ReadLine());

            for (int i = 0; i < numStocks; i++)
            {
                Console.Write($"Enter the name of stock #{i+1}: ");
                string name = Console.ReadLine();

                Console.Write($"Enter the number of shares for {name}: ");
                int numShares = int.Parse(Console.ReadLine());

                Console.Write($"Enter the share price for {name}: ");
                double sharePrice = double.Parse(Console.ReadLine());

                Stock stock = new Stock { Name = name, NumberOfShares = numShares, SharePrice = sharePrice };
                portfolio.Stocks.Add(stock);
            }

            portfolio.CalculateTotalValue();

            Console.WriteLine("\nStock Report\n");
        }

        class Stock
        {
            public string Name { get; set; }
            public int NumberOfShares { get; set; }
            public double SharePrice { get; set; }
            public double Value { get; set; }

            public void CalculateValue()
            {
                Value = NumberOfShares * SharePrice;
            }
        }


        class StockPortfolio
        {
            public List<Stock> Stocks { get; set; }
            public double TotalValue { get; set; }

            public StockPortfolio()
            {
                Stocks = new List<Stock>();
            }

            public void CalculateTotalValue()
            {
                TotalValue = 0;
                foreach (var stock in Stocks)
                {
                    stock.CalculateValue();
                    TotalValue += stock.Value;
                }
            }
        }

    }
}
