using System.Drawing;

namespace ShapeStrategizing
{
    public class Scalene : Triangles
    {
        protected new string type = "scalene";

        public Scalene(Shape parent) : base(parent)
        {
            this.parent = parent;
        }

        public override void addArea(Dictionary<string, string> shape)
        {
            if (shape == null) return;
            if (!type.Equals(shape["type"], StringComparison.OrdinalIgnoreCase)) return;


            double side1 = double.Parse(shape["arg0"]);
            double side2 = double.Parse(shape["arg1"]);
            double side3 = double.Parse(shape["arg2"]);
            double semiperimeter = (side1 + side2 + side3) / 2;

            // Heron's Formula
            double area = Math.Sqrt(semiperimeter * (semiperimeter - side1) * (semiperimeter - side2) * (semiperimeter - side3));
            totalArea += area;

            // Passing up tree
            parent.addArea(area);
        }

        public override string toString()
        {
            return $"Scalene:";
        }
        public override List<string> generateOutput()
        {
            List<string> output = new List<string>();
            output.Add(totalArea.ToString());
            output.Add(toString());

            Shape? nextParent = parent;
            while (nextParent != null)
            {
                output.Add(nextParent.toString());
                nextParent = nextParent.parent;
            }

            output.Reverse();
            return output;
        }
    }
}
