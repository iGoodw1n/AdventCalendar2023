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
    var min = 1;
    for (; min <= time; min++)
    {
        if (CalcDistance(min) > distance)
        {
            break;
        }
    }

    var max = time - 1;

    for (; max > min; max--)
    {
        if (CalcDistance(max) > distance)
        {
            break;
        }
    }

    return max - min + 1;

    int CalcDistance(int seconds)
    {
        return (time - seconds) * seconds;
    }
}