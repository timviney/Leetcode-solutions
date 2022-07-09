namespace _13_RomanToInteger
{
    public class Solution13
    {
        public int RomanToInt(string s)
        {
            int total = 0;

            int currentCharIndex = 0;

            int currentValue = GetNextNumeralValue(ref currentCharIndex, s);

            while (currentCharIndex != s.Length)
            {
                int nextValue = GetNextNumeralValue(ref currentCharIndex, s);

                if (nextValue > currentValue) total -= currentValue;
                else total += currentValue;

                currentValue = nextValue;
            }

            return total + currentValue;
        }

        public int GetNextNumeralValue(ref int currentCharIndex, string s)
        {
            char startChar = s[currentCharIndex];
            int value = GetValue(startChar);
            int total = value;

            currentCharIndex++;
            while (currentCharIndex < s.Length)
            {             
                char nextChar = s[currentCharIndex];
                if (nextChar != startChar) break;
                total += value;
                currentCharIndex++;
            }

            return total;
        }

        public int GetValue(char numeral)
        {
            switch (numeral)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }
    }
}
