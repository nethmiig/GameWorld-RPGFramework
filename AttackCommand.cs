namespace Game_World
{
    public class AttackCommand : ICommand
    {
        private Character _character;
        private Enemy _target;

        public AttackCommand(Character character, Enemy target)
        {
            _character = character;
            _target = target;
        }

        public void Execute()
        {
            Console.WriteLine($"{_character.Name} attacks {_target.Name}!");
            _target.Health -= _character.Strength;

            if (_target.Health <= 0)
            {
                _target.Health = 0; // Prevent negative health
                Console.WriteLine($"{_target.Name} has been defeated!");
                return; // Exit the method as the enemy is already defeated
            }

            Console.WriteLine($"{_target.Name}'s health is now {_target.Health}.");
        }
    }
}
