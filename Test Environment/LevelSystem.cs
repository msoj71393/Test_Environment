using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Environment
{
    internal class LevelSystem
    {
        public int experience = 0;
        public int level = 1;
        public int experienceToNextLevel;

        public LevelSystem()
        {
            experienceToNextLevel = 100;
        }
        public void AddExperience(int amount)
        {
            experience += amount;
            while (experience >= experienceToNextLevel)
            {
                LevelUp();
            }
        }
        public void LevelUp()
        {
            level++;
            experience -= experienceToNextLevel;

            experienceToNextLevel = (int)(experienceToNextLevel * 1.2);
            Console.WriteLine($"Level Up! You are now level {level}.");
        }
        public void PrintStatus()
        {
            Console.WriteLine($"Level: {level}, Experience: {experience}/{experienceToNextLevel}");
        }

    }
}
