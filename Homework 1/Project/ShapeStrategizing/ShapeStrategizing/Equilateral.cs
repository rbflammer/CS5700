namespace ShapeStrategizing
{
    public class Equilateral : Triangles
    {
        protected new string type = "equilateral";

        public Equilateral(Shape parent) : base(parent)
        {
            this.parent = parent;
        }

        public override void addArea(Dictionary<string, string> shape)
        {
            if (shape == null) return;
            if (!type.Equals(shape["type"], StringComparison.OrdinalIgnoreCase)) return;

            double side = double.Parse(shape["arg0"]);
            double semiperimeter = (side * 3) / 2;

            // Heron's Formula
            double area = Math.Sqrt(semiperimeter * (semiperimeter - side) * (semiperimeter - side) * (semiperimeter - side));
            totalArea += area;

            // Passing up tree
            parent.addArea(area);
        }

        public override string toString()
        {
            return $"Equilateral:";
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
