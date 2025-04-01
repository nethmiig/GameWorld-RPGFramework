# 🧙‍♂️ Fantasy RPG Game – Design Patterns Project

Welcome to the **Fantasy RPG Game**, a console-based RPG project developed in C#. This project demonstrates several core object-oriented design patterns including Singleton, Factory, Abstract Factory, Strategy, State, Observer, and Command. 

---

## 📦 Project Structure

```
DesignPatternsFantasyRPG/
│
├── CharacterCreator/           # Character models and creation (Factory Pattern)
├── EnemyCreator/              # Enemy creation system (Factory)
├── ItemCreator/               # Item generation (Abstract Factory Pattern)
├── GameWorldCreator/          # World generation and management (Singleton)
├── CommandHandler/            # Action execution (Command Pattern)
├── Quests/                    # Quest notification system (Observer Pattern)
├── Program.cs                 # Entry point with sample game logic
```

---

## 🎮 Features

- **Singleton Pattern** for managing a single `GameWorld` instance.
- **Factory Method Pattern** for character creation: `Warrior`, `Mage`, `Archer`, and `NPC`.
- **Abstract Factory Pattern** for generating items like `Weapons`, `Potions`, and `Armor` of different rarities.
- **Strategy Pattern** for flexible character actions like `Attack`, `Heal`, and `Movement`.
- **State Pattern** for managing character states like `Idle`, `Action`, and `Defending`.
- **Command Pattern** to map keyboard inputs to game actions.
- **Observer Pattern** for broadcasting quest updates to characters.

---

## 🚀 Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- IDE like Visual Studio or VS Code with C# support

### Run the Project

```bash
dotnet run
```

You’ll be prompted with:
```
Press 'A' to Attack, 'D' to Defend, 'H' to Heal, 'M' to Move, 'S' to change state. Press 'Q' to quit.
```

---

## 🛡️ Gameplay Summary

- **Characters**: Created using factories (`Conan`, `Merlin`, `Legolas`, and NPCs).
- **World Map**: Randomly generated using a list of `Biomes` (Lake, Forest, Desert, etc.).
- **Inventory System**: Equip weapons, armor, and potions.
- **Combat System**: Use commands to perform actions in real time.
- **Enemies**: Spawned via `EnemyManager` (e.g., Slime, Goblin, Dragon).
- **Quest System**: Notify characters of quest changes using Observer pattern.

---

## 🧩 Design Patterns Implemented

| Pattern         | Purpose                                             | Classes Involved                              |
|----------------|-----------------------------------------------------|------------------------------------------------|
| Singleton       | Global GameWorld instance                          | `GameWorld`                                    |
| Factory Method  | Dynamic character creation                         | `CharacterFactory`, `WarriorFactory`, etc.     |
| Abstract Factory| Dynamic item generation                            | `ItemFactory`, `CommonItemFactory`, etc.       |
| Strategy        | Swappable character actions                        | `IActionStrategy`, `AttackAction`, etc.        |
| State           | Dynamic behavior changes based on character state | `ICharacterState`, `IdleState`, `DefendingState` |
| Observer        | Quest notifications                                | `IObserver`, `ISubject`, `QuestManager`        |
| Command         | Action mapping to keys                             | `ICommand`, `AttackCommand`, `GameController`  |

---

## 🧠 Example Controls

- **A** – Attack
- **D** – Defend
- **H** – Heal
- **M** – Move
- **S** – Change State
- **Q** – Quit Game

---

## 📚 Future Improvements

- Advanced AI for enemy behavior
- Quest dialog trees
- Dungeon generator with events
- Saving/loading game state
- Graphical user interface (GUI)

---

## 👩‍💻 Author

**Nethmi Nirasha Gamage**  
Bachelor's in Information Technology Engineering  
South-Eastern Finland University of Applied Sciences (XAMK)
