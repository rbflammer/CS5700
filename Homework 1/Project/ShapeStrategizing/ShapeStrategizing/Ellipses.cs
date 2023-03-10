namespace ShapeStrategizing
{
    public class Ellipses : Shape
    {
        protected new string type = "ellipses";
        protected const double pi = 3.14159265359;

        public Ellipses(Shape parent)
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
            return $"Ellipses:"; ;
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