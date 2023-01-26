using Newtonsoft.Json;
using System;

namespace ShapeStrategizing
{
    public class JSONReader
    {
        public static List<Dictionary<string, string>> parseJson(string path)
        {
            string json = File.ReadAllText(path);

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonObject[]>(json);

            List<Dictionary<string, string>> output = new List<Dictionary<string, string>>();

            if (result == null) return output;

            foreach (var response in result)
            {
                Dictionary<string, string> shape= new Dictionary<string, string>();
                int index = 0;
                shape.Add("type", response.type);
                foreach(var arg in response.args)
                {
                    shape.Add($"arg{index++}", arg);
                }
                shape.Add("argc", index.ToString());
                output.Add(shape);
            }

          //foreach(var shape in output)
          //{
          //    Console.WriteLine(shape["type"]);
          //    for (int i = 0; i < int.Parse(shape["argc"]); i++)
          //    {
          //        Console.WriteLine(shape[$"arg{i}"]);
          //    }
          //}

            return output;
        }
    }

    class JsonObject
    {
        public string type;
        public string[] args;
    }
}