using System;
using System.Collections.Generic;
using TestGame.Actions;


namespace TestGame.Characters
{
    /// <summary>
    /// Computer class.
    /// </summary>
    public class Computer : Character
    {
        private int criticalHealthPercent = 35;

        public Computer(string name) : base(name)
        {
            actions = new List<Actions.Action>{
                new AttackAction(this, "regular attack", 18, 25),
                new AttackAction(this, "random attack", 10,35),
                new RecoverAction(this, "recovery", 18, 25)
            };
        }

        /// <summary>
        /// Set increased probability of recovery if health is less than critical
        /// </summary>
        public void checkHealth()
        {          
            Actions.Action action = actions.Find(item => item.ActionName.Equals("recovery"));

            action.Probability = (Health <= criticalHealthValue()) 
                ? action.IncreasedProbability : action.NormalProbability;
        }

        /// <summary>
        /// Calculate critical health value.
        /// </summary>
        /// <returns>Critical health value</returns>
        private int criticalHealthValue()
        {
            return (criticalHealthPercent * MaxHealth) / 100;
        }
    }
}