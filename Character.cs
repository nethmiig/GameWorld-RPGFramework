namespace Game_World
{
    public abstract class Character
    {
        // Character Properties
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public Inventory Inventory { get; private set; }

        // Strategy Pattern Property
        public IActionStrategy ActionStrategy { get; set; }

        // Equipment Slots
        public Weapon? WeaponSlot { get; set; }
        public DefensiveItem? DefensiveSlot { get; set; }
        public UtilityItem? UtilitySlot { get; set; }





        // State Pattern Property
        private ICharacterState _currentState;

        // Default Constructor
        public Character(string name)
        {
            // Validate name
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Character name cannot be null or empty.");

            Name = name;
            Health = 100; // Default health
            Mana = 50;    // Default mana
            Strength = 20; // Default strength
            Agility = 15;  // Default agility

            _currentState = new IdleState(); // Default state
            Inventory = new Inventory();     // Initialize Inventory
            {
                Name = name ?? throw new ArgumentException("Name cannot be null.");
                Inventory = new Inventory();
            }

        }
        public void EquipItem(string itemName)
        {
            // Check if the item exists in the inventory
            Item itemToEquip = Inventory.FindItemByName(itemName);

            if (itemToEquip == null)
            {
                Console.WriteLine($"Item '{itemName}' does not exist in the inventory. Equip failed.");
                return;
            }

            // Equip the item in the appropriate slot based on its type
            switch (itemToEquip)
            {
                case Weapon weapon:
                    WeaponSlot = weapon;
                    Console.WriteLine($"{weapon.Name} has been equipped in the Weapon Slot.");
                    break;

                case DefensiveItem defensiveItem:
                    DefensiveSlot = defensiveItem;
                    Console.WriteLine($"{defensiveItem.Name} has been equipped in the Defensive Slot.");
                    break;

                case UtilityItem utilityItem:
                    UtilitySlot = utilityItem;
                    Console.WriteLine($"{utilityItem.Name} has been equipped in the Utility Slot.");
                    break;

                default:
                    Console.WriteLine($"Item '{itemName}' cannot be equipped.");
                    break;
            }
        }

        public void UnequipItem(EquipmentSlotType slotType)
        {
            switch (slotType)
            {
                case EquipmentSlotType.Weapon:
                    if (WeaponSlot != null)
                    {
                        Inventory.AddItem(WeaponSlot); // Return the item to the inventory
                        Console.WriteLine($"{WeaponSlot.Name} has been unequipped from the Weapon Slot.");
                        WeaponSlot = null; // Clear the slot
                    }
                    else
                    {
                        Console.WriteLine("Weapon Slot is already empty.");
                    }
                    break;

                case EquipmentSlotType.Defensive:
                    if (DefensiveSlot != null)
                    {
                        Inventory.AddItem(DefensiveSlot); // Return the item to the inventory
                        Console.WriteLine($"{DefensiveSlot.Name} has been unequipped from the Defensive Slot.");
                        DefensiveSlot = null; // Clear the slot
                    }
                    else
                    {
                        Console.WriteLine("Defensive Slot is already empty.");
                    }
                    break;

                case EquipmentSlotType.Utility:
                    if (UtilitySlot != null)
                    {
                        Inventory.AddItem(UtilitySlot); // Return the item to the inventory
                        Console.WriteLine($"{UtilitySlot.Name} has been unequipped from the Utility Slot.");
                        UtilitySlot = null; // Clear the slot
                    }
                    else
                    {
                        Console.WriteLine("Utility Slot is already empty.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid equipment slot selected.");
                    break;
            }
        }




        // Display Equipment Slots
        public void DisplayEquipment()
        {
            Console.WriteLine("\nEquipment Slots:");
            Console.WriteLine($"Weapon Slot: {(WeaponSlot != null ? WeaponSlot.Name : "Empty")}");
            Console.WriteLine($"Defensive Slot: {(DefensiveSlot != null ? DefensiveSlot.Name : "Empty")}");
            Console.WriteLine($"Utility Slot: {(UtilitySlot != null ? UtilitySlot.Name : "Empty")}");
        }

        // Overloaded Constructor for Custom Initialization
        public Character(string name, int health, int mana, int strength, int agility) : this(name)
        {
            Health = health;
            Mana = mana;
            Strength = strength;
            Agility = agility;
        }

        // Method to Change the Character's State
        public void ChangeState(ICharacterState newState)
        {
            if (newState == null)
                throw new ArgumentNullException(nameof(newState), "State cannot be null.");
            _currentState = newState;
        }

        // Handle the Current State
        public void HandleState()
        {
            if (_currentState == null)
            {
                Console.WriteLine($"{Name} is in an undefined state.");
                return;
            }

            _currentState.HandleState(this);
        }

        // Perform an Action Using the Strategy Pattern
        public void PerformAction()
        {
            if (ActionStrategy != null)
            {
                ActionStrategy.PerformAction(this);
            }
            else
            {
                Console.WriteLine($"{Name} has no action strategy set!");
            }
        }

        // Display Character Stats and Inventory
        public virtual void DisplayStats()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health} | Mana: {Mana}");
            Console.WriteLine($"Strength: {Strength} | Agility: {Agility}");
            Console.WriteLine("\nInventory:");
            Inventory.ListItems();
        }

        // Helper Method to Display Character's Current State
        public void DisplayCurrentState()
        {
            if (_currentState != null)
                Console.WriteLine($"{Name} is currently {_currentState.GetType().Name}.");
            else
                Console.WriteLine($"{Name} has no defined state.");
        }

        // Method to Add Item to Inventory
        public void AddItemToInventory(Item item)
        {
            Inventory.AddItem(item);
        }

        // Method to Remove Item from Inventory
        public void RemoveItemFromInventory(string itemName)
        {
            Inventory.RemoveItem(itemName);
        }
    }
}
