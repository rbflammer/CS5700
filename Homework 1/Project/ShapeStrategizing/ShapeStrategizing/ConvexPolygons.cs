namespace ShapeStrategizing
{
    public class ConvexPolygons : Shape
    {
        protected new string type = "convex polygon";

        public ConvexPolygons(Shape parent)
        {
            this.parent = parent;
        }

        public override void addArea(double area)
        {
            totalArea += area;
            parent.addArea(area);
        }

        public override string toString()
        {
            return $"Convex Polygons:"; ;
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
