namespace _456_132Pattern;

public class Solution456 {
    public bool Find132pattern(int[] nums) {
        var l = nums.Length;
        var n2 = int.MinValue;

        var valuesHigherThani = new Stack<int>();
        
        for (int i = l-1; i >= 0; i--){
            var ni = nums[i];
            if (n2 > ni) return true;
            while (valuesHigherThani.Count > 0 && valuesHigherThani.Peek() < ni){
                n2 = valuesHigherThani.Pop(); // this can be a 2 so just need to check it has a 1
            }
            valuesHigherThani.Push(ni); //potential 3
        }

        return false;
    }
}