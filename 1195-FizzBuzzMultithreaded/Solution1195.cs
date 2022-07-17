namespace _1195_FizzBuzzMultithreaded
{
    public class Solution1195
    {
        private int n;
        private int i;
        private object lockKey = new object();
        private bool Running = true;

        public Solution1195(int n)
        {
            this.n = n;
            i = 1;
        }

        // printFizz() outputs "fizz".
        public void Fizz(Action printFizz)
        {
            while (Running)
            {
                CheckAndRun(() => (IsDiv(3) && !IsDiv(5)), printFizz);
            }
        }

        // printBuzzz() outputs "buzz".
        public void Buzz(Action printBuzz)
        {
            while (Running)
            {
                CheckAndRun(() => (IsDiv(5) && !IsDiv(3)), printBuzz);
            }
        }

        // printFizzBuzz() outputs "fizzbuzz".
        public void Fizzbuzz(Action printFizzBuzz)
        {
            while (Running)
            {
                CheckAndRun(() => (IsDiv(3) && IsDiv(5)), printFizzBuzz);
            }
        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Number(Action<int> printNumber)
        {
            while (Running)
            {
                CheckAndRun(() => (!IsDiv(3) && !IsDiv(5)), () => printNumber(i));
            }
        }

        public bool IsDiv(int by) => i % by == 0;

        public void CheckAndRun(Func<bool> isDiv, Action print)
        {
            lock (lockKey)
            {
                if (i > n) return;
                if (isDiv())
                {
                    print();
                    i++;
                    if (i > n) Running = false;
                }
            }
        }
    }
}