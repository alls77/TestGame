using System;
using TestGame.Characters;

namespace TestGame.Actions
{
    /// <summary>
    /// Recovery action class.
    /// </summary>
    public class RecoverAction:Action
    {
        private Random random = new Random();

        private Character initialCharacter;
        private int minHeal;
        private int maxHeal;


        public RecoverAction(Character initialCharacter, String actionName, int minHeal, int maxHeal)
            :base(actionName)
        {
            this.initialCharacter = initialCharacter;
            this.minHeal = minHeal;
            this.maxHeal = maxHeal;
        }

        /// <summary>
        /// Check the direction of action (on the character or not).
        /// </summary>
        /// <returns>directed on the character</returns>
        public override bool isForEnemy()
        {
            return false;
        }

        /// <summary>
        /// Perform a recover action.
        /// </summary>
        /// <param name="character">This character</param>
        public override void act(Character targetCharacter)
        {
            int heal = random.Next(minHeal, maxHeal);
            targetCharacter.applyHeal(heal);

            Console.WriteLine(initialCharacter.Name + " performed " + ActionName + ", "
             + targetCharacter.Name + " was healed: " + heal);
        }
    }
}