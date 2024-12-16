using System;
using System.Collections.Generic;

namespace Game_World
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the single instance of GameWorld
            GameWorld gameWorld = GameWorld.Instance;

            // Modify the game state
            gameWorld.TimeOfDay = "Evening";
            gameWorld.Weather = "Rainy";

            // Display the updated state
            Console.WriteLine("\nGame State:");
            gameWorld.DisplayState();

            // Character Creation
            PlayerCharacter player = CreatePlayerCharacter();

            // Explore Game World
            ExploreGameWorld(gameWorld, player);

            // Inventory Management
            ManageInventory(player);

            // Enemy Creation
            List<Enemy> enemies = CreateEnemies();

            // Start Combat
            StartCombat(player, enemies);

            Console.WriteLine("\nThank you for playing!");
            Console.ReadLine(); // Wait for user input before closing
        }

        // Character Creation
        static PlayerCharacter CreatePlayerCharacter()
        {
            Console.WriteLine("\nWelcome to the Character Creation!");

            Console.Write("Enter character name: ");
            string characterName = Console.ReadLine();

            Console.Write("Enter character type (Warrior, Mage, Archer): ");
            string characterType = Console.ReadLine();

            try
            {
                Character character = CharacterFactory.CreateCharacter(characterType, characterName);
                Console.WriteLine("\nCharacter Created!");
                character.DisplayStats();

                // Return as PlayerCharacter (downcasting)
                return new PlayerCharacter(character.Name);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"\nError: {e.Message}");
                return CreatePlayerCharacter(); // Retry on invalid input
            }
        }

        // Explore Game World
        static void ExploreGameWorld(GameWorld gameWorld, PlayerCharacter player)
        {
            bool exploring = true;

            while (exploring)
            {
                Console.WriteLine("\nChoose a location to visit:");
                for (int i = 0; i < gameWorld.WorldMap.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {gameWorld.WorldMap[i]}");
                }
                Console.Write("Enter your choice (or 0 to exit): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice > 0 && choice <= gameWorld.WorldMap.Count)
                {
                    string location = gameWorld.WorldMap[choice - 1];
                    Console.WriteLine($"\nYou arrived at {location}.");

                    foreach (var npc in gameWorld.LocationNPCs[location])
                    {
                        Console.WriteLine($"\nInteract with {npc.Name} ({npc.Role})? (yes/no)");
                        string response = Console.ReadLine()?.ToLower();

                        if (response == "yes" && npc is NPC questNpc)
                        {
                            questNpc.Interact(player);
                        }
                    }
                }
                else if (choice == 0)
                {
                    exploring = false;
                    Console.WriteLine("Exiting exploration...");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        // Inventory Management Function
        static void ManageInventory(PlayerCharacter player)
        {
            bool managingInventory = true;

            while (managingInventory)
            {
                Console.WriteLine("\nInventory Management:");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Remove Item");
                Console.WriteLine("4. View Active Quests");
                Console.WriteLine("5. Exit Inventory Management");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddItemToInventory(player);
                        break;

                    case "2":
                        player.Inventory.ListItems();
                        break;

                    case "3":
                        Console.Write("Enter the name of the item to remove: ");
                        string itemName = Console.ReadLine();
                        player.Inventory.RemoveItem(itemName);
                        break;

                    case "4":
                        player.DisplayActiveQuests();
                        break;

                    case "5":
                        managingInventory = false;
                        Console.WriteLine("Exiting Inventory Management...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Add Item to Inventory
        static void AddItemToInventory(PlayerCharacter player)
        {
            Console.WriteLine("Select item type to add: 1. Weapon, 2. Defensive, 3. Utility");
            string itemTypeChoice = Console.ReadLine();

            try
            {
                switch (itemTypeChoice)
                {
                    case "1":
                        Console.Write("Enter Weapon Name: ");
                        string weaponName = Console.ReadLine();
                        Console.Write("Enter Weapon Damage: ");
                        int weaponDamage = int.Parse(Console.ReadLine());
                        Weapon weapon = new Weapon(weaponName, ItemRarity.Common, weaponDamage, WeaponTypeEnum.Melee);
                        player.Inventory.AddItemAndAssignToEquipment(weapon, player);
                        break;

                    case "2":
                        Console.Write("Enter Defensive Item Name: ");
                        string defensiveName = Console.ReadLine();
                        Console.Write("Enter Defense Value: ");
                        int defense = int.Parse(Console.ReadLine());
                        DefensiveItem defensiveItem = new DefensiveItem(defensiveName, ItemRarity.Common, defense);
                        player.Inventory.AddItemAndAssignToEquipment(defensiveItem, player);
                        break;

                    case "3":
                        Console.Write("Enter Utility Item Name: ");
                        string utilityName = Console.ReadLine();
                        Console.Write("Enter Effect: ");
                        string effect = Console.ReadLine();
                        UtilityItem utilityItem = new UtilityItem(utilityName, ItemRarity.Common, effect);
                        player.Inventory.AddItemAndAssignToEquipment(utilityItem, player);
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        // Enemy Creation
        static List<Enemy> CreateEnemies()
        {
            List<Enemy> enemies = new List<Enemy>();
            Console.WriteLine("\nEnemy Creation!");

            for (int i = 0; i < 2; i++) // Create 2 enemies
            {
                Console.Write($"Enter enemy type for Enemy {i + 1} (Slime, Goblin, Dragon): ");
                string enemyType = Console.ReadLine();

                Console.Write($"Enter enemy rank for Enemy {i + 1} (Normal, Elite, Boss): ");
                string enemyRank = Console.ReadLine();

                try
                {
                    enemies.Add(EnemyFactory.CreateEnemy(enemyType, enemyRank));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"\nError: {e.Message}");
                    i--; // Retry current enemy creation
                }
            }

            Console.WriteLine("\nEnemies Created!");
            foreach (var enemy in enemies)
            {
                enemy.DisplayStats();
            }

            return enemies;
        }

        // Start Combat
        static void StartCombat(PlayerCharacter player, List<Enemy> enemies)
        {
            CombatManager combatManager = new CombatManager(new List<Character> { player }, enemies);
            combatManager.StartCombat();

            Console.WriteLine("\nFinal Stats:");
            player.DisplayStats();
            foreach (var enemy in enemies)
            {
                enemy.DisplayStats();
            }
        }
    }
}
