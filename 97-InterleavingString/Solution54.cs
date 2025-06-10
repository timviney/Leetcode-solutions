namespace _97_InterleavingString
{
    public class Solution97 {
        
        public bool IsInterleave_DP(string s1, string s2, string s3) {
            if (s1 + s2 == s3) return true;

            int l1 = s1.Length;
            int l2 = s2.Length;
            int l3 = s3.Length;

            if (l1 == 0 || l2 == 0 || l3 == 0) return false;
            if (l1 + l2 != l3) return false;

            // DP table: dp[i][j] represents whether first i chars of s1 
            // and first j chars of s2 can form first i+j chars of s3
            bool[,] dp = new bool[s1.Length + 1, s2.Length + 1];

            dp[0,0] = true; // empty strings alwasy match

            // Check each string individually
            for (var i = 0; i < l1; i++){
                dp[i+1,0] = dp[i,0] && s1[i]==s3[i];
            }
            for (var j = 0; j < l2; j++){
                dp[0,j+1] = dp[0,j] && s2[j]==s3[j];
            }

            for (int i = 1; i <= l1; i++) {
                for (int j = 1; j <= l2; j++) {
                    // Current position in s3
                    var k = i + j - 1;

                    var matchS1 = dp[i-1,j] && s1[i-1] == s3[k];
                    if (matchS1) dp[i,j] = true;
                    else{
                        var matchS2 = dp[i,j-1] && s2[j-1] == s3[k];
                        dp[i,j] = matchS2;
                    }
                }
            }

            return dp[l1,l2];
        }
        
        
        public bool IsInterleave_Recursion(string s1, string s2, string s3) {
            if (s1 + s2 == s3) return true;

            int l1 = s1.Length;
            int l2 = s2.Length;
            int l3 = s3.Length;

            if (l1 == 0 || l2 == 0 || l3 == 0) return false;
            if (l1 + l2 != l3) return false;

            var visited = new HashSet<(int,int,int)>();

            return Search(0, 0, 0);

            bool Search(int pos1, int pos2, int pos3){
                if (pos3 == l3) return true;
                if (visited.Contains((pos1,pos2,pos3))) return false;
            
                var c = s3[pos3];
                if (pos1 < l1 && s1[pos1] == c){
                    var found = Search(pos1+1, pos2, pos3+1);
                    visited.Add((pos1,pos2,pos3));
                    if (found) return true;
                }
                if (pos2 < l2 && s2[pos2] == c){
                    var found = Search(pos1, pos2+1, pos3+1);
                    visited.Add((pos1,pos2,pos3));
                    if (found) return true;
                }
            
                return false;
            }
        }
    }
}