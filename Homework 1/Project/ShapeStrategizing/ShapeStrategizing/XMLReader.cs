using Newtonsoft.Json;
using System;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ShapeStrategizing
{
    class XMLReader
    {
        public static List<Dictionary<string, string>> parseXml(string path)
        {
            string xml = File.ReadAllText(path);
            
            XDocument doc = XDocument.Parse(xml);

            List<Dictionary<string, string>> output = new List<Dictionary<string, string>>();


            foreach (var shape in doc.Root.Elements("shape").Select(element => element.Value).ToList())
            {
                Dictionary<string, string> newShape = new Dictionary<string, string>();
                StringBuilder sb = new StringBuilder();
                int index = -1;
                int quotecount = 0;
                foreach (char character in shape.ToString())
                {
                    if (character != '\"')
                    {
                        sb.Append(character);
                    } 
                    else
                    {
                        if (quotecount % 2 == 0 && quotecount > 0)
                        {
                            if (index == -1)
                            {
                                newShape.Add("type", sb.ToString());
                            }
                            else
                            {
                                newShape.Add($"arg{index}", sb.ToString());
                            }
                            sb.Clear();
                            index++;
                        }
                        quotecount++;
                    }
                }

                newShape.Add($"arg{index}", sb.ToString());
                newShape.Add("argc", (index + 1).ToString());
                output.Add(newShape);
            }

            foreach (var shape in output)
            {
                Console.WriteLine(shape["type"]);
                for (int i = 0; i < int.Parse(shape["argc"]); i++)
                {
                    Console.WriteLine(shape[$"arg{i}"]);
                }
            }

            return output;
        }
    }
}