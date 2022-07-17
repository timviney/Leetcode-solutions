namespace _657_RobotReturnToOrigin
{
    public class Solution657
    {
        public bool JudgeCircle(string moves)
        {

            int up = 0;
            int along = 0;
            foreach (char c in moves)
            {
                GetDirection(c, ref up, ref along);
            }

            return up == 0 && along == 0;
        }

        public void GetDirection(char c, ref int up, ref int along)
        {
            switch (c)
            {
                case 'U':
                    up++;
                    break;
                case 'D':
                    up--;
                    break;

                case 'L':
                    along--;
                    break;

                case 'R':
                    along++;
                    break;

                default:
                    throw new Exception();
            }
        }
    }
}