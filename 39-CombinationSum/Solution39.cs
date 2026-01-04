namespace _39_CombinationSum;

public class Solution39 {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        Array.Sort(candidates);
        return BT(candidates, target, 0, new List<int>(), new List<IList<int>>());
    }

    public IList<IList<int>> BT(int[] c, int remaining, int pos, List<int> current, IList<IList<int>> res){
        if (remaining == 0){
            res.Add(new List<int>(current));
            return res;
        }

        while (pos < c.Length && c[pos] <= remaining){
            current.Add(c[pos]);

            BT(c,remaining-c[pos], pos, current, res);
            
            current.RemoveAt(current.Count-1);

            pos++;
        }

        return res;
    }
}