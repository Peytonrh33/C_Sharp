List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

// Console.WriteLine(eruptions.FirstOrDefault(c => c.Location == "Chile"));
// Console.WriteLine(eruptions.FirstOrDefault(c => c.Location == "Hawaiian Is"));
// Console.WriteLine(eruptions.FirstOrDefault(c => c.Location == "Greenland"));

// Console.WriteLine(eruptions.Where(c => c.Year > 1900).FirstOrDefault( c=> c.Location == "New Zealand"));

// IEnumerable<Eruption> locations = eruptions.Where(c => c.ElevationInMeters > 2000);
// PrintEach(locations, "Over 2000m");

// IEnumerable<Eruption> Names = eruptions.Where(c => c.Volcano.StartsWith("L"));
// PrintEach(Names, "Names that start with L");

// int Max = eruptions.Max(m => m.ElevationInMeters);
// Console.WriteLine(Max);

// Console.WriteLine(eruptions.Where(n => n.ElevationInMeters == Max));

// IEnumerable<Eruption> alphabetical = eruptions.OrderBy(a => a.Volcano);
// PrintEach(alphabetical, "Alphabetically sorted");

// int sum = eruptions.Sum(p => p.ElevationInMeters);
// Console.WriteLine(sum);

// bool checking = eruptions.Any(a => a.Year == 2000);
// Console.WriteLine(checking);

// IEnumerable<Eruption> stratos = eruptions.Where(c => c.Type == "Stratovolcano").Take(3);
// PrintEach(stratos, "v");

// IEnumerable<Eruption> last = eruptions.Where(c => c.Year < 1000).OrderBy(v => v.Volcano);
// PrintEach(last, "done");

// IEnumerable<string> lastOne = eruptions.Where(c => c.Year < 1000).OrderBy(v => v.Volcano).Select(c => c.Volcano).ToList();
// foreach(string name in lastOne)
// {
//     Console.WriteLine(name);
// }

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}


//!! ===============================================================Worked with Anthony and Jacob