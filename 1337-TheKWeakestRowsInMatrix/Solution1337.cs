namespace _1337_TheKWeakestRowsInMatrix
{
    public class Solution1337
    {
        public int[] KWeakestRows(int[][] mat, int k)
        {

            var dict = new SortedDictionary<int, List<int>>();

            for (int row = 0; row < mat.Length; row++)
            {

                int[] rowMat = mat[row];
                int score = 0;
                for (int pos = 0; pos < rowMat.Length; pos++)
                {
                    if (rowMat[pos] == 0) break;
                    score++;
                }

                if (!dict.ContainsKey(score)) dict[score] = new List<int>() { row };
                else dict[score].Add(row);
            }

            int count = 0;
            var output = new int[k];

            foreach (int key in dict.Keys)
            {
                List<int> rows = dict[key];

                foreach (int row in rows)
                {
                    output[count] = row;
                    count++;
                    if (count == k) return output;
                }
            }

            return output;
        }
    }
}