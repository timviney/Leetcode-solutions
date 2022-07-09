// See https://aka.ms/new-console-template for more information

//var roman = new _12_IntegerToRoman.Solution12();
//Console.WriteLine(roman.IntToRoman(40));
using _234_PalindromeLinkedList;

ListNode end = new ListNode(2);
ListNode start = new ListNode(1,end);

Solution234 s = new Solution234();
s.IsPalindrome(start);
