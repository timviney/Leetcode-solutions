namespace _1480_RunningSumOf1dArray
{
    public class Solution1480
    {
        public int[] RunningSum(int[] nums)
        {

            var array = new int[nums.Length];
            int cumul = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                cumul += nums[i];
                array[i] = cumul;
            }

            return array;
        }
    }
}