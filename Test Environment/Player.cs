using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Environment
{
    class Player
    {
        public int Health = 100;
        public int Damage = 7;

        public static void NewSkill(SkillSystem skillSystem, LevelSystem levelSystem)
        {
            SkillSystem.InitializeSkillSystem();
        }
    }

    class LevelSystem
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

                if (level == 2)
                {
                    SkillSystem skillSystem = new SkillSystem();
                    Player.NewSkill(skillSystem, this);

                    string FireNova = SkillSystem.GetSkillSystem("fire skill", "Fire Nova");
                    Console.WriteLine($"Your new skill is {FireNova}");
                }
                if (level == 3)
                {
                    SkillSystem skillSystem = new SkillSystem();
                    Player.NewSkill(skillSystem, this);

                    string Blizzard = SkillSystem.GetSkillSystem("cold skill", "Blizzard");
                    Console.WriteLine($"Your new skill is {Blizzard}");
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
        public void PrintStatus()
        {
            Console.WriteLine($"Level: {level}, Experience: {experience}/{experienceToNextLevel}");
        }

    }
}
