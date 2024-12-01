try
{
    using var reader = new StreamReader("input.txt");

    string rawPuzzleInput = reader.ReadToEnd();
    string[] lines = rawPuzzleInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

    foreach (string line in lines)
    {
        Console.WriteLine(line);
    }
}
catch (IOException e)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}