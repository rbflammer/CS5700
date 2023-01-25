namespace ShapeStrategizing
{
    public class Rectangles : ConvexPolygons
    {
        protected string type = "rectangles";

        public Rectangles(Shape parent) : base(parent)
        {
            this.parent = parent;
        }

        public string toString()
        {
            return $"                   Rectangles:                                               {totalArea}"; ;
        }
    }
}