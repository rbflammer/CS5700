namespace ShapeStrategizing
{
    public class OtherRegularPolygon : ConvexPolygons
    {
        protected new string type = "regular polygon";

        public OtherRegularPolygon(Shape parent) : base(parent)
        {
            this.parent = parent;
        }

        public override void addArea(Dictionary<string, string> shape)
        {
            if (shape == null) return;
            if (!type.Equals(shape["type"], StringComparison.OrdinalIgnoreCase)) return;

            double sideLength = double.Parse(shape["arg0"]);
            double sideCount = double.Parse(shape["arg1"]); // Prevents conversion to double later
            double apothem = sideLength / (2 * Math.Tan((180/sideCount) * (Math.PI/180)));

            double area = sideCount * sideLength * apothem * 0.5;
            totalArea += area;

            parent.addArea(area);
        }

        public override string toString()
        {
            return $"Other Regular Polygons:"; ;
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