using NumPosition = (int StartIndex, int EndIndex, int LineIndex, (int x, int y) GearPos);

var lines = File.ReadAllLines("input.txt");

List<NumPosition> numbers = new();

int pointer;

for (int i = 0; i < lines.Length; i++)
{
    pointer = 0;
    while (pointer < lines[i].Length)
    {
        AddNextNumberWithGearPositionAtLine(i);
    }
}

var sum = numbers
    .GroupBy(n => n.GearPos, ConvertToNumber)
    .Where(g => g.Count() == 2)
    .Select(g => g.Aggregate((x, y) => x * y))
    .Sum();

Console.WriteLine(sum);

void AddNextNumberWithGearPositionAtLine(int lineIndex)
{
    int lineLength = lines[lineIndex].Length;
    while (pointer < lineLength && !char.IsDigit(lines[lineIndex][pointer]))
    {
        pointer++;
    }

    int startIndex = pointer;

    while (pointer < lineLength && char.IsDigit(lines[lineIndex][pointer]))
    {
        pointer++;
    }

    int endIndex = pointer;

    if (TryFindNumberGear(startIndex, endIndex, lineIndex, out var gearPos))
    {
        numbers.Add(new NumPosition(startIndex, endIndex, lineIndex, gearPos));
    }
}

bool TryFindNumberGear(int startIndex, int endIndex, int lineIndex, out (int, int) gearPos)
{
    gearPos = default;
    for (int i = -1; i < 2; i++)
    {
        int line = lineIndex + i;
        if (line < 0 || line >= lines.Length)
        {
            continue;
        }

        int startPos = Math.Max(0, startIndex - 1);

        int endPos = Math.Min(lines[lineIndex].Length - 1, endIndex + 1);

        if (TryFindAdjacentGear(startPos, endPos, line, out gearPos))
        {
            return true;
        }
    }
    return false;
}

bool TryFindAdjacentGear(int startPos, int endPos, int line, out (int, int) gearPos)
{
    gearPos = default;
    for (int i = 0; i < endPos - startPos; i++)
    {
        var y = i + startPos;
        char c = lines[line][y];
        if (!char.IsDigit(c) && c == '*')
        {
            gearPos = (line, y);
            return true;
        }
    }

    return false;
}

int ConvertToNumber(NumPosition numPosition)
{
    var span = lines[numPosition.LineIndex].AsSpan(numPosition.StartIndex, numPosition.EndIndex - numPosition.StartIndex);
    var num = int.Parse(span);
    return num;
}