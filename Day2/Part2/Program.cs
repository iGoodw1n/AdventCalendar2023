//For each game, find the minimum set of cubes that must have been present. What is the sum of the power of these sets?
using System.Text.RegularExpressions;

var games = File.ReadAllLines("input.txt");

var sumPowerOFSet = 0;
foreach (var game in games)
{
    sumPowerOFSet += GetPowerOfSet(game);
}

Console.WriteLine(sumPowerOFSet);


int GetPowerOfSet(string game)
{
    var idAndGameData = game.Split(": ");

    var colorData = idAndGameData[1];

    return GetMinSetFor(colorData, "red") * GetMinSetFor(colorData, "green") * GetMinSetFor(colorData, "blue");
}

int GetMinSetFor(string line, string color)
{
    var regex = new Regex($"(\\d+) {color}");
    var matches = regex.Matches(line);

    int max = 0;

    for (int i = 0; i < matches.Count; i++)
    {
        var cubes = int.Parse(matches[i].Groups[1].Value);
        max = Math.Max(max, cubes);
    }

    return max;
}

