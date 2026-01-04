// See https://aka.ms/new-console-template for more information

//var roman = new _12_IntegerToRoman.Solution12();
//Console.WriteLine(roman.IntToRoman(40));
using _234_PalindromeLinkedList;
using _39_CombinationSum;

var s = new Solution39();
Console.WriteLine(string.Join("||", (s.CombinationSum(new int[] { 2, 3, 6, 7 }, 7)).Select(s => string.Join(',',s))));
