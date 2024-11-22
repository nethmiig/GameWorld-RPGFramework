using System;
using System.Collections.Generic;

namespace Game_World
{
    public class GameWorld
    {
        // Static instance of the class
        private static GameWorld instance = null;

        // Lock object for thread safety (optional for this use case)
        private static readonly object lockObj = new object();

        // Properties for the Game World
        public List<string> WorldMap { get; private set; }
        public List<NPC> NPCs { get; private set; }
        public string TimeOfDay { get; set; }
        public string Weather { get; set; }

        // Private constructor to prevent external instantiation
        private GameWorld()
        {
            // Initialize the game world
            WorldMap = new List<string> { "Village", "Forest", "Mountain", "Castle" };
            NPCs = new List<NPC>
            {
                new NPC("John", "Merchant"),
                new NPC("Lucy", "Warrior"),
                new NPC("Elder", "Guide")
            };
            TimeOfDay = "Morning";
            Weather = "Sunny";
        }

        // Public method to get the single instance of GameWorld
        public static GameWorld Instance
        {
            get
            {
                // Ensure thread safety (optional for single-threaded console apps)
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

        // Method to display the game world's current state
        public void DisplayState()
        {
            Console.WriteLine("World Map Locations: " + string.Join(", ", WorldMap));
            Console.WriteLine("NPCs in the Game:");
            foreach (var npc in NPCs)
            {
                Console.WriteLine($"- {npc.Name}, Role: {npc.Role}");
            }
            Console.WriteLine($"Time of Day: {TimeOfDay}");
            Console.WriteLine($"Weather: {Weather}");
        }
    }

    // NPC class for storing Non-Player Characters
    public class NPC
    {
        public string Name { get; set; }
        public string Role { get; set; }

        public NPC(string name, string role)
        {
            Name = name;
            Role = role;
        }
    }

    
}
