namespace _234_PalindromeLinkedList
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

    public class Solution234
    {
        public bool IsPalindrome(ListNode head)
        {
            if (head.next == null) return true;

            ListNode middle = FindMiddle(head);

            ListNode last = ReverseAndReturnLast(middle);

            while (last.next != null)
            {
                if (last.val != head.val) return false;
                last = last.next;
                head = head.next;
            }
            return true;
        }

        private static ListNode ReverseAndReturnLast(ListNode middle)
        {
            ListNode next = middle.next;
            ListNode previous = middle;
            middle.next = null;
            while (next.next != null)
            {
                ListNode oldNext = next.next;
                next.next = previous;
                previous = next;
                next = oldNext;
            }
            next.next = previous;

            return next;
        }

        private static ListNode FindMiddle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }
    }
}