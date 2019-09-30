using System;
using TestGame.Characters;

namespace TestGame.Actions
{
    /// <summary>
    /// Character action class.
    /// </summary>
    public abstract class Action
    {
        private const int NORMAL_PROBABILITY = 1;
        private const int INCREASED_PROBABILITY = 2;

        private String actionName;
        private double probability;
        public double Probability { get { return probability; } set { probability = value; } }
        public double NormalProbability { get { return NORMAL_PROBABILITY; }}
        public double IncreasedProbability { get { return INCREASED_PROBABILITY; } }
        public String ActionName { get { return actionName; } }

        public Action(String actionName, double probability = NORMAL_PROBABILITY)
        {
            this.actionName = actionName;
            this.probability = probability;
        }

        /// <summary>
        /// Check the direction of action (on the character or the enemy).
        /// </summary>
        /// <returns>directed on the enemy or not</returns>
        public abstract bool isForEnemy();

        /// <summary>
        /// Perform an action.
        /// </summary>
        /// <param name="character">Target character</param>
        public abstract void act(Character character);
    }
}