namespace GameTaskRPS.Classes
{
    static class Conditions
    {
        public enum MoveState
        {
            Lose = -1,
            Draw = 0,
            Win = 1
        }

        public static string MoveStateToString(int value)
        {
            return ((MoveState)Enum.Parse(typeof(MoveState), value.ToString())).ToString();
        }
    }
}
