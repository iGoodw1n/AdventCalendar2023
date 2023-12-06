var data = File.ReadAllLines("input.txt");

var time = ParseData(data[0]);
var distance = ParseData(data[1]);

var allPossibleWays = GetAllPossibleWins(time, distance);

Console.WriteLine(allPossibleWays);

long ParseData(string data)
{
    return long.Parse(new ReadOnlySpan<char>(data.Where(char.IsDigit).ToArray()));
}

long GetAllPossibleWins(long time, long distance)
{
    var minTimeButtonPressed = (-time + (long)Math.Sqrt(time * time - 4 * (-1) * -distance)) / (2 * (-1));
    var maxTimeButtonPressed = (-time - (long)Math.Sqrt(time * time - 4 * (-1) * -distance)) / (2 * (-1));

    return maxTimeButtonPressed - minTimeButtonPressed + 1;
}