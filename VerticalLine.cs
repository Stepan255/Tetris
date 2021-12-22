namespace Tetris
{
	class VerticalLine : Figure
	{
		public VerticalLine(int topMin, int topMax, int left, char sym)
		{
			pList = new List<Point>();
			for (int i = topMin; i <= topMax; i++)
			{
				Point p = new Point(left, i, sym);
				pList.Add(p);
			}
		}
	}
}