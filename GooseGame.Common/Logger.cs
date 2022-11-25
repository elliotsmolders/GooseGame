namespace GooseGame.Common
{
    public static class Logger
    {
        public static string TurnLog { get; set; }
        public static List<string> TotalLog { get; set; } = new List<string>();

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        public static void AddToCurrentTurnLog(string message)
        {
            TurnLog += $"{message},";
        }

        /// <summary>
        ///
        /// </summary>
        public static void ClearString()
        {
            TurnLog = "";
        }

        /// <summary>
        ///
        /// </summary>
        public static void AddToTotalLog()
        {
            TotalLog.Add(TurnLog);
        }
    }
}