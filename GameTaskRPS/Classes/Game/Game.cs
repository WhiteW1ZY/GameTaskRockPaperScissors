namespace GameTaskRPS.Classes.Game
{
    internal class Game
    {
        private string[] gameMoves;
        private string computerMove;
        private HMACGenerator hmacGenerator;

        public void RunGame()
        {
            if (GameRules.IsGameValid(gameMoves))
            {
                computerMove = GameRules.GetComputerMove(gameMoves);
                hmacGenerator = new HMACGenerator(computerMove);
                LoadMenu();
            }
        }

        private void LoadMenu()
        {
            Console.Clear();

            Console.WriteLine(GameInfo.GetHMACMessage(hmacGenerator.HMAC));
            Console.WriteLine(GameInfo.GetAvailableMovesMessage(gameMoves));
            
            string userMove = GameRules.GetUserMove(gameMoves);

            switch (userMove)
            {
                case ("?"): LoadGameRulesTable(); break;
                case ("0"): LoadExitGame(); break;
                default: LoadGameResult(int.Parse(userMove));  break;
            }
        }

        private void LoadGameResult(int userMove)
        {
            Console.WriteLine(GameInfo.GetUserMoveFromStringMessage(userMove, gameMoves));
            Console.WriteLine(GameInfo.GetComputerMoveMessage(computerMove));
            Console.WriteLine(GameInfo.GetResultMessage(Conditions.MoveStateToString(GameRules.WinningFormula(userMove, Array.IndexOf(gameMoves, computerMove) + 1,gameMoves.Length)))); // Convert the computer stroke into a working format and calculate the result.
            Console.WriteLine(GameInfo.GetHMACKeyMessage(hmacGenerator.HMAC_key));
            Console.WriteLine();
        }

        private void LoadGameRulesTable()
        {
            Console.Clear();
            Console.WriteLine(GameInfo.GetTableInfoMessage());
            TableGenerator.FillTable(gameMoves).Write();
            Console.ReadLine();
            
            LoadMenu();
        }

        private void LoadExitGame()
        {
            Console.Clear();
            Console.WriteLine(GameInfo.GetExitMessage());
            Thread.Sleep(2000);
        }

        public Game(string[] gameMoves)
        {
            this.gameMoves = gameMoves;
        }
    }
}
