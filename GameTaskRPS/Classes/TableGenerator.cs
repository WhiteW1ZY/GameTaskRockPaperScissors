using ConsoleTables;
using GameTaskRPS.Classes.Game;

namespace GameTaskRPS.Classes
{
    public static class TableGenerator
    {
        public static ConsoleTable FillTable(string[] gameMoves)
        {
            var table = new ConsoleTable(@"v PC\User >");
            table.AddColumn(gameMoves);
            for (int i = 0; i < gameMoves.Length; i++)
            {
                string[] col = new string[gameMoves.Length + 1];
                col[0] = gameMoves[i];

                for (int j = 0; j < gameMoves.Length; j++)
                {
                    col[j + 1] = Conditions.MoveStateToString(GameRules.WinningFormula(i, j, gameMoves.Length));
                }
                table.AddRow(col);
            }
            return table;
        }
    }
}
