namespace _724_FindPivotIndex
{
    public class Solution724
    {
        public int PivotIndex(int[] nums)
        {

            int lSum = 0;
            int rSum = nums.Sum() - nums[0];
            if (rSum == 0) return 0;

            for (int i = 1; i < nums.Length; i++)
            {
                lSum += nums[i - 1];
                rSum -= nums[i];

                if (lSum == rSum) return i;
            }

            return -1;
        }
    }
}