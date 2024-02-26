namespace GameTaskRPS.Classes.Game
{
    static class GameInfo
    {
        public static string GetResultMessage(string result)
        {
            return string.Format($"You {result}!");
        }
        public static string GetComputerMoveMessage(string computerMove)
        {
            return string.Format($"Computer move: {computerMove}");
        }
        public static string GetUserMoveFromStringMessage(int move, string[] gameMoves)
        {
            return string.Format($"Your move: {gameMoves[move-1]}");
        }
        public static string GetExitMessage()
        {
            return string.Format("See you next time...");
        }
        public static string GetTableInfoMessage()
        {
            return string.Format("The following table summarizes the rules of the game. " +
                "Press any button to return to the menu.");
        }
        public static string GetFewMovesMessage()
        {
            return string.Format("At least three possible moves are required to start the game. " +
                "Add more for a successful start.");
        }
        public static string GetRepeatMovesMessage()
        {
            return string.Format("The moves must be unique. " +
                        "Remove repetitions for a successful start of the game.");
        }

        public static string GetHMACKeyMessage(string hmacKey)
        {
            return string.Format($"HMAC key: {hmacKey}");
        }
        public static string GetHMACMessage(string hmac)
        {
            return string.Format($"HMAC: {hmac}");
        }

        public static string EnterMoveMessage()
        {
            return string.Format("Enter your move: ");
        }
        public static string InvalidInputMessage()
        {
            return string.Format("Invalid input. Please, try again.");
        }

        public static string GetAvailableMovesMessage(string[] gameMoves)
        {
            string result = "Available moves:";
            for(int iteration = 0; iteration < gameMoves.Length; iteration++)
            {
                result += $"\n{iteration+1} - {gameMoves[iteration]}"; 
            }
            result += "\n0 - exit";
            result += "\n? - help";
            return result;
        }
    }
}
