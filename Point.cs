namespace Tetris
{
	class Point
	{
		public int x;
		public int y;
		public char sym;

		public Point(int x, int y, char sym)
		{
			this.x = x;
			this.y = y;
			this.sym = sym;
		}

		public void Draw()
		{
			Console.SetCursorPosition(x, y);
			Console.Write(sym);
			Console.SetCursorPosition(50, 30);
			// Thread.Sleep(100);
		}

		public void Clear()
		{
			Console.SetCursorPosition(x, y);
			Console.Write(' ');
		}

		public void ClearColor()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.SetCursorPosition(x, y);
			Console.Write('█');
			Thread.Sleep(50);
			Console.ResetColor();
			Clear();
		}

		public bool IsHit(Point p)
		{
			return p.x == this.x && p.y == this.y;
		}
		
		internal void Offset(int left, int top)
		{
			x += left;
			y += top;
		}
	}
}