using System.Text.RegularExpressions;

class WordFrequencyCount
{
    public static void Main(string[] args)
    {
        var words = Console.ReadLine()!.Trim();
        var result = countFrequency(words!);

        foreach (var item in result)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }


    }


    public static Dictionary<string, int> countFrequency(string words)
    {
        Dictionary<string,int> frequency = new Dictionary<string,int>();
        
        string[] separatedWords = words.Split(' ');

        foreach (string word in separatedWords)
        {
            string cleanWord = Regex.Replace(word, @"\p{P}", "");
            if (frequency.ContainsKey(cleanWord))
            {
                frequency[cleanWord]++;
            }
            else {
                frequency[cleanWord] = 1;
            }
        }
        return frequency;
    }
}