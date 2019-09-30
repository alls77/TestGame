using System;
using System.Collections.Generic;
using TestGame.Utils;

namespace TestGame.Characters
{
    /// <summary>
    /// Abstract character class.
    /// </summary>
    public abstract class Character
    {
        private const int MAX_HEALTH = 100;
        private int health = MAX_HEALTH;
        private String name;
        private Randomizer random = new Randomizer();
        protected List<Actions.Action> actions;     

        public String Name { get { return name; } protected set { name = value; } }
        public int Health { get { return health; } protected set { health = value; } }
        public int MaxHealth { get { return MAX_HEALTH; } }

        public Character(String name)
        {
            this.name = name;
        }

        /// <summary>
        /// Check character is alive or not.
        /// </summary>
        /// <returns>Character is alive or not</returns>
        public bool isAlive()
        {
            return (health > 0);
        }

        /// <summary>
        /// To damage the character.
        /// </summary>
        /// <param name="damage">Damage value</param>
        public void applyDamage(int damage)
        {
            health -= damage;
            if (health < 0) health = 0;
        }


        /// <summary>
        /// To heal the character.
        /// </summary>
        /// <param name="heal">Heal value</param>
        public void applyHeal(int heal)
        {
            health += heal;
            if (health > MAX_HEALTH) health = MAX_HEALTH;
        }

        /// <summary>
        /// Get random character action.
        /// </summary>
        /// <returns>Random action</returns>
        public Actions.Action getAction()
        {
            return actions[random.getRandomIndex(actions)];
        }
    }
}