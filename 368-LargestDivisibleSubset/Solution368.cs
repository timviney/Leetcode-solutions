namespace _368_LargestDivisibleSubset;

public class Solution368
{
    public IList<int> LargestDivisibleSubset(int[] nums) {
        var n = nums.Length;
        var results = new List<int>();

        if (n == 0) return results;
        
        Array.Sort(nums);

        var lengthOfSet = new int[n];
        var previousIndexOfSet = new int[n];

        for (int i = 0; i<n; i++){
            lengthOfSet[i] = 1;
            previousIndexOfSet[i] = -1;
        }

        int maxIndex = 0;

        for (int j = 1; j<n; j++){
            for (int i = 0; i<j; i++){
                bool isDiv = nums[j]%nums[i]==0;
                if (isDiv && lengthOfSet[i] >= lengthOfSet[j]){
                    lengthOfSet[j] = lengthOfSet[i]+1;
                    previousIndexOfSet[j]=i;
                }
            }
            if (lengthOfSet[j] > lengthOfSet[maxIndex]){
                maxIndex = j;
            }
        }

        while (maxIndex > -1){
            results.Add(nums[maxIndex]);
            maxIndex = previousIndexOfSet[maxIndex];
        }

        return results;
    }
}