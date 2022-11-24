namespace GooseGame.Common
{
    public static class Logger
    {
        public static string TurnLog { get; set; }
        public static List<string> TotalLog { get; set; } = new List<string>();

        public static void AddToCurrentTurnLog(string message)
        {
            TurnLog += $"{message},";
        }

        public static void ClearString()
        {
            TurnLog = "";
        }

        public static void AddToTotalLog()
        {
            TotalLog.Add(TurnLog);
        }
    }
}