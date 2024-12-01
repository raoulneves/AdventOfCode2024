const string separator = "   ";

try
{
    using var reader = new StreamReader("input.txt");

    string rawPuzzleInput = reader.ReadToEnd();
    string[] lines = rawPuzzleInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

    List<KeyValuePair<int, int>> locationsList = lines.Select(line => line.Split(separator))
                                                      .Select(pair => new KeyValuePair<int, int>(int.Parse(pair[0]), int.Parse(pair[1])))
                                                      .ToList();

    foreach (KeyValuePair<int, int> locationLine in locationsList)
    {
        Console.WriteLine(locationLine);
    }
}
catch (IOException e)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}