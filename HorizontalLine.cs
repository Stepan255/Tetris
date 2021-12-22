namespace Tetris
{
	class HorizontalLine : Figure
	{
		public HorizontalLine(int leftMin, int leftMax, int top, char sym)
		{
			pList = new List<Point>();
			for (int i = leftMin; i <= leftMax; i++)
			{
				Point p = new Point(i, top, sym);
				pList.Add(p);
			}
		}
	}
}
