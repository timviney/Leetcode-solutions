namespace _202_HappyNumber
{
    public class Solution202
    {
        public bool IsHappy(int n)
        {

            HashSet<int> sums = new HashSet<int>();
            sums.Add(n);
            while (true)
            {
                if (IsHappy(n, out int sum)) return true;
                if (sums.Contains(sum)) return false;
                sums.Add(sum);
                n = sum;
            }
        }

        public bool IsHappy(int n, out int sum)
        {

            sum = 0;
            foreach (int digit in GetDigits(n))
            {
                Console.WriteLine(digit);
                sum += digit * digit;
            }
            return sum == 1;
        }

        public IEnumerable<int> GetDigits(int n)
        {
            for (; n > 0; n /= 10)
            {
                yield return (n % 10);
            }
        }
    }
}