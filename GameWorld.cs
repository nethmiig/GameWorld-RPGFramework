using System;
using System.Collections.Generic;

namespace Game_World
{
    public class GameWorld
    {
        // Static instance of the class (Singleton Pattern)
        private static GameWorld instance = null;

        // Lock object for thread safety (optional for this use case)
        private static readonly object lockObj = new object();

        // Properties for the Game World
        public List<string> WorldMap { get; private set; }
        public Dictionary<string, List<NPC>> LocationNPCs { get; private set; }
        public string TimeOfDay { get; set; }
        public string Weather { get; set; }

        // Private constructor to prevent external instantiation
        private GameWorld()
        {
            InitializeGameWorld();
        }

        // Public method to get the single instance of GameWorld
        public static GameWorld Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new GameWorld();
                    }
                }
                return instance;
            }
        }

        private void InitializeGameWorld()
        {
            // Initialize locations and NPCs
            GenerateWorldMap();
            GenerateNPCs();

            // Set default world properties
            TimeOfDay = "Morning";
            Weather = "Sunny";
        }

        // Generate the game world map with locations
        private void GenerateWorldMap()
        {
            WorldMap = new List<string> { "Village", "Town", "Dungeon", "Castle", "Forest" };
        }

        // Generate NPCs dynamically for each location
        private void GenerateNPCs()
        {
            LocationNPCs = new Dictionary<string, List<NPC>>();
            Random random = new Random();

            foreach (string location in WorldMap)
            {
                LocationNPCs[location] = new List<NPC>();

                int npcCount = random.Next(2, 5); // Random NPC count per location
                for (int i = 0; i < npcCount; i++)
                {
                    string role = random.Next(0, 3) switch
                    {
                        0 => "Villager",
                        1 => "Merchant",
                        2 => "King/Queen",
                        _ => "Villager"
                    };

                    LocationNPCs[location].Add(new NPC($"NPC_{i + 1}_{location}", role));
                }
            }
        }

        // Display the current state of the game world
        public void DisplayState()
        {
            Console.WriteLine("\nWorld Map Locations:");
            foreach (var location in WorldMap)
            {
                Console.WriteLine($"- {location}");
                foreach (var npc in LocationNPCs[location])
                {
                    Console.WriteLine($"   - {npc.Name} ({npc.Role})");
                }
            }
            Console.WriteLine($"\nTime of Day: {TimeOfDay}");
            Console.WriteLine($"Weather: {Weather}");
        }

        // Allow the player to explore locations and interact with NPCs
        public void Explore(PlayerCharacter player)
        {
            bool exploring = true;

            while (exploring)
            {
                Console.WriteLine("\nChoose a location to visit:");
                for (int i = 0; i < WorldMap.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {WorldMap[i]}");
                }
                Console.Write("Enter your choice (or 0 to exit): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice > 0 && choice <= WorldMap.Count)
                {
                    string location = WorldMap[choice - 1];
                    Console.WriteLine($"\nYou arrived at {location}.");
                    List<NPC> npcs = LocationNPCs[location];

                    foreach (var npc in npcs)
                    {
                        Console.WriteLine($"\nInteract with {npc.Name} ({npc.Role})? (yes/no)");
                        string response = Console.ReadLine();
                        if (response.ToLower() == "yes")
                        {
                            npc.Interact(player);
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
    }

    // Enhanced NPC class
    public class NPC
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public Quest AssignedQuest { get; private set; }

        public NPC(string name, string role)
        {
            Name = name;
            Role = role;
            AssignQuest();
        }

        private void AssignQuest()
        {
            AssignedQuest = new Quest($"Help {Role} {Name}", "Complete a task for the NPC", 100);
        }

        public void Interact(PlayerCharacter player)
        {
            Console.WriteLine($"\n{Role} {Name}: Hello, adventurer!");
            if (AssignedQuest != null)
            {
                Console.WriteLine($"Quest Available: {AssignedQuest.Description}");
                Console.WriteLine("Do you want to accept the quest? (yes/no)");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "yes")
                {
                    player.AcceptQuest(AssignedQuest);
                    Console.WriteLine($"Quest '{AssignedQuest.Title}' accepted!");
                }
                else
                {
                    Console.WriteLine("Maybe next time.");
                }
            }
        }
    }

    // Simple Quest Class
    public class Quest
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int RewardGold { get; private set; }

        public Quest(string title, string description, int rewardGold)
        {
            Title = title;
            Description = description;
            RewardGold = rewardGold;
        }
    }

}
