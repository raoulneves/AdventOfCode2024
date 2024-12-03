const string separator = "   ";
int i = 0;
try
{
    using var reader = new StreamReader("input.txt");

    string rawPuzzleInput = reader.ReadToEnd();
    string[] lines = rawPuzzleInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

    List<KeyValuePair<int, int>> locationsList = lines.Select(line => line.Split(separator))
                                                      .Select(pair =>
                                                          new KeyValuePair<int, int>(int.Parse(pair[0]),
                                                              int.Parse(pair[1])))
                                                      .ToList();


    int totalDistance = 0;
    bool firstPass = true;
    var leftSideSmallest = new List<int>();
    var rightSideSmallest = new List<int>();

    do
    {
        int leftSmallest;
        int rightSmallest;

        Console.WriteLine($"At iteration {i}");
        if (firstPass)
        {
            leftSmallest = locationsList.Min(location => location.Key);
            rightSmallest = locationsList.Min(location => location.Value);
            firstPass = false;
        }
        else
        {
            leftSmallest = locationsList.Where(location => !leftSideSmallest.Contains(location.Key))
                                        .Min(location => location.Key);

            Console.WriteLine($"Left {leftSmallest}");
            rightSmallest = locationsList.Where(location => !rightSideSmallest.Contains(location.Value))
                                         .Min(location => location.Value);
            
            Console.WriteLine($"Right {rightSmallest}");
        }

        int leftSideIndex = locationsList.FindIndex(location => location.Key == leftSmallest);
        int rightSideIndex = locationsList.FindIndex(location => location.Value == rightSmallest);
        int distance = Math.Abs(leftSideIndex - rightSideIndex);

        leftSideSmallest.Add(leftSmallest);
        rightSideSmallest.Add(rightSmallest);
        totalDistance += distance;
        i++;
    } while (i < lines.Length);
    
    Console.WriteLine("GOT HERE 1");
    
    Console.WriteLine(totalDistance);
}
catch (IOException e)
{
    Console.WriteLine("GOT HERE 2");

    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}
catch (Exception e)
{
    Console.WriteLine("GOT HERE 3");

    Console.WriteLine($"Broke at {i}");
}