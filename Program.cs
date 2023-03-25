using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace JsonInventoryDataManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the JSON file
            //string json = File.ReadAllText("inventory.json");
            string path = @"C:\Users\91997\source\repos\JSONInventoryManagement\Inventory.json";
            string json = File.ReadAllText(path);


            // Parse the JSON data
            JObject inventoryData = JObject.Parse(json);

            // Calculate the value of the inventory
            double riceValue = CalculateInventoryValue(inventoryData["rice"]);
            double pulsesValue = CalculateInventoryValue(inventoryData["pulses"]);
            double wheatsValue = CalculateInventoryValue(inventoryData["wheats"]);
            double totalValue = riceValue + pulsesValue + wheatsValue;

            // Create the JSON output
            JObject output = new JObject();
            output["rice"] = new JObject();
            output["rice"]["value"] = riceValue;
            output["pulses"] = new JObject();
            output["pulses"]["value"] = pulsesValue;
            output["wheats"] = new JObject();
            output["wheats"]["value"] = wheatsValue;
            output["totalValue"] = totalValue;

            // Output the JSON string
            Console.WriteLine(output.ToString());
        }

        static double CalculateInventoryValue(JToken inventory)
        {
            double value = 0;

            foreach (var item in inventory)
            {
                double weight = (double)item["weight"];
                double pricePerKg = (double)item["price_per_kg"];
                value += weight * pricePerKg;
            }

            return value;
        }
    }
}

