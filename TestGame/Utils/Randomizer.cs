using System;
using System.Collections.Generic;
using System.Linq;


namespace TestGame.Utils
{
    /// <summary>
    /// Class for generating random data.
    /// </summary>
    class Randomizer
    {
        private Random random;

        public Randomizer()
        {
            random = new Random();
        }

        /// <summary>
        /// Helper function. Normalize probabilities of the character’s actions.
        /// </summary>
        /// <param name="actions">Character’s actions</param>
        /// <returns>array of cumulative probability</returns>
        private double[] normalizeProbability(List<Actions.Action> actions)
        {
            double[] probabilities = new double[actions.Count];
            for (int i = 0; i < actions.Count; i++)
            {
                probabilities[i] = actions[i].Probability;
            }

            double sum = probabilities.Sum();
            probabilities[0] /= sum;
            for (int i = 1; i < probabilities.Length; i++)
            {
                probabilities[i] = probabilities[i] / sum + probabilities[i - 1];
            }
            probabilities[probabilities.Length - 1] = 1.0;

            return probabilities;
        }

        /// <summary>
        /// Return random index from Character’s action list.
        /// </summary>
        /// <param name="actions">Character’s actions</param>
        /// <returns>Random index of action List</returns>
        public int getRandomIndex(List<Actions.Action> actions)
        {
            double[] probabilities = normalizeProbability(actions);
            double randomValue = random.NextDouble();

            for (int i = 0; i < probabilities.Length; i++)
                if (probabilities[i] >= randomValue)
                    return i;

            return -1;
        }

        //public T randomElement<T>(List<T> list)
        //{
        //    return list.ElementAt(random.Next(list.Count()));
        //}

        /// <summary>
        /// Shuffle list.
        /// </summary>
        /// <typeparam name="T">The element type of the list</typeparam>
        /// <param name="list">List of elements</param>
        public void Shuffle<T>(List<T> list)
        {
            int number = list.Count;
            while (number > 1)
            {
                number--;
                int k = random.Next(number + 1);
                T value = list[k];
                list[k] = list[number];
                list[number] = value;
            }
        }
    }
}