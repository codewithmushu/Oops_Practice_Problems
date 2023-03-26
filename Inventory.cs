using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementProgram
{
     class Inventory
    {
        public string Name { get; set; }
        public int PricePerKg { get; set; }
        public int Weight { get; set; }

        public Inventory(string name, int pricePerKg, int weight)
        {
            this.Name = name;
            this.PricePerKg = pricePerKg;
            this.Weight = weight;
        }

        public int CalculateValue()
        {
            return this.PricePerKg * this.Weight;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


    class InventoryFactory
    {
        public static Inventory CreateFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Inventory>(json);
        }
    }

    class InventoryManager
    {
        public void ManageInventory(string[] jsonInventories)
        {
            foreach (string jsonInventory in jsonInventories)
            {
                Inventory inventory = InventoryFactory.CreateFromJson(jsonInventory);
                int value = inventory.CalculateValue();
                string json = inventory.ToJson();
                Console.WriteLine("Inventory Value: " + value);
                Console.WriteLine("Inventory JSON: " + json);
            }
        }
    }
}
