using System.Text.RegularExpressions;

class Palindrome
{
    public static void Main(string[] args)
    {
        string word = Console.ReadLine()!;
        if (word.Length == 0)
        {
            Console.WriteLine("please enter a valid word");
        }
        else
        {
            string cleanWord = Regex.Replace(word, @"\p{P}", "").ToLower();

            bool result = CheckPalindrome(cleanWord);
            Console.WriteLine(result);
        }
        
    }

    public static bool CheckPalindrome(string word)
    {
        var i = 0;
        var j = word.Length - 1;

        while (i < j)
        {
            if (word[i] != word[j])
            {
                return false;
            }
            i++;
            j--;
        }
        return true;
    }
}
