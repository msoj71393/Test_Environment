using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Test_Environment
{
    public class Item
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }

        public Item(string name, string type, int value)
        {
            Name = name;
            Type = type;
            Value = value;
        }

        public void UseItem(Player player)
        {
            if (Type == "HealthPotion")
            {
                player.Health += Value;
                Console.WriteLine($"{Name} used! Health increased by {Value}. Current Health: {player.Health}");
            }
            if (Type == "DamageBoost" || Type == "Scroll")
            {
                player.BaseDamage += Value;
                Console.WriteLine($"{Name} used! Base Damage increased by {Value}. Current Base Damage: {player.BaseDamage}");
            }
            else
            {
                Console.WriteLine($"Item {Name} cannot be used.");
            }
        }
    }

    public class Inventory
    {
        private Dictionary<string, Item> items;

        public Inventory()
        {
            items = new Dictionary<string, Item>();
        }

        public void AddItem(Item item)
        {
            if (items.ContainsKey(item.Name))
            {
                Console.WriteLine($"Item {item.Name} is already in the inventory.");
            }
            else
            {
                items.Add(item.Name, item);
                Console.WriteLine($"{item.Name} added to inventory.");
            }
        }

        public bool RemoveItem(string itemName)
        {
            if (items.ContainsKey(itemName))
            {
                items.Remove(itemName);
                Console.WriteLine($"{itemName} removed from inventory.");
                return true;
            }
            else
            {
                Console.WriteLine($"Item {itemName} not found in inventory.");
                return false;
            }
        }

        public void DisplayItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                Console.WriteLine("Your Inventory contains:");
                foreach (var item in items.Values)
                {
                    Console.WriteLine($"Item: {item.Name} | Type: {item.Type} | Value: {item.Value}");
                }
            }
        }

        public Item GetItem(string itemName)
        {
            Item item = null;

            if (items.TryGetValue(itemName, out item))
            {
                return item;
            }
            else
            {
                return null;
            }
        }
    }
}