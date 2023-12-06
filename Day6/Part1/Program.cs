var data = File.ReadAllLines("input.txt");

var times = ParseData(data[0]);
var distances = ParseData(data[1]);

var allPossibleWays = 1;

for (int i = 0; i < times.Count; i++)
{
    allPossibleWays *= GetAllPossibleWins(times[i], distances[i]);
}

Console.WriteLine(allPossibleWays);

List<int> ParseData(string data)
{
    return data.Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToList();
}

int GetAllPossibleWins(int time, int distance)
{
    var minTimeButtonPressed = (-time + (int)Math.Sqrt(time * time - 4 * (-1) * -distance)) / (2 * (-1));
    var maxTimeButtonPressed = (-time - (int)Math.Sqrt(time * time - 4 * (-1) * -distance)) / (2 * (-1));

    return maxTimeButtonPressed - minTimeButtonPressed + 1;
}