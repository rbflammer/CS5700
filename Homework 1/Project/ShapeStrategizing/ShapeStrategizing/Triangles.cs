namespace ShapeStrategizing
{
    public class Triangles : ConvexPolygons
    {
        protected new string type = "triangles";

        public Triangles(Shape parent) : base(parent)
        {
            this.parent = parent;
        }

        public override string toString()
        {
            return $"Triangles:"; ;
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
