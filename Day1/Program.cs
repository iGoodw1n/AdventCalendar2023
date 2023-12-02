using System.Text.RegularExpressions;
using IndexAndDigit = (int Index, int Digit);

var addresses = File.ReadAllLines("input.txt");

List<string> digitWords = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
List<string> digitNumbers = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];

var sum = 0;

foreach (var address in addresses)
{
    var firstDigit = FindFirstDigit(address, digitWords, digitNumbers);
    var lastDigit = FindLastDigit(address, digitWords, digitNumbers);

    var number = firstDigit * 10 + lastDigit;

    sum += number;
}


Console.WriteLine(sum);

bool TryGetIndexAndMath(string text, List<string> valuesToFind, out IndexAndDigit matchData, bool rightToLeft = false)
{
    var options = new RegexOptions();
    if (rightToLeft)
    {
        options |= RegexOptions.RightToLeft;
    }
    var regex = new Regex($"({string.Join('|', valuesToFind)})", options);

    var match = regex.Match(text);
    Console.WriteLine($"Match for {text}: {match.Groups[0].Value}");
    matchData.Index = match.Groups[0].Index;
    matchData.Digit = valuesToFind.IndexOf(match.Groups[0].Value);

    return match.Success;
}

int FindFirstDigit(string line, List<string> digitWords, List<string> digitsNumbers)
{
    List<IndexAndDigit> digits = [];
    if (TryGetIndexAndMath(line, digitWords, out var matchData))
    {
        digits.Add(matchData);
    }

    if (TryGetIndexAndMath(line, digitsNumbers, out var matchData1))
    {
        digits.Add(matchData1);
    }

    return digits.OrderBy(d => d.Index).First().Digit;
}

int FindLastDigit(string line, List<string> digitWords, List<string> digitsNumbers)
{
    List<IndexAndDigit> digits = [];
    if (TryGetIndexAndMath(line, digitWords, out var matchData, rightToLeft: true))
    {
        digits.Add(matchData);
    }

    if (TryGetIndexAndMath(line, digitsNumbers, out var matchData1, rightToLeft: true))
    {
        digits.Add(matchData1);
    }

    return digits.OrderByDescending(d => d.Index).First().Digit;
}