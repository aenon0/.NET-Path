Console.WriteLine("Enter the word.");
Dictionary<string, int> map = new Dictionary<string, int>();
map.Add("a", 0);
map.Add("b", 0);
map.Add("c", 0);
map.Add("d", 0);
map.Add("e", 0);
map.Add("f", 0);
map.Add("g", 0);
map.Add("h", 0);
map.Add("i", 0);
map.Add("j", 0);
map.Add("k", 0);
map.Add("l", 0);
map.Add("m", 0);
map.Add("n", 0);
map.Add("o", 0);
map.Add("p", 0);
map.Add("q", 0);
map.Add("r", 0);
map.Add("s", 0);
map.Add("t", 0);
map.Add("u", 0);
map.Add("v", 0);
map.Add("w", 0);
map.Add("x", 0);
map.Add("y", 0);
map.Add("z", 0);

string word = Console.ReadLine().ToLower();
foreach(char c in word)
{
    map[Convert.ToString(c)] += 1;
}
Console.WriteLine("Character dictionary of the word " + word + " is:");
foreach (string c in map.Keys)
{
    if (map[Convert.ToString(c)] != 0)
    {
        Console.WriteLine(c + " : " + map[Convert.ToString(c)]);
    }
}

