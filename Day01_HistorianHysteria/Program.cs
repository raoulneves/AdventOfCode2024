try
{
    using var reader = new StreamReader("input.txt");

    string puzzleInput = reader.ReadToEnd();

    Console.WriteLine(puzzleInput);
}
catch (IOException e)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}