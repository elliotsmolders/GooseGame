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
        public void RollDice(int max = 6)
        {
            Roll = rnd.Next(1, max);
        }
    }
}