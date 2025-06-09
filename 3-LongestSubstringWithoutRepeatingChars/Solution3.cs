namespace _3_LongestSubstringWithoutRepeatingChars
{
    public class Solution3
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length < 2) return s.Length;
            var left = 0;
            var max = 0;
            var charIndex = new int[128];
        
            for (int i = 0; i < charIndex.Length; i++)
            {
                charIndex[i] = -1;
            }
        
            for (int right = 0; right < s.Length; right++)
            {
                var c = s[right];
                int pos = charIndex[c];
            
                if (left <= pos)
                {
                    max = Math.Max(right - left, max);
                    left = pos + 1;
                }
                charIndex[c] = right;
            }

            return Math.Max(s.Length - left, max);
        }
        
        #region 2nd Solution
        
        public int LengthOfLongestSubstring2(string s)
        {
            var memo = new Dictionary<string, int>();
            int max = 0;
            for (int p = 0; p < s.Length; p++)
            {
                max = Math.Max(max, LongestSubFromLetter(s, p));
            }

            return max;
        }

        private HashSet<char> l = new();

        public int LongestSubFromLetter(string s, int pos)
        {
            l.Clear();
            for (int p = pos; p < s.Length; p++)
            {
                var count = l.Count;
                l.Add(s[p]);
                if (l.Count == count) return count;
            }

            return l.Count;
        }
        
        #endregion
    }
}