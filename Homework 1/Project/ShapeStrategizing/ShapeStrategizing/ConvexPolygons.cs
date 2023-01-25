namespace ShapeStrategizing
{
    public class ConvexPolygons : Shape
    {
        protected string type = "convex polygon";

        public ConvexPolygons(Shape parent)
        {
            this.parent = parent;
        }

        public void addArea(double area)
        {
            totalArea += area;
            parent.addArea(area);
        }

        public string toString()
        {
            return $"          Convex Polygons:                                                   {totalArea}"; ;
        }
    }
}
