using System;
using TestGame.Characters;

namespace TestGame.Actions
{
    /// <summary>
    /// Attack action class.
    /// </summary>
    public class AttackAction : Action
    {
        private Random random = new Random();

        private Character Character;
        private int minDamage;
        private int maxDamage;

        public AttackAction(Character Character, String actionName, int minDamage, int maxDamage)
            :base(actionName)
        {
            this.Character = Character;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
        }

        /// <summary>
        /// Check the direction of action (on the enemy or not).
        /// </summary>
        /// <returns>directed on the enemy</returns>
        public override bool isForEnemy()
        {
            return true;
        }

        /// <summary>
        /// Perform an attack action.
        /// </summary>
        /// <param name="character">Enemy character</param>
        public override void act(Character targetCharacter)
        {
            int damage = random.Next(minDamage, maxDamage);
            targetCharacter.applyDamage(damage);

            Console.WriteLine(Character.Name + " performed " + ActionName + ", "
             + targetCharacter.Name + " took damage: " + damage);
        }
    }
}