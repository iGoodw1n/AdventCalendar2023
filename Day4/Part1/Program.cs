var cards = File.ReadAllLines("input.txt").Select(x => x[10..]).ToList();

var totalPoints = cards.Select(CalcPointsForCard).Sum();

Console.WriteLine(totalPoints);


int CalcPointsForCard(string card)
{
    var matches = card
        .Split(new char[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .GroupBy(n => n)
        .Count(g => g.Count() >= 2);

    return (int)Math.Pow(2, matches - 1);
}
