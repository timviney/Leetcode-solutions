namespace _1584_MinCostToConnectAllPoints
{
    public class Solution1584
    {
        public int MinCostConnectPoints(int[][] points)
        {

            int score = 0;
            bool[] isInTree = new bool[points.Length];
            List<int> tree = new List<int>(points.Length);
            tree.Add(0);
            isInTree[0] = true;

            while (tree.Count < points.Length)
            {
                int bestDistTotal = int.MaxValue;
                int closestToAdd = -1;
                for (int indexToAdd = 0; indexToAdd < points.Length; indexToAdd++)
                {

                    if (isInTree[indexToAdd]) continue;
                    int[] toAdd = points[indexToAdd];

                    int bestDist = int.MaxValue;
                    foreach (int treeMember in tree)
                    {
                        int dist = GetDist(points[treeMember], toAdd);
                        bestDist = Math.Min(bestDist, dist);
                    }

                    if (bestDist < bestDistTotal)
                    {
                        bestDistTotal = bestDist;
                        closestToAdd = indexToAdd;
                    }
                }

                tree.Add(closestToAdd);
                isInTree[closestToAdd] = true;
                score += bestDistTotal;
            }


            return score;
        }

        public int GetDist(int[] treePos, int[] otherPos)
        {
            return Math.Abs(treePos[0] - otherPos[0]) + Math.Abs(treePos[1] - otherPos[1]);
        }
    }
}