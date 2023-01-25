
namespace ShapeStrategizing
{
    class MainClass
    {
        static void Main(string[] args)
        {
             // Getting input parameters
             
             // Getting whether xml or json
             Console.WriteLine("Is the input XML or JSON(X/J)?");
             string inputType = Console.ReadLine().ToLower();
             
             while (inputType == null || (inputType != "x" && inputType != "j")) 
             {
                 Console.WriteLine("Correct input is 'x', 'X', 'j', or 'J'. Please try again.");
                 inputType = Console.ReadLine().ToLower();
             }
             
             
             // Getting input file path
             Console.WriteLine($"Where is the input file located? Current directory is {Directory.GetCurrentDirectory()}");
             string inputLocation = Console.ReadLine();
             
             while (inputLocation == null || !File.Exists(inputLocation))
             {
                 Console.WriteLine("Invalid input path, please try again.");
                 inputLocation = Console.ReadLine();
             }
             
             // Getting output file type
             Console.WriteLine("Should the output be saved to a file or displayed on screen?(F/S)?");
             string outputType = Console.ReadLine().ToLower();
             
             while (outputType == null || (outputType != "f" && outputType != "s"))
             {
                 Console.WriteLine("Correct input format is 'f', 'F', 's', or 'S'. Please try again.");
                 outputType = Console.ReadLine().ToLower();
             }
             
             if (outputType == "f")
             {
                 // Getting output file location
                 Console.WriteLine("Where should the output file be saved?");
                 string outputLocation = Console.ReadLine();
             
                 while (outputLocation == null)
                 {
                     Console.WriteLine("Please enter a valid path.");
                     outputLocation = Console.ReadLine();
                 }
             }   
             
             
             // Parsing input
             List<Dictionary<string, string>> shapes;
             
             if (inputType== "j") {
                 shapes = JSONReader.parseJson(inputLocation);
             } else // This must be "x" because of previous statments
             {
                 shapes = XMLReader.parseXml(inputLocation);
             }

            // Computing areas
            AreaFinder areaFinder = new AreaFinder();
            List<List<string>> output = areaFinder.calculateArea(shapes);

            if (outputType == "s") 
            {
                OutputGenerator.displayOutput(output);
            } else
            {
                OutputGenerator.saveOutput(output, "D:/output.csv");
            }
        }
    }
}