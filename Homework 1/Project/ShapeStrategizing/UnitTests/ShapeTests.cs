using NuGet.Frameworks;
using ShapeStrategizing;
using System.Xml;

namespace UnitTests
{
    [TestClass]
    public class ShapeTests
    {
        private bool isClose(double unit1, double unit2)
        {
            double difference = Math.Abs(unit1 - unit2);
            return difference < 0.01;
        }

        [TestMethod]
        public void TestAdditon()
        {
            // Object setup

            Shape[] shapes = new Shape[13];

            // Root
            shapes[0] = new Shape();

            // Ellipses
            shapes[1] = new Ellipses(shapes[0]);
            shapes[2] = new Circle(shapes[1]);
            shapes[3] = new NonCircleEllipse(shapes[1]);

            // Convex Polygons
            shapes[4] = new ConvexPolygons(shapes[0]);

            // Triangles
            shapes[5] = new Triangles(shapes[4]);
            shapes[6] = new Equilateral(shapes[5]);
            shapes[7] = new Isosceles(shapes[5]);
            shapes[8] = new Scalene(shapes[5]);

            // Rectangles
            shapes[9] = new Rectangles(shapes[4]);
            shapes[10] = new Square(shapes[9]);
            shapes[11] = new NonSquareRectangle(shapes[9]);

            // Other Regular Polygons
            shapes[12] = new OtherRegularPolygon(shapes[4]);


            // Running addition tests
            
            // Checking with every type
            string[] types = { "circle", "non-circle ellipse", "square", "non-square rectangle", "equilateral", "isosceles", "scalene", "regular polygon" };
            
            foreach (var type in types)
            {
                // Setting up input
                Dictionary<string, string> input = new Dictionary<string, string>();
                input.Add("type", type);
                input.Add("arg0", "4");
                input.Add("arg1", "5");
                input.Add("arg2", "6");

                foreach (var shape in shapes)
                {
                    shape.addArea(input);
                }
            }

            // Checking addition methods
            // Ellipses
            Assert.IsTrue(isClose(shapes[2].getArea(), 50.265));
            Assert.IsTrue(isClose(shapes[3].getArea(), 62.831));
            // Triangles
            Assert.IsTrue(isClose(shapes[6].getArea(), 6.928));
            Assert.IsTrue(isClose(shapes[7].getArea(), 7.806));
            Assert.IsTrue(isClose(shapes[8].getArea(), 9.922));
            // Rectangles
            Assert.IsTrue(isClose(shapes[10].getArea(), 16));
            Assert.IsTrue(isClose(shapes[11].getArea(), 20));
            // Other Regular Polygons
            Assert.IsTrue(isClose(shapes[12].getArea(), 27.5276));

            // Checking summation of children areas
            // Convex polygons
            Assert.IsTrue(isClose(shapes[5].getArea(), 24.656));
            Assert.IsTrue(isClose(shapes[9].getArea(), 36));
            Assert.IsTrue(isClose(shapes[4].getArea(), 88.1836));

            // Ellipses
            Assert.IsTrue(isClose(shapes[1].getArea(), 113.097));
            
            // Grand Total
            Assert.IsTrue(isClose(shapes[0].getArea(), 201.2806));
        }

        [TestMethod]
        public void testXMLParsing()
        {
            string testxml =
                "<shapes>" +
                "  <shape>" +
                "    <type>\"circle\"</type>" +
                "    <args><arg>\"4\"</arg></args>" +
                "  </shape>" +
                "  <shape>" +
                "    <type>\"scalene\"</type>" +
                "    <args>" +
                "      <arg>\"4\"</arg>" +
                "      <arg>\"6\"</arg>" +
                "      <arg>\"8\"</arg>" +
                "    </args>" +
                "  </shape>" +
                "</shapes>";

            File.WriteAllText("test.xml", testxml);

            List<Dictionary<string, string>> output = XMLReader.parseXml("test.xml");

            File.Delete("test.xml");

            Assert.AreEqual(output[0]["type"], "circle");
            Assert.AreEqual(output[0]["arg0"], "4");
            Assert.AreEqual(output[0]["argc"], "1");

            Assert.AreEqual(output[1]["type"], "scalene");
            Assert.AreEqual(output[1]["arg0"], "4");
            Assert.AreEqual(output[1]["arg1"], "6");
            Assert.AreEqual(output[1]["arg2"], "8");
            Assert.AreEqual(output[1]["argc"], "3");
        }

        [TestMethod]
        public void testJSONParsing()
        {
            string testjson =
                "[" +
                "  {" +
               "    \"type\": \"circle\"," +
                "    \"args\": [\"4\"]" +
                "  }," +
                "  {" +
                "    \"type\": \"scalene\"," +
                "    \"args\": [" +
                "      \"4\"," +
                "      \"6\"," +
                "      \"8\"" +
                "    ]" +
                "  }" +
                "]";

            File.WriteAllText("test.json", testjson);

            List<Dictionary<string, string>> output = JSONReader.parseJson("test.json");

            File.Delete("test.json");

            Assert.AreEqual(output[0]["type"], "circle");
            Assert.AreEqual(output[0]["arg0"], "4");
            Assert.AreEqual(output[0]["argc"], "1");

            Assert.AreEqual(output[1]["type"], "scalene");
            Assert.AreEqual(output[1]["arg0"], "4");
            Assert.AreEqual(output[1]["arg1"], "6");
            Assert.AreEqual(output[1]["arg2"], "8");
            Assert.AreEqual(output[1]["argc"], "3");
        }
    }
}