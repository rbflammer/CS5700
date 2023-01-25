namespace ShapeStrategizing
{
	public class Shape
	{
		protected double totalArea = 0;
		protected string type = "shape";
		protected Shape parent;

		public Shape()
		{
		}

		public String getType()
		{
			return type;
		}

		public double getArea()
		{
			return totalArea;
		}

		public string toString()
		{
			return $"Total area of all shapes:                                                    {totalArea}";
		}

		public void addArea(double area)
		{
			totalArea += area;
		}

		public void addArea(Dictionary<string, string> args)
		{
			return;
		}

		private bool isMyType(string type)
		{
			return this.type.Equals(type);
		}
	}

}