using System.Text;

if (args.Length < 2)
{
    Console.WriteLine("Usage: mkprairie <dimensions> <num_rabbits> [<output_file>]");
    Console.WriteLine();
    Console.WriteLine("    dimensions: WxH (e.g., 160x90)");
    Console.WriteLine("    num_rabbits: The number of rabbits on the prairie");
    Console.WriteLine("    output_file: The path to the output file, or stdout if not specified");
    Console.WriteLine();

    return;
}

string dimensions = args[0];
int numRabbits = int.Parse(args[1]);

Stream outputStream = (args.Length > 2)
    ? new FileStream(args[2], FileMode.Create)
    : Console.OpenStandardOutput();

string outputFile = args.Length > 2 ? args[2] : "stdout";

// Parse dimensions (format: WxH)
var dims = dimensions.Split('x');
if (dims.Length != 2 || !int.TryParse(dims[0], out int width) || !int.TryParse(dims[1], out int height))
{
    Console.WriteLine("Invalid dimensions format. Use WxH (e.g., 160x90).");
    return;
}

var rabbits = new HashSet<Position>();
var rnd = new Random(width * (height>>1) + numRabbits);

while (rabbits.Count < numRabbits)
    rabbits.Add(new Position(rnd.Next(0, width), rnd.Next(0, height)));

using (var writer = new StreamWriter(outputStream, Encoding.UTF8))
{
    writer.NewLine = "\n"; // Force UNIX line endings
    writer.WriteLine($"{width}x{height}");

    for (int y = 0; y < height; y++)
    {
        var lineBuilder = new StringBuilder();

        for (int x = 0; x < width; x++)
        {
            var pos = new Position(x, y);
            if (rabbits.Contains(pos))
                lineBuilder.Append("🐇");
            else
                lineBuilder.Append(NextGroundPatch());
        }

        writer.WriteLine(lineBuilder.ToString());
        if (outputStream is FileStream)
            Console.Write($"\rLine {y+1}...");
    }
}

if (outputStream is FileStream)
    Console.WriteLine();

outputStream.Close();

static string NextGroundPatch()
{
    string[] groundPatches = { "🟢", "🟢", "🟢", "🟢", "🌱", "🌿", "🌾", "🌳", "🌲", "🌵" };
    return groundPatches[new Random().Next(groundPatches.Length)];
}

record Position(int x, int y)
{
    public override string ToString() => $"Rabbit at ({x}, {y})";
}

