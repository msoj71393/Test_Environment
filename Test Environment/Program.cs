using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using static Test_Environment.Program;

namespace Test_Environment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(0);
            Player player = new Player();
            Tower tower = new Tower();
            Kobold kobold = new Kobold();
            LootTable lootTable = new LootTable();

            MainMenu(manager, player, kobold, tower, lootTable);
            Gather(manager, player, kobold, tower, lootTable);
            Construct(manager, player, kobold, tower, lootTable);

            
        }

        static void MainMenu(Manager manager, Player player, Kobold kobold, Tower tower, LootTable lootTable)
        {
            int choice = 0;
            do
            {
                Console.WriteLine("----------");
                Console.WriteLine("1) Gather");
                Console.WriteLine("2) Construct");
                Console.WriteLine("3) Inventory");
                Console.WriteLine("4) Tower");
                Console.WriteLine("5) Exit");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Gather(manager, player, kobold, tower, lootTable);
                            break;
                        case 2:
                            Construct(manager, player, kobold, tower, lootTable);
                            break;
                        case 3:
                            Inventory(manager);
                            break;
                        case 4:
                            Tower(player, kobold, tower, manager, lootTable);
                            break;
                        case 5:
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice, try again.");
                            break;
                    }
                }
            } while (choice != 6);
        }

        static void Gather(Manager manager, Player player, Kobold kobold, Tower tower, LootTable lootTable)
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
                        case 3:
                            MainMenu(manager, player, kobold, tower, lootTable);
                            break;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }

                manager.Turn++;
                Console.WriteLine($"The end of turn {manager.Turn} \n");

            } while (choice != 4 && manager.Turn <= 100);
        }

        static void Construct(Manager manager, Player player, Kobold kobold, Tower tower, LootTable lootTable)
        {

            int choice = 0;
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Construct a spear, cost 7 wood & 3 stone");
                Console.WriteLine("3) Back");


                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Spear(manager);
                            break;
                        //case 2:
                        //    asdf(manager);
                        //    break;
                        case 3:
                            MainMenu(manager, player, kobold, tower, lootTable);
                            break;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }

                manager.Turn++;
                Console.WriteLine($"The end of turn {manager.Turn} \n");

            } while (choice != 4 && manager.Turn <= 100);
        }

        static void Tower(Player player, Test_Environment.Kobold kobold, Test_Environment.Tower tower, Manager manager, LootTable lootTable)
        {

            int choice = 0;
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Floor 1");
                Console.WriteLine("1) Floor 2");
                Console.WriteLine("3) Back");


                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Combat(player, kobold, tower, lootTable);
                            break;
                        //case 2:
                        //    asdf(manager);
                        //    break;
                        case 3:
                            MainMenu(manager, player, kobold, tower, lootTable);
                            break;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }

                manager.Turn++;
                Console.WriteLine($"The end of turn {manager.Turn} \n");

            } while (choice != 4 && manager.Turn <= 100);
        }

        public class Manager
        {
            public int Turn = 0;
            public Resource resource = new Resource();
            public Building building = new Building();

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

        public class Building
        {
            public bool Spear = false;
        }

        public static void Inventory(Manager manager)
        {

            Console.WriteLine($"You have {manager.resource.wood} wood and {manager.resource.stone} stone");
            Console.WriteLine($"---------------------");
            if (manager.building.Spear == true)
            {
                Console.WriteLine($"You have a spear \n");
            }
        }


        static void gatherWood(Manager manager)
        {
            manager.resource.wood += 1;
            //Thread.Sleep(500);
            Console.WriteLine($"You have gathered 1 wood, you now have {manager.resource.wood} \n");
        }

        static void gatherStone(Manager manager)
        {
            manager.resource.stone += 1;
            //Thread.Sleep(500);
            Console.WriteLine($"You have gathered 1 stone, you now have {manager.resource.stone} \n");
        }

        static void Spear(Manager manager)
        {
            if (manager.resource.wood >= 7 && manager.resource.stone >= 3)
            {
                manager.building.Spear = true;
                manager.resource.wood -= 7;
                manager.resource.stone -= 3;
                Console.WriteLine($"You now have a spear but you lost 7 wood and 3 stone. \n");
            }
            else
            {
                Console.WriteLine($"You don't have enough resources \n");
            }
        }

        static void Combat(Player player, Kobold kobold, Tower tower, LootTable lootTable)
        {

            int choice = 0;
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Attack kobold");
                //Console.WriteLine("1) 2");
                Console.WriteLine("3) Back");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            if (player.Health > 0 && kobold.Health > 0)
                            {
                                kobold.Health -= player.Damage;
                                Console.WriteLine($"You deal {player.Damage} to the kobold, kobold's health is now {kobold.Health} ");
                                player.Health -= kobold.Damage;
                                Console.WriteLine($"The kobold deals {kobold.Damage} to you, your health is now {player.Health} \n");
                                if (kobold.Health == 0) 
                                {
                                    LootTable.InitializeLootTable();
                                    string loot = LootTable.GetRandomLoot();
                                    Console.WriteLine($"Chosen Loot: {loot}");
                                }
                                break;
                            }
                            else if (player.Health == 0)
                            {
                                Console.WriteLine($"You have died");
                                break;
                            }
                            else if (kobold.Health == 0)
                            {
                                Console.WriteLine($"The kobold already dead");
                                break;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }
            } while (choice != 3 && kobold.Health > 0 && choice != 3 && player.Health > 0);
        }

        
    }
}
