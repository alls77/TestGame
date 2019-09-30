using System;
using System.Collections.Generic;
using TestGame.Actions;
using TestGame.Characters;
using TestGame.Utils;

namespace TestGame
{
    /// <summary>
    /// Class implements the general logic of the game.
    /// </summary>
    public class Game
    {
        private List<Character> characters= new List<Character>();
        private Player Player;
        private Computer Computer;
        private Randomizer random = new Randomizer();

        /// <summary>
        /// Create characters.
        /// </summary>
        private void start()
        {
            Player = new Player("player");
            Computer = new Computer("computer");
            characters.Add(Player);
            characters.Add(Computer);

            Console.WriteLine("\nStart game!");
            Console.WriteLine("Player 1: " + Player.Name + " Player 2:  " + Computer.Name + "\n");
        }

        /// <summary>
        /// Start the game loop.
        /// </summary>
        public void play() {
            start();

            random.Shuffle(characters);
            while (isContinue())
            {                
                move();
            }

            end();
        }

        /// <summary>
        /// Check the game is continues or not
        /// </summary>
        /// <returns>the game is continues or not</returns>
        private bool isContinue()
        {
            return (Player.isAlive() && Computer.isAlive());
        }

        /// <summary>
        /// Implement character move
        /// </summary>
        private void move()
        {
            Character activeCharacter = characters[0];
            Character targetCharacter;

            Actions.Action action = activeCharacter.getAction();

            while (action is RecoverAction && activeCharacter.Health == activeCharacter.MaxHealth)
            {
                action = activeCharacter.getAction();
            }

            targetCharacter = (action.isForEnemy()) ? characters[1] : characters[0];
            action.act(targetCharacter);

            Computer.checkHealth();
            characters.Reverse();

            Console.WriteLine(Computer.Name + " hp: " + Computer.Health + " "
            +Player.Name + " hp: " + Player.Health+"\n");
        }

        /// <summary>
        /// Complete the game.
        /// </summary>
        public void end() {
            if (!Computer.isAlive())
            {

                Console.WriteLine("\n" + Computer.Name + " lose.");
            }
            else if (!Player.isAlive())
            {
                Console.WriteLine("\n" + Player.Name + " lose.");
            }

            Console.WriteLine("Game over!");
        }
    }
}