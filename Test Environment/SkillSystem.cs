using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Environment
{
    internal class SkillSystem
    {
        public static Dictionary<string, List<string>> skillSystem = new Dictionary<string, List<string>>();

        public static void InitializeSkillSystem()
        {
            skillSystem["cold skill"] = new List<string> { "Blizzard", "Ice Nova" };
            skillSystem["fire skill"] = new List<string> { "Fire Nova", "Meteor" };
            skillSystem["lightning skill"] = new List<string> { "Lightning Nova", "Chain Lightning" };
            skillSystem["regular skill"] = new List<string> { "Leap Attack", "Frenzy" };
        }

        public static string GetSkillSystem(string category, string skillName)
        {
            if (string.IsNullOrEmpty(category) || !skillSystem.ContainsKey(category))
            {
                return "Category not found!";
            }

            var items = skillSystem[category];
            if (string.IsNullOrEmpty(skillName) || !items.Contains(skillName))
            {
                return $"Skill '{skillName}' not found in category '{category}'!";
            }

            return $"{category}: {skillName}";
        }
    }
}