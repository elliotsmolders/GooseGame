namespace GooseGame.Business
{
    public static class Dice
    {
        private static readonly Random rnd = new Random();

        /// <summary>
        /// rnd initialized with .next to avoid not getting true randomness
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int RollDice(int max = 6)
        {
            return rnd.Next(1, max);
        }
    }
}