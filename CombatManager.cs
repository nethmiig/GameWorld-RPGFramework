using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class CombatManager
    {
        private List<Character> _players;
        private List<Enemy> _enemies;
        private int _currentTurn;

        public CombatManager(List<Character> players, List<Enemy> enemies)
        {
            _players = players;
            _enemies = enemies;
            _currentTurn = 0;
        }

        public void StartCombat()
        {
            Console.WriteLine("\nCombat Started!");
            while (_players.Exists(p => p.Health > 0) && _enemies.Exists(e => e.Health > 0))
            {
                Console.WriteLine($"\n--- Turn {_currentTurn + 1} ---");
                PlayerTurn();
                if (_enemies.Exists(e => e.Health > 0))
                {
                    EnemyTurn();
                }
                _currentTurn++;
            }

            EndCombat();
        }

        private void PlayerTurn()
        {
            foreach (var player in _players)
            {
                if (player.Health <= 0) continue;

                Console.WriteLine($"\n{player.Name}'s turn. Choose an action:");
                Console.WriteLine("1. Attack 2. Defend 3. Heal 4. Skip");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var target = SelectTarget(_enemies);
                        player.ActionStrategy = new MeleeAction(); // Default to MeleeAction
                        player.PerformAction();
                        target.Health -= player.Strength;
                        Console.WriteLine($"{player.Name} dealt {player.Strength} damage to {target.Name}!");
                        if (target.Health <= 0)
                        {
                            Console.WriteLine($"{target.Name} has been defeated!");
                        }
                        break;

                    case "2":
                        player.ChangeState(new DefendingState());
                        player.HandleState();
                        break;

                    case "3":
                        player.ActionStrategy = new HealAction();
                        player.PerformAction();
                        player.Health += 20;
                        Console.WriteLine($"{player.Name} healed for 20 health. New health: {player.Health}");
                        break;

                    case "4":
                        Console.WriteLine($"{player.Name} skipped their turn.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Turn skipped.");
                        break;
                }
            }
        }

        private void EnemyTurn()
        {
            foreach (var enemy in _enemies)
            {
                if (enemy.Health <= 0) continue;

                var target = _players.Find(p => p.Health > 0); // Find a player who is still alive
                if (target == null) return;

                Random rand = new Random();
                int action = rand.Next(1, 4); // 1: Attack, 2: Heal, 3: Skip

                if (action == 1)
                {
                    Console.WriteLine($"{enemy.Name} attacks {target.Name}!");
                    int damage = enemy.Strength - (target.DefensiveSlot?.Defense ?? 0);
                    damage = Math.Max(0, damage);
                    target.Health -= damage;
                    Console.WriteLine($"{enemy.Name} dealt {damage} damage to {target.Name}!");

                    if (target.Health <= 0)
                    {
                        Console.WriteLine($"{target.Name} has been downed!");
                    }
                }
                else if (action == 2)
                {
                    enemy.Health += 15;
                    Console.WriteLine($"{enemy.Name} used a healing action and recovered 15 health.");
                }
                else
                {
                    Console.WriteLine($"{enemy.Name} skipped their turn.");
                }
            }
        }

        private Enemy SelectTarget(List<Enemy> enemies)
        {
            Console.WriteLine("Select an enemy to attack:");
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].Health > 0)
                    Console.WriteLine($"{i + 1}. {enemies[i].Name} (Health: {enemies[i].Health})");
            }

            int choice = int.Parse(Console.ReadLine());
            return enemies[choice - 1];
        }

        private void EndCombat()
        {
            if (_players.Exists(p => p.Health > 0))
                Console.WriteLine("\nPlayers won the battle!");
            else
                Console.WriteLine("\nEnemies won the battle!");
        }
    }
}
