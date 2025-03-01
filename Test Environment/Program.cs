using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using static Test_Environment.Program;

namespace Test_Environment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(0);

            MainMenu(manager);
            Gather(manager);
            Construct(manager);
        }

        static void MainMenu(Manager manager)
        {
            int choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("----------");
                Console.WriteLine("1) Gather");
                Console.WriteLine("2) Construct");
                Console.WriteLine("3) Exit");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Gather(manager);
                            break;
                        case 2:
                            Construct(manager);
                            break;
                        case 3:
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice, try again.");
                            break;
                    }
                }
            } while (choice != 3);
        }

        static void Gather(Manager manager)
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Gather wood");
                Console.WriteLine("2) Gather stone");
                Console.WriteLine("3) Exit");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            gatherWood(manager);
                            break;
                        case 2:
                            gatherStone(manager);
                            break;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }

                manager.Turn++;
                Console.WriteLine($"The end of turn {manager.Turn} \n");

            } while (choice != 3 && manager.Turn <= 100);
        }

        static void Construct(Manager manager)
        {

            int choice = 0;
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Construct a fireplace");
                Console.WriteLine("3) Exit");


                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Fireplace(manager);
                            break;
                        //case 2:
                        //    asdf(manager);
                        //    break;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }

                manager.Turn++;
                Console.WriteLine($"The end of turn {manager.Turn} \n");

            } while (choice != 3 && manager.Turn <= 100);
        }

        public class Manager
        {
            public int Turn = 0;
            public Resource resource = new Resource();
            public Buildings buildings = new Buildings();

            public Manager(int turn)
            {
                Turn = turn;
            }
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

        public class Buildings
        {
            public string? Fireplace;
        }


        static void gatherWood(Manager manager) 
        {
            manager.resource.wood += 1;
            Thread.Sleep(500);
            Console.WriteLine($"You have gathered 1 wood, you now have {manager.resource.wood} \n");
        }

        static void gatherStone(Manager manager)
        {
            manager.resource.stone += 1;
            Thread.Sleep(500);
            Console.WriteLine($"You have gathered 1 stone, you now have {manager.resource.stone} \n");
        }

        static void Fireplace(Manager manager)
        {
            if (manager.resource.wood >= 7 && manager.resource.stone >= 3)
            {
                manager.buildings.Fireplace += 1;
                manager.resource.wood -= 7;
                manager.resource.stone -= 3;
                Console.WriteLine($"You now have a fireplace but you lost 7 wood and 3 stone. \n");
            }
            else
            {
                Console.WriteLine($"You don't have enough resources \n");
            }
        }
    }
}
