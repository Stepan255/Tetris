namespace Tetris
{
	class Figure
	{
		internal List<Point> pList;

		public Figure()
		{
			pList = new List<Point>();
		}

		internal void Draw()
		{
			foreach (Point p in pList)
			{
				p.Draw();
			}
		}

		internal void Clear()
		{
			foreach (Point p in pList)
			{
				p.Clear();
			}
		}

		internal bool IsHit(Figure figure)
		{
			foreach (Point p in pList)
			{
				if (figure.IsHit(p)) return true;
			}
			return false;
		}

		internal bool IsHit(Point point)
		{
			foreach (Point p in pList)
			{
				if (p.IsHit(point)) return true;
			}
			return false;
		}
	}
}