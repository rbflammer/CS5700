namespace ShapeStrategizing
{
    public class Square : Rectangles
    {
        protected new string type = "square";

        public Square(Shape parent) : base(parent)
        {
            this.parent = parent;
        }

        public override void addArea(Dictionary<string, string> shape)
        {
            if (shape == null) return;
            if (!type.Equals(shape["type"], StringComparison.OrdinalIgnoreCase)) return;

            double side = double.Parse(shape["arg0"]);

            // Heron's Formula
            double area = side * side;
            totalArea += area;

            // Passing up tree
            parent.addArea(area);

        }

        public override string toString()
        {
            return $"Square:";
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
