using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Test_Environment;

namespace Test_Environment 
{
    public class Player
    {
        public int Health { get; set; } = 100;
        public int BaseDamage { get; set; } = 7;
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public Inventory PlayerInventory { get; set; } = new Inventory();

        public int CalculateTotalDamage()
        {
            int totalDamage = BaseDamage;


            foreach (var skill in Skills)
            {
                totalDamage += skill.DamageBoost;
            }

            return totalDamage;
        }

        public void UseItem(string itemName)
        {
            var item = PlayerInventory.GetItem(itemName);
            if (item != null)
            {
                item.UseItem(this);
                PlayerInventory.RemoveItem(item.Name);
            }
            else
            {
                Console.WriteLine($"{itemName} is not in your inventory.");
            }
        }
    }

    public class Skill
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int DamageBoost { get; set; }

        public Skill(string name, string type, int damageBoost)
        {
            Name = name;
            Type = type;
            DamageBoost = damageBoost;
        }
    }

    public class SkillSystem
    {
        private static Dictionary<string, string> skillDictionary = new Dictionary<string, string>();

        public static void InitializeSkillSystem()
        {
            skillDictionary.Clear();
            skillDictionary.Add("fire skill", "Fire Nova");
            skillDictionary.Add("cold skill", "Blizzard");
            skillDictionary.Add("lightning skill", "Chain Lightning");
        }

        public static string GetSkillSystem(string skillType, string skillName)
        {
            if (skillDictionary.ContainsKey(skillType))
            {
                return skillDictionary[skillType];
           }
            return "Unknown Skill";
        }
    }

    public class LevelSystem
    {
        public int experience = 0;
        public int level = 1;
        public int experienceToNextLevel;

        public LevelSystem()
        {
            experienceToNextLevel = 100;
        }

        public void AddExperience(int amount, Player player)
        {
            experience += amount;
            while (experience >= experienceToNextLevel)
            {
                LevelUp();

                if (level == 2)
                {
                    player.Skills.Add(new Skill("Fire Nova", "Fire", 10));
                    DisplaySkills(player);
                }
                if (level == 3)
                {
                    player.Skills.Add(new Skill("Chain Lightning", "Lightning", 15));
                    DisplaySkills(player);
                }
                if (level == 4)
                {
                    player.Skills.Add(new Skill("Blizzard", "Cold", 20));
                    DisplaySkills(player);
                }
            }
        }

        public void LevelUp()
        {
            level++;
            experience -= experienceToNextLevel;
            experienceToNextLevel = (int)(experienceToNextLevel * 1.2);
            Console.WriteLine($"Level Up! You are now level {level}.");
        }
        public void DisplaySkills(Player player)
        {
            Console.WriteLine("\nYour current skills are:");
            foreach (var skill in player.Skills)
            {
                Console.WriteLine($"Skill: {skill.Name} | Type: {skill.Type} | Damage Boost: {skill.DamageBoost}");
            }
            Console.WriteLine();
        }
    }
}