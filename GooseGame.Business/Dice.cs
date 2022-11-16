namespace GooseGame.Business
{
    public class Dice
    {
        private Random rnd = new Random();
        public int Roll { get; set; }

        /// <summary>
        /// rnd initialized with .next to avoid not getting true randomness
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public int RollDice(int max = 7)
        {
            return Roll = rnd.Next(1, max);
        }
    }
}