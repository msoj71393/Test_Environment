using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Environment
{
    public class LootTable
    {

        public static Dictionary<string, List<string>> lootTable = new Dictionary<string, List<string>>();

        public static void InitializeLootTable()
        {
            lootTable["a weapon"] = new List<string> { "Sword", "Axe", "Bow", "Dagger", "Spear" };
            lootTable["armor piece"] = new List<string> { "Helmet", "Chestplate", "Boots", "Gloves" };
            lootTable["a potion"] = new List<string> { "Health Potion", "Mana Potion", "Stamina Potion" };
            lootTable["miscellaneous "] = new List<string> { "Gold", "Map", "Key" };
        }

        public static string GetRandomLoot()
        {
            Random rand = new Random();

            var categories = new List<string>(lootTable.Keys);
            if (categories.Count == 0)
            {
                return "No loot available!";
            }

            string randomCategory = categories[rand.Next(0, categories.Count)];

            if (lootTable[randomCategory].Count == 0)
            {
                return $"No items in category: {randomCategory}";
            }

            var items = lootTable[randomCategory];
            string randomItem = items[rand.Next(0, items.Count)];

            return $"{randomCategory}: {randomItem}";
        }
    }
}
