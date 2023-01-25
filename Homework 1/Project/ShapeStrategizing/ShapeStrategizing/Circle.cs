namespace ShapeStrategizing
{
    public class Circle : Ellipses
    {
        protected new string type = "circle";

        public Circle(Shape parent) : base(parent)
        {
            this.parent = parent;
        }

        public override void addArea(Dictionary<string, string> shape)
        {
            if (shape == null) return;
            if (!type.Equals(shape["type"], StringComparison.OrdinalIgnoreCase)) return;

            // area = pi * r^2
            double area = pi * double.Parse(shape["arg0"]) * double.Parse(shape["arg0"]);
            totalArea += area;

            // Passing up tree
            parent.addArea(area);
        }

        public override string toString()
        {
            return $"Circles:"; 
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