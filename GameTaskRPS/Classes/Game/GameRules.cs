namespace GameTaskRPS.Classes.Game
{
    static class GameRules
    {
        private static string[] specialMoves = { "?", "0" };

        public static int WinningFormula(int firstMove, int secondMove, int strokeCount)
        {
            int p = strokeCount >> 1;
            return Math.Sign((firstMove - secondMove + p + strokeCount) % strokeCount - p);
        }

        public static string GetUserMove(string[] gameMoves)
        {
            Console.Write(GameInfo.EnterMoveMessage());
            string move = Console.ReadLine();

            while (Array.IndexOf(specialMoves, move) == -1)
            {
                try
                {
                    int check = int.Parse(move);
                    if (check > 0 && check <= gameMoves.Length)
                    {
                        return move;
                    }
                }
                catch
                {
                }
                Console.WriteLine(GameInfo.InvalidInputMessage());
                Console.Write(GameInfo.EnterMoveMessage());
                move = Console.ReadLine();
            }

            return move;
        }

        public static string GetComputerMove(string[] gameMoves)
        {
            return gameMoves[new Random().Next(0, gameMoves.Length)];
        }

        public static bool IsGameValid(string[] gameMoves)
        {
            if (gameMoves.Length < 3)
            {
                Console.WriteLine(GameInfo.GetFewMovesMessage());
                return false;
            }

            for (int i = 0; i < gameMoves.Length-1; i++)
            {
                for(int j = i+1; j < gameMoves.Length; j++)
                if (gameMoves[i] == gameMoves[j])
                {
                    Console.WriteLine(GameInfo.GetRepeatMovesMessage());
                    return false;
                }
            }
            return true;
        }


    }
}
