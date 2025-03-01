using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using static Test_Environment.Program;

namespace Test_Environment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Game();
            }

            Game();
        }

        public class Manager
        {
            public int Turn = 0;
            public Resource resource = new Resource();

            public Manager(int turn)
            {
                Turn = turn;
            }
        }

        static bool Game()
        {
            Manager manager = new Manager(0);

            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Gather wood");
            Console.WriteLine("2) Gather stone");

            do
            {
                Console.WriteLine("It's your turn");

                switch (Console.ReadLine())
                {
                    case "1":
                        gatherWood(manager);
                        break;
                    case "2":
                        gatherStone(manager);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                manager.Turn++;
                Console.WriteLine($"The end of turn + {manager.Turn} \n");

            } while (manager.Turn <= 100);

            return true;
        }

        public class Resource
        {
            public int wood;
            public int stone;

            public Resource()
            {
                this.wood = 0;
            }

            public Resource(int stone)
            {
                this.stone = 0;
            }
        }

        static void gatherWood(Manager manager) 
        {
            manager.resource.wood += 1;
            Console.WriteLine($"You have gathered 1 wood, you now have {manager.resource.wood} \n");
        }

        static void gatherStone(Manager manager)
        {
            manager.resource.stone += 1;
            Console.WriteLine($"You have gathered 1 stone, you now have {manager.resource.stone} \n");
        }
    }
}
