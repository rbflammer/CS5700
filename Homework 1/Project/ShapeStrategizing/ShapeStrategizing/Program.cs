
namespace ShapeStrategizing
{
    class MainClass
    {
        static void Main(string[] args)
        {
            JSONReader.parseJson("D:/jsontest.json");


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
            Console.WriteLine("Should the output file format be .csv or .txt(C/T)?");
            string outputType = Console.ReadLine().ToLower();

            while (outputType == null || (outputType != "c" && outputType != "t"))
            {
                Console.WriteLine("Correct input format is 'c', 'C', 't', or 'T'. Please try again.");
                outputType = Console.ReadLine().ToLower();
            }

            // Getting output file location
            Console.WriteLine("Where should the output file be saved?");
            string outputLocation = Console.ReadLine();

            while (outputLocation == null)
            {
                Console.WriteLine("Please enter a valid path.");
                outputLocation = Console.ReadLine();
            }


        }
    }
}