namespace _54_SpiralMatrix
{
    public class Solution54
    {
        private int Rows;
        private int Cols;
        private bool[] ColsComplete;
        private bool[] RowsComplete;

        public IList<int> SpiralOrder(int[][] matrix)
        {

            Rows = matrix.Length;
            Cols = matrix[0].Length;
            RowsComplete = new bool[Rows];
            ColsComplete = new bool[Cols];

            int len = Rows * Cols;

            int[] rowCol = new int[2];
            int[] output = new int[len];

            Direction d = Direction.Right;
            for (int i = 0; i < len; i++)
            {

                output[i] = matrix[rowCol[0]][rowCol[1]];

                Move(rowCol, d);

                if (MoveAllowed(rowCol)) continue;
                ReverseMove(rowCol, d);
                d = NextDirection(d);
                Move(rowCol, d);
            }

            return output;
        }

        public enum Direction
        {
            Right, Down, Left, Up
        }

        public void Move(int[] rowCol, Direction d)
        {
            switch (d)
            {
                case Direction.Right:
                    rowCol[1]++;
                    break;
                case Direction.Down:
                    rowCol[0]++;
                    break;
                case Direction.Left:
                    rowCol[1]--;
                    break;
                case Direction.Up:
                    rowCol[0]--;
                    break;
            }
        }

        public void ReverseMove(int[] rowCol, Direction d) => Move(rowCol, (Direction)(((int)d + 2) % 4));

        public Direction NextDirection(Direction d) => (Direction)(((int)d + 1) % 4);

        public bool MoveAllowed(int[] rowCol)
        {
            int row = rowCol[0];
            int col = rowCol[1];

            if (row >= Rows || row < 0 || RowsComplete[row])
            {
                ColsComplete[col] = true;
                return false;
            }
            if (col >= Cols || col < 0 || ColsComplete[col])
            {
                RowsComplete[row] = true;
                return false;
            }

            return true;
        }
    }
}