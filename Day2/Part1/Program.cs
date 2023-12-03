// Determine which games would have been possible
// if the bag had been loaded with only 12 red cubes, 13 green cubes, and 14 blue cubes.
// What is the sum of the IDs of those games?
using System.Text.RegularExpressions;

const int MAX_RED = 12;
const int MAX_GREEN = 13;
const int MAX_BLUE = 14;

var games = File.ReadAllLines("input.txt");

var sumCorrectIds = 0;
foreach (var game in games)
{
    if(IsGameCorrect(game, out int gameId))
    {
        sumCorrectIds += gameId;
    }
}

Console.WriteLine(sumCorrectIds);


bool IsGameCorrect(string game, out int gameId)
{
    var idAndGameData = game.Split(": ");

    gameId = int.Parse(idAndGameData[0][5..]);

    var colorData = idAndGameData[1];

    return IsColorCorrect(colorData, "red", MAX_RED) && 
        IsColorCorrect(colorData, "green", MAX_GREEN) && 
        IsColorCorrect(colorData, "blue", MAX_BLUE);
}

bool IsColorCorrect(string line, string color, int max)
{
    var regex = new Regex($"(\\d+) {color}");
    var matches = regex.Matches(line);

    for (int i = 0; i < matches.Count; i++)
    {
        var cubes = int.Parse(matches[i].Groups[1].Value);
        if (cubes > max) return false;
    }

    return true;
}

