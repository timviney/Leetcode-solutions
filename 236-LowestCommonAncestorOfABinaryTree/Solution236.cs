namespace _236_LowestCommonAncestorOfABinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public class Solution236
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {

            Stack<TreeNode> pBranch = GetParentBranch(root, p);
            if (pBranch == null) return null;

            Stack<TreeNode> qBranch = GetParentBranch(root, q);
            if (qBranch == null) return null;

            TreeNode lastMatch = root;
            int count = pBranch.Count;

            for (int i = 0; i < count; i++)
            {
                if (qBranch.Count == 0 || pBranch.Count == 0) break;
                TreeNode next = pBranch.Pop();
                if (next == qBranch.Pop()) lastMatch = next;
                else break;
            }

            return lastMatch;
        }

        public Stack<TreeNode> GetParentBranch(TreeNode root, TreeNode target)
        {

            Stack<TreeNode> output = new Stack<TreeNode>();
            if (root == target)
            {
                output.Push(root);
                return output;
            }

            bool found = NextNodeIsInTargetBranch(root, target, output);
            if (!found) return null;
            output.Push(root);

            return output;
        }


        public bool NextNodeIsInTargetBranch(TreeNode start, TreeNode target, Stack<TreeNode> stack)
        {
            if (SearchNext(start.left, target, stack)) return true;
            return SearchNext(start.right, target, stack);
        }

        public bool SearchNext(TreeNode leftOrRight, TreeNode target, Stack<TreeNode> stack)
        {
            if (leftOrRight == null) return false;
            else if (leftOrRight == target || NextNodeIsInTargetBranch(leftOrRight, target, stack))
            {
                stack.Push(leftOrRight);
                return true;
            }
            return false;
        }
    }
}