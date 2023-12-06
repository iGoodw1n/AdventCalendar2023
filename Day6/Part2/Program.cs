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
    var min = 1L;
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

    long CalcDistance(long seconds)
    {
        return (time - seconds) * seconds;
    }
}