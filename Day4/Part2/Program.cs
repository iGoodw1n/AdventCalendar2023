var cards = File.ReadAllLines("input.txt").Select(x => x[10..]).ToList();


var copies = Enumerable.Repeat(1, cards.Count).ToList();
for (int i = 0; i < cards.Count; i++)
{
    var matches = CalcPointsForCard(cards[i]);
   
    for (int j = i + 1; j <= i + matches && j < cards.Count; j++)
    {
        copies[j] += copies[i];
    }

}

foreach (var item in copies)
{
    Console.WriteLine(item);
}

Console.WriteLine(copies.Sum(x => x));



int CalcPointsForCard(string card)
{
    var matches = card
        .Split(new char[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .GroupBy(n => n)
        .Count(g => g.Count() >= 2);

    return matches;
}
