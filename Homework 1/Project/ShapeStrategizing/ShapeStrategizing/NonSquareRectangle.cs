namespace ShapeStrategizing
{
    public class NonSquareRectangle : Rectangles
    {
        protected new string type = "non-square rectangle";

        public NonSquareRectangle(Shape parent) : base(parent)
        {
            this.parent = parent;
        }

        public override void addArea(Dictionary<string, string> shape)
        {
            if (shape == null) return;
            if (!type.Equals(shape["type"], StringComparison.OrdinalIgnoreCase)) return;

            double length = double.Parse(shape["arg0"]);
            double width  = double.Parse(shape["arg1"]);

            // Heron's Formula
            double area = length * width;
            totalArea += area;

            // Passing up tree
            parent.addArea(area);
        }

        public override string toString()
        {
            return $"Non-Square Rectangle:";
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
