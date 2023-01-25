namespace ShapeStrategizing
{
    public class Triangles : ConvexPolygons
    {
        protected string type = "triangles";

        public Triangles(Shape parent) : base(parent)
        {
            this.parent = parent;
        }

        public string toString()
        {
            return $"                    Triangles:                                               {totalArea}"; ;
        }
    }
}
