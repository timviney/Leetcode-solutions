namespace _876_MiddleOfLinkedList
{
    public class Solution876
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public class Solution
        {
            public ListNode MiddleNode(ListNode head)
            {


                if (head.next == null) return head;

                ListNode slow = head;
                ListNode fast = head;

                while (fast.next != null && fast.next.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }


                if (fast.next == null) return slow;
                return slow.next;
            }
        }
    }
}