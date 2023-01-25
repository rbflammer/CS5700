namespace ShapeStrategizing
{
	public class Shape
	{
		protected double totalArea = 0;
		protected string type = "shape";
		public Shape? parent;

		public Shape()
		{
			// Empty
		}

		public String getType()
		{
			return type;
		}

		public double getArea()
		{
			return totalArea;
		}

		public virtual string toString()
		{
			return $"All Shapes:";
		}

		public virtual void addArea(double area)
		{
			totalArea += area;
		}

		public virtual void addArea(Dictionary<string, string> args)
		{
			return;
		}

		public virtual List<string> generateOutput() {
			List<string> output = new List<string>();
			output.Add(toString());
			output.Add(totalArea.ToString());
		    return output;
		}
	}

}