using System;


namespace ShapeStrategizing
{
	public class AreaFinder
	{
		private Shape[] shapes;
		public AreaFinder() {
			shapes = new Shape[13];

			// Root
			shapes[0] = new Shape();

			// Ellipses
			shapes[1] = new Ellipses(shapes[0]);
			shapes[2] = new Circle(shapes[1]);
			shapes[3] = new NonCircleEllipse(shapes[1]);

			// Convex Polygons
			shapes[4] = new ConvexPolygons(shapes[0]);

			// Triangles
			shapes[5] = new Triangles(shapes[4]);
			shapes[6] = new Equilateral(shapes[5]);
			shapes[7] = new Isosceles(shapes[5]);
			shapes[8] = new Scalene(shapes[5]);

			// Rectangles
			shapes[9] = new Rectangles(shapes[4]);
			shapes[10] = new Square(shapes[9]);
			shapes[11] = new NonSquareRectangle(shapes[9]);

			// Other Regular Polygons
			shapes[12] = new OtherRegularPolygon(shapes[4]);

        }
		public List<List<string>> calculateArea(List<Dictionary<string, string>> input)
		{
			foreach (var shape in input)
			{
				for (int i = 0; i < 13; i++)
				{
					shapes[i].addArea(shape);
				}
			}

			List<List<string>> output = new List<List<string>>();
			for (int i = 0; i < 13; i++)
			{
				output.Add(shapes[i].generateOutput());
			}
			return output;
		}
	}
}
