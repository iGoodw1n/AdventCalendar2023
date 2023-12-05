var data = File.ReadAllText("input.txt").Split("\r\n\r\n");
var seeds = data[0][7..].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();

foreach (var mapData in data.Skip(1))
{
    var map = mapData.Split("\r\n").Skip(1).Select(ConvertToTuple).ToList();

    for (int i = 0; i < seeds.Count; i++)
    {
        seeds[i] = Map(seeds[i], map);
    }
}

Console.WriteLine(seeds.Min());

static (long SourceStart, long Range, long DestStart) ConvertToTuple(string line)
{
    var data = line.Split(' ').Select(long.Parse).ToList();
    return (data[1], data[2], data[0]);
}


long Map(long value, List<(long SourceStart, long Range, long DestStart)> list)
{
    var dest = list.Find(x => value >= x.SourceStart && value <= x.SourceStart + x.Range);

    return dest == default ? value : dest.DestStart + value - dest.SourceStart;
}