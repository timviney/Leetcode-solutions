namespace _412_FizzBuzz
{
    public class Solution412
    {
        public IList<string> FizzBuzz(int n)
        {

            var r = new List<string>(n);

            for (int i = 1; i < n + 1; i++)
            {
                r.Add(Get(i));
            }

            return r;
        }

        public string Get(int n)
        {

            if (n % 15 == 0) return "FizzBuzz";
            if (n % 3 == 0) return "Fizz";
            if (n % 5 == 0) return "Buzz";

            return n.ToString();
        }
    }
}