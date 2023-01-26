using System;
using static System.Net.Mime.MediaTypeNames;

namespace ShapeStrategizing
{
	public class OutputGenerator
	{
		// Displays formatted output to the screen
		public static void displayOutput(List<List<string>> output)
		{
            int maxLength = getMaxLength(output);
			

			foreach (var shape in output)
			{
				int index = 0;
				foreach (var data in shape)
				{
					if (index == shape.Count - 2)
					{
						Console.Write(data);
						for (int i = 0; i < 24 - data.Count(); i++)
						{
							Console.Write(" ");
						}
					} 
					else if (index == shape.Count - 1)
					{
						for (int i = index; i < maxLength - 1; i++)
						{
                            Console.Write("                  ");
                        }
                        Console.Write(" " + data);
                    }
					else
					{
						Console.Write("                  ");
					}
					index++;
				}
				Console.Write('\n');
			}
		}

		public static async void saveOutput(List<List<string>> output, string filename)
		{
			int maxLength = getMaxLength(output);
			string totalOutput = "";


			foreach (var shape in output)
			{
				string outputline = "";
				int index = 0;
				foreach(var data in shape) 
				{
					if (data == shape.Last())
					{
						for(int i = index; i < maxLength - 1;i++)
						{
							outputline += ",";
						}
					}
                    outputline += data;
                    outputline += ",";
					index++;
				}
                outputline += "\n";
				totalOutput += outputline;
			}

			try
			{
				await File.WriteAllTextAsync(filename, totalOutput);
			}
			catch (Exception)
			{
				Console.WriteLine("Unable to open output file '" + filename + "'. Please relaunch program and try again.");
			}
        }

		private static int getMaxLength(List<List<string>> input) {
			int maxLength = 0;
            foreach (var shape in input)
            {
                if (shape.Count > maxLength) maxLength = shape.Count;
            }
			return maxLength;
        }

    }

}