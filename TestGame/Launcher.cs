namespace TestGame
{
    /// <summary>
    /// Class with program entry point.
    /// </summary>
    class Launcher
    {
        /// <summary>
		/// Program entry point.
		/// </summary>
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.play();
        }
    }
}