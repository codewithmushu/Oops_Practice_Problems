using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;

namespace InventoryManagementProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] jsonInventories = {
            "{\"Name\":\"Rice\",\"PricePerKg\":50,\"Weight\":20}",
            "{\"Name\":\"Wheat\",\"PricePerKg\":30,\"Weight\":15}",
            "{\"Name\":\"Sugar\",\"PricePerKg\":40,\"Weight\":10}"
        };

            InventoryManager inventoryManager = new InventoryManager();
            inventoryManager.ManageInventory(jsonInventories);




            string path = @"C:\Users\91997\source\repos\InventoryManagementProgram\inventories.json";
            string json = File.ReadAllText(path);
            JArray jArray = JArray.Parse(json);
            string[] strings = jArray.Select(j => j.ToString()).ToArray();

            

        }
    }
}
