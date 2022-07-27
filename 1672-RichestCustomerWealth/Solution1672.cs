namespace _1672_RichestCustomerWealth
{
    public class Solution1672
    {
        public int MaximumWealth(int[][] accounts)
        {

            int w = 0;
            for (int customer = 0; customer < accounts.Length; customer++)
            {
                int cW = accounts[customer].Sum();
                w = Math.Max(w, cW);
            }

            return w;
        }
    }
}