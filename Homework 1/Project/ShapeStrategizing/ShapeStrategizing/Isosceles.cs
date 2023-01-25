using System.Drawing;

namespace ShapeStrategizing
{
    public class Isosceles : Triangles
    {
        protected new string type = "isosceles";

        public Isosceles(Shape parent) : base(parent)
        {
            this.parent = parent;
        }

        public override void addArea(Dictionary<string, string> shape)
        {
            if (shape == null) return;
            if (!type.Equals(shape["type"], StringComparison.OrdinalIgnoreCase)) return;

            double side1 = double.Parse(shape["arg0"]); // length of equal sides
            double side2 = double.Parse(shape["arg1"]); // length of single side
            double semiperimeter = ((side1 * 2) + side2) / 2;

            // Heron's Formula
            double area = Math.Sqrt(semiperimeter * ((semiperimeter - side1) * (semiperimeter - side1) * (semiperimeter - side2)));
            totalArea += area;

            // Passing up tree
            parent.addArea(area);
        }
        public override string toString()
        {
            return $"Isosceles:";
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
