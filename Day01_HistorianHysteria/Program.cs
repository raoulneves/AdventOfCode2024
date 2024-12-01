const string separator = "   ";

try
{
    using var reader = new StreamReader("input.txt");

    string rawPuzzleInput = reader.ReadToEnd();
    string[] lines = rawPuzzleInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

    List<KeyValuePair<int, int>> locationsList = lines.Select(line => line.Split(separator))
                                                      .Select(pair => new KeyValuePair<int, int>(int.Parse(pair[0]), int.Parse(pair[1])))
                                                      .ToList();

    int i = 0;
    int totalDistance = 0;
    bool firstPass = true;
    var checkedIds = new List<int>();     
    do
    {
        int smallestId;

        if (firstPass)
        {
            smallestId = locationsList.Min(location => location.Key);    
            firstPass = false;
        }
        else
        {
             smallestId =  locationsList.Where(location => !checkedIds.Contains(location.Key))
                                        .Min(location => location.Key);
        }
        
        int leftSideIndex = locationsList.FindIndex(location => location.Key == smallestId);
        int rightSideIndex = locationsList.FindIndex(location => location.Value == smallestId);
        int distance = Math.Abs(leftSideIndex - rightSideIndex);

        checkedIds.Add(smallestId);
        totalDistance += distance;
        i++;
    } while (i < lines.Length);
    
    Console.WriteLine(totalDistance);
}
catch (IOException e)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}