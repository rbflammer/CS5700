using Newtonsoft.Json;
using System;

namespace ShapeStrategizing
{
    class XMLReader
    {
        public static List<Dictionary<string, string>> parseXml(string path)
        {
            string json = File.ReadAllText(path);

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonObject[]>(json);

            List<Dictionary<string, string>> output = new List<Dictionary<string, string>>();

            foreach (var response in result)
            {
                Dictionary<string, string> shape = new Dictionary<string, string>();
                int index = 0;
                shape.Add("type", response.type);
                foreach (var arg in response.args)
                {
                    shape.Add($"arg{index++}", arg);
                }
                shape.Add("argc", index.ToString());
                output.Add(shape);
            }

            return output;
        }
    }

    class JsonObject
    {
        public string type;
        public string[] args;
    }
}