using System;

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
            Console.WriteLine("\nWelcome to the Character Creation!");

            Console.Write("Enter character name: ");
            string characterName = Console.ReadLine();

            Console.Write("Enter character type (Warrior, Mage, Archer): ");
            string characterType = Console.ReadLine();

            Character character;
            try
            {
                // Create the character using the factory
                character = CharacterFactory.CreateCharacter(characterType, characterName);

                // Display character stats
                Console.WriteLine("\nCharacter Created!");
                character.DisplayStats();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"\nError: {e.Message}");
                return;
            }

            // Inventory Management
            ManageInventory(character);

            // Enemy Creation
            Enemy enemy;
            Console.WriteLine("\nEnemy Creation!");

            Console.Write("Enter enemy type (Slime, Goblin, Dragon): ");
            string enemyType = Console.ReadLine();

            Console.Write("Enter enemy rank (Normal, Elite, Boss): ");
            string enemyRank = Console.ReadLine();

            try
            {
                // Create enemy using the factory
                enemy = EnemyFactory.CreateEnemy(enemyType, enemyRank);

                // Display enemy stats
                Console.WriteLine("\nEnemy Created!");
                enemy.DisplayStats();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"\nError: {e.Message}");
                return;
            }

            // Quest Notifications
            QuestManager questManager = new QuestManager();
            QuestNPC villager = new QuestNPC("Villager");
            QuestNPC blacksmith = new QuestNPC("Blacksmith");

            questManager.RegisterObserver(villager);
            questManager.RegisterObserver(blacksmith);

            questManager.ChangeQuestState("Quest Started: Defend the Village");
            questManager.ChangeQuestState("Quest Updated: Gather Reinforcements");
            questManager.ChangeQuestState("Quest Completed: Victory!");
            questManager.UnregisterObserver(villager);
            questManager.ChangeQuestState("New Quest Started: Repair the Village!");

            // Commands and Controller
            GameController gameController = new GameController();
            Controller controller = new Controller();

            ICommand attackCommand = new AttackCommand(character, enemy);
            ICommand defendCommand = new DefendCommand(character);
            ICommand healCommand = new HealCommand(character);
            ICommand moveCommand = new MoveCommand(character, "Forest");

            // Map keys to commands
            controller.MapKeyToCommand(ConsoleKey.A, attackCommand);
            controller.MapKeyToCommand(ConsoleKey.D, defendCommand);
            controller.MapKeyToCommand(ConsoleKey.H, healCommand);
            controller.MapKeyToCommand(ConsoleKey.M, moveCommand);

            Console.WriteLine("\nWelcome to the Game!");
            Console.WriteLine("Use the following keys to control your character:");
            Console.WriteLine("A - Attack | D - Defend | H - Heal | M - Move | Q - Quit");

            // Game loop
            bool isRunning = true;
            while (isRunning)
            {
                Console.Write("\nPress a key: ");
                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Q)
                {
                    Console.WriteLine("\nExiting the game. Goodbye!");
                    isRunning = false;
                }
                else
                {
                    controller.HandleKeyPress(key);

                    // Check if the enemy is defeated
                    if (enemy.Health <= 0)
                    {
                        Console.WriteLine($"\n{enemy.Name} has been defeated! You win!");
                        isRunning = false;
                    }
                }
            }

            // Final Stats
            Console.WriteLine("\nFinal Stats:");
            character.DisplayStats();
            enemy.DisplayStats();

            Console.WriteLine("\nThank you for playing!");
            Console.ReadLine(); // Wait for user input before closing
        }

        // Inventory Management Function
       

        static void ManageInventory(Character character)
        {
            bool managingInventory = true;

            while (managingInventory)
            {
                Console.WriteLine("\nInventory Management:");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Remove Item");
                Console.WriteLine("4. Exit Inventory Management");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddItemToInventory(character);
                        break;

                    case "2":
                        character.Inventory.ListItems();
                        break;

                    case "3":
                        Console.Write("Enter the name of the item to remove: ");
                        string itemName = Console.ReadLine();
                        character.Inventory.RemoveItem(itemName);
                        break;

                    case "4":
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
        static void AddItemToInventory(Character character)
        {
            Console.WriteLine("Select item type to add: 1. Weapon, 2. Defensive, 3. Utility");
            string itemTypeChoice = Console.ReadLine();

            switch (itemTypeChoice)
            {
                case "1":
                    Console.Write("Enter Weapon Name: ");
                    string weaponName = Console.ReadLine();
                    Console.Write("Enter Weapon Damage: ");
                    int weaponDamage = int.Parse(Console.ReadLine());
                    Weapon weapon = new Weapon(weaponName, ItemRarity.Common, weaponDamage, WeaponTypeEnum.Melee);
                    character.Inventory.AddItemAndAssignToEquipment(weapon, character);
                    break;

                case "2":
                    Console.Write("Enter Defensive Item Name: ");
                    string defensiveName = Console.ReadLine();
                    Console.Write("Enter Defense Value: ");
                    int defense = int.Parse(Console.ReadLine());
                    DefensiveItem defensiveItem = new DefensiveItem(defensiveName, ItemRarity.Common, defense);
                    character.Inventory.AddItemAndAssignToEquipment(defensiveItem, character);
                    break;

                case "3":
                    Console.Write("Enter Utility Item Name: ");
                    string utilityName = Console.ReadLine();
                    Console.Write("Enter Effect: ");
                    string effect = Console.ReadLine();
                    UtilityItem utilityItem = new UtilityItem(utilityName, ItemRarity.Common, effect);
                    character.Inventory.AddItemAndAssignToEquipment(utilityItem, character);
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            
        }

        Console.WriteLine("Select slot to unequip: 1. Weapon, 2. Defensive, 3. Utility, 4. Skip");
            string slotChoice = Console.ReadLine();

            if (slotChoice == "4")
            {
                Console.WriteLine("Skipping unequipping process...");
            }
            else
            {
                try
                {
                    EquipmentSlotType slotType = slotChoice switch
                    {
                        "1" => EquipmentSlotType.Weapon,
                        "2" => EquipmentSlotType.Defensive,
                        "3" => EquipmentSlotType.Utility,
                        _ => throw new ArgumentException("Invalid slot type.")
                    };

                    character.UnequipItem(slotType);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


        }






    }





}
