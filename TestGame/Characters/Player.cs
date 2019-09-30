using System;
using System.Collections.Generic;
using TestGame.Actions;

namespace TestGame.Characters
{
    /// <summary>
    /// Player class.
    /// </summary>
    public class Player:Character
    {
        public Player(string name) : base(name)
        {
            this.actions = new List<Actions.Action>{
                new AttackAction(this, "regular attack", 18, 25),
                new AttackAction(this, "random attack", 10,35),
                new RecoverAction(this, "recovery", 18, 25)
            };
        }
    }
}
