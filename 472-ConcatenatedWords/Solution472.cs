namespace _472_ConcatenatedWords
{
    public class Solution472
    {
        // Hashset is way faster but wanted to try using a Trie
        public IList<string> FindAllConcatenatedWordsInADict(string[] words) {
            var results = new List<string>();

            var trie = new Node();
        
            foreach (string word in words){
                AddNode(trie, word, 0);
            }

            foreach (string word in words){
                if (IsConcat(word, trie)) results.Add(word);
            }

            return results;
        }

        private void AddNode(Node node, string word, int pos){
            if (pos == word.Length) {
                node.IsWord = true;
                return;
            }
        
            char ch = word[pos];
            if (!node.Children.TryGetValue(ch, out var child)) {
                child = new Node() { Ch = ch };
                node.Children[ch] = child;
            }
        
            AddNode(child, word, pos + 1);
        }

        private Dictionary<(string, bool),bool> _cache = new();

        private bool IsConcat(string word, Node trie, bool hasSplit = false){
            if (_cache.TryGetValue((word, hasSplit), out bool b)){
                return b;
            }
            var pos = 0;
            var node = trie;
            while (pos < word.Length){
                bool got = node.Children.TryGetValue(word[pos], out var child);
                if (!got) break;
                pos++;
                if (child.IsWord){
                    if (pos == word.Length) return cached(hasSplit);
                    if (IsConcat(word[pos..], trie, true)) return cached(true);
                }
                node = child;
            }
            return cached(false);

            bool cached(bool b){
                _cache.Add((word, hasSplit), b);
                return b;
            }
        }

        private class Node{
            public char Ch;
            public Dictionary<char, Node> Children = new Dictionary<char, Node>();
            public bool IsWord;
        }
    }
}