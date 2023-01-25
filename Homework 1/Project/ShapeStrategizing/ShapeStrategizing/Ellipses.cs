namespace ShapeStrategizing
{
    public class Ellipses : Shape
    {
        protected string type = "ellipses";

        public Ellipses(Shape parent)
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
            return $"          Ellipses:                                                          {totalArea}"; ;
        }
    }
}