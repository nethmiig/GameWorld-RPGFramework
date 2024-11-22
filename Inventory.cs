using System;
using System.Collections.Generic;

namespace Game_World
{
    public class Inventory
    {
        private readonly List<Weapon> _weapons;
        private readonly List<DefensiveItem> _defensiveItems;
        private readonly List<UtilityItem> _utilityItems;

        public Inventory()
        {
            _weapons = new List<Weapon>();
            _defensiveItems = new List<DefensiveItem>();
            _utilityItems = new List<UtilityItem>();
        }

        public void AddItem(Item item)
        {
            switch (item)
            {
                case Weapon weapon:
                    _weapons.Add(weapon);
                    Console.WriteLine($"{weapon.Name} has been added to the Weapons category.");
                    break;

                case DefensiveItem defensiveItem:
                    _defensiveItems.Add(defensiveItem);
                    Console.WriteLine($"{defensiveItem.Name} has been added to the Defensive Items category.");
                    break;

                case UtilityItem utilityItem:
                    _utilityItems.Add(utilityItem);
                    Console.WriteLine($"{utilityItem.Name} has been added to the Utility Items category.");
                    break;

                default:
                    Console.WriteLine($"{item.Name} is of an unknown type and cannot be added.");
                    break;
            }
        }

        public void AddItemAndAssignToEquipment(Item item, Character character)
        {
            AddItem(item);

            switch (item)
            {
                case Weapon weapon:
                    if (character.WeaponSlot == null)
                    {
                        character.WeaponSlot = weapon;
                        Console.WriteLine($"{weapon.Name} has been automatically equipped in the Weapon Slot.");
                    }
                    else
                    {
                        Console.WriteLine($"Weapon Slot is already occupied by {character.WeaponSlot.Name}. {weapon.Name} added to inventory.");
                    }
                    break;

                case DefensiveItem defensiveItem:
                    if (character.DefensiveSlot == null)
                    {
                        character.DefensiveSlot = defensiveItem;
                        Console.WriteLine($"{defensiveItem.Name} has been automatically equipped in the Defensive Slot.");
                    }
                    else
                    {
                        Console.WriteLine($"Defensive Slot is already occupied by {character.DefensiveSlot.Name}. {defensiveItem.Name} added to inventory.");
                    }
                    break;

                case UtilityItem utilityItem:
                    if (character.UtilitySlot == null)
                    {
                        character.UtilitySlot = utilityItem;
                        Console.WriteLine($"{utilityItem.Name} has been automatically equipped in the Utility Slot.");
                    }
                    else
                    {
                        Console.WriteLine($"Utility Slot is already occupied by {character.UtilitySlot.Name}. {utilityItem.Name} added to inventory.");
                    }
                    break;

                default:
                    Console.WriteLine($"{item.Name} cannot be assigned to an equipment slot.");
                    break;
            }
        }

        public void RemoveItem(string itemName)
        {
            if (RemoveFromCategory(_weapons, itemName) || RemoveFromCategory(_defensiveItems, itemName) || RemoveFromCategory(_utilityItems, itemName))
            {
                Console.WriteLine($"{itemName} has been removed from the inventory.");
            }
            else
            {
                Console.WriteLine($"Item {itemName} not found in the inventory.");
            }
        }

        private bool RemoveFromCategory<T>(List<T> items, string itemName) where T : Item
        {
            var itemToRemove = items.Find(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);
                return true;
            }
            return false;
        }

        public void ListItems()
        {
            Console.WriteLine("\nCurrent Inventory:");

            if (_weapons.Count == 0 && _defensiveItems.Count == 0 && _utilityItems.Count == 0)
            {
                Console.WriteLine("The inventory is empty.");
                return;
            }

            if (_weapons.Count > 0)
            {
                Console.WriteLine("\nWeapons:");
                foreach (var weapon in _weapons)
                {
                    weapon.DisplayStats();
                }
            }

            if (_defensiveItems.Count > 0)
            {
                Console.WriteLine("\nDefensive Items:");
                foreach (var defensiveItem in _defensiveItems)
                {
                    defensiveItem.DisplayStats();
                }
            }

            if (_utilityItems.Count > 0)
            {
                Console.WriteLine("\nUtility Items:");
                foreach (var utilityItem in _utilityItems)
                {
                    utilityItem.DisplayStats();
                }
            }
        }

        public Item? FindItemByName(string itemName)
        {
            var weapon = _weapons.Find(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (weapon != null) return weapon;

            var defensiveItem = _defensiveItems.Find(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (defensiveItem != null) return defensiveItem;

            var utilityItem = _utilityItems.Find(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (utilityItem != null) return utilityItem;

            return null;
        }
    }
}
