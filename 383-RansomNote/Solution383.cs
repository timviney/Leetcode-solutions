namespace _383_RansomNote
{
    public class Solution383
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {

            Dictionary<char, int> magDict = GetDict(magazine);
            Dictionary<char, int> noteDict = GetDict(ransomNote);

            foreach (char c in noteDict.Keys)
            {
                if (!magDict.ContainsKey(c)) return false;
                if (magDict[c] < noteDict[c]) return false;
            }

            return true;
        }

        public Dictionary<char, int> GetDict(string words)
        {
            var r = new Dictionary<char, int>();

            foreach (char c in words)
            {
                if (!r.ContainsKey(c)) r[c] = 1;
                else r[c] += 1;
            }

            return r;
        }
    }
}