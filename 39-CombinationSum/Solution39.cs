namespace _39_CombinationSum;

public class Solution39 {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        Array.Sort(candidates);

        var sums = new List<IList<int>>[target+1];
        for (int i = 1; i<=target; i++) sums[i] = new List<IList<int>>();

        for (int i = 0; i<candidates.Length; i++){
            var val = candidates[i];
            if (val > target) break;

            // start with the value itself as an option, and it can add to this below
            sums[val].Add(new List<int>{val});
            
            // then go through all existing sums and add to them as much as possible
            for (int sum = (target-val); sum > 0; sum--){
                var setsThatEqualSum = sums[sum];
                foreach (var set in setsThatEqualSum){
                    var valueOfSet = sum+val;
                    var newSet = new List<int>(set);
                    newSet.Add(val);
                    while (valueOfSet <= target){
                        sums[valueOfSet].Add(new List<int>(newSet));
                        newSet.Add(val);
                        valueOfSet += val;
                    }
                }
            }
        }

        return sums[target];
    }
}