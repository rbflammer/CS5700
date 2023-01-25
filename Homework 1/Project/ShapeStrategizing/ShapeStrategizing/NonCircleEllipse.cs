namespace ShapeStrategizing
{
    public class NonCircleEllipse : Ellipses
    {
        protected new string type = "non-circle ellipse";

        public NonCircleEllipse(Shape parent) : base(parent)
        {
            this.parent = parent;
        }

        public override void addArea(Dictionary<string, string> shape)
        {
            if (shape == null) return;
            if (!type.Equals(shape["type"], StringComparison.OrdinalIgnoreCase)) return;

            // area = pi * a * b
            double area = pi * double.Parse(shape["arg0"]) * double.Parse(shape["arg1"]);
            totalArea += area;

            // Passing up tree
            parent.addArea(area);
        }

        public override string toString()
        {
            return $"Non-Circle Ellipses:";  
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