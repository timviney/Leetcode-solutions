namespace _153_MinInRotatedSortedArray;

public class Solution153 {
    public int FindMin(int[] nums) {
        int l = 0, r = nums.Length-1;
        while (l<r){
            var m = (l+r)/2;
            if (nums[r] < nums[m])
                l = m+1;
            else r = m;
        }

        return nums[r];
    }
}