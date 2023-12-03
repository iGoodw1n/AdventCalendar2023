using NumPosition = (int StartIndex, int EndIndex, int LineIndex);

var lines = File.ReadAllLines("input.txt");

int pointer;

int sum = 0;

for (int i = 0; i < lines.Length; i++)
{
    pointer = 0;
    while (pointer < lines[i].Length)
    {
        var numberPosition = GetNextNumberPositionAtLine(i);

        if (IsAdjacentBySymbol(numberPosition))
        {
            int number = ConvertToNumber(numberPosition);
            sum += number;
        }
    }
}

Console.WriteLine(sum);

NumPosition GetNextNumberPositionAtLine(int lineIndex)
{
    int lineLength = lines[lineIndex].Length;
    while (pointer < lineLength && !char.IsDigit(lines[lineIndex][pointer]))
    {
        pointer++;
    }

    int starrtIndex = pointer;

    while (pointer < lineLength && char.IsDigit(lines[lineIndex][pointer]))
    {
        pointer++;
    }

    int endIndex = pointer;

    return new NumPosition(starrtIndex, endIndex, lineIndex);
}

bool IsAdjacentBySymbol(NumPosition numPosition)
{

    for (int i = -1; i < 2; i++)
    {
        int line = numPosition.LineIndex + i;
        if (line < 0 || line >= lines.Length)
        {
            continue;
        }

        int startPos = Math.Max(0, numPosition.StartIndex - 1);

        int endPos = Math.Min(lines[numPosition.LineIndex].Length - 1, numPosition.EndIndex + 1);

        if (IsLineHaveAdjacentSymbol(startPos, endPos, line))
        {
            return true;
        }
    }
    return false;
}

bool IsLineHaveAdjacentSymbol(int startPos, int endPos, int line)
{
    for (int i = 0; i < endPos - startPos; i++)
    {
        char c = lines[line][i + startPos];
        if (!char.IsDigit(c) && c != '.')
        {
            return true;
        }
    }

    return false;
}

int ConvertToNumber(NumPosition numPosition)
{
    var span = lines[numPosition.LineIndex].AsSpan(numPosition.StartIndex, numPosition.EndIndex - numPosition.StartIndex );
    var num = int.Parse(span);
    Console.WriteLine(num);
    return num;
}