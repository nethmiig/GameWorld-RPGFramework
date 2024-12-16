using Game_World;

public class NPC : IObserver
{
    public string Name { get; set; }
    public string Role { get; set; }
    public Quest AssignedQuest { get; private set; }

    public NPC(string name, string role)
    {
        Name = name;
        Role = role;
        AssignRandomQuest();
    }

    private void AssignRandomQuest()
    {
        AssignedQuest = new Quest($"Find the lost artifact", "Retrieve the artifact from the dungeon", 50);
    }

    public void Interact(PlayerCharacter player)
    {
        Console.WriteLine($"\n{Role} {Name}: Welcome, adventurer!");
        if (AssignedQuest != null)
        {
            Console.WriteLine($"Quest: {AssignedQuest.Description}");
            Console.WriteLine("Do you want to accept this quest? (yes/no)");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "yes")
            {
                player.AcceptQuest(AssignedQuest);
                Console.WriteLine("Quest accepted!");
            }
        }
    }

    public void Update(string questStatus)
    {
        Console.WriteLine($"{Name} received an update: {questStatus}");
    }
}
