namespace Tetris
{
	class InstalledFigure : Figure
	{
		List<CountPointInLine> countPointInLineList;
		int maxWidth;
		public int score;
		public InstalledFigure(int mapWidth, int mapHeight)
		{
			maxWidth = mapWidth;
			countPointInLineList = new List<CountPointInLine>();
			pList = new List<Point>();
			score = 0;
		}

		public bool IsHit(TetrisFigure tetrisFigure)
		{
			foreach (Point p in pList)
			{
				if (tetrisFigure.IsHit(p)) return true;
			}
			return false;
		}

		public void Add(TetrisFigure tetrisFigure)
		{
			foreach (Point p in tetrisFigure.pList)
			{
				pList.Add(p);
				AddCountPointInLine(p);
			}
		}

		public void AddCountPointInLine(Point p)
		{
			bool check = true;
			foreach (CountPointInLine countPointInLine in countPointInLineList)
			{
				if (p.y == countPointInLine.y)
				{
					countPointInLine.count += 1;
					check = false;
					break;
				}
			}
			if (check)
			{
				CountPointInLine countPointInLine = new CountPointInLine(p.y);
				countPointInLineList.Add(countPointInLine);
			}
		}

		public void CheckLine()
		{
			int countOfClearLine = 0;
			int yMin = int.MaxValue;
			foreach (CountPointInLine countPointInLine in countPointInLineList)
			{
				if (countPointInLine.count >= maxWidth)
				{
					if (countPointInLine.y < yMin) yMin = countPointInLine.y;
					countOfClearLine +=1;
					countPointInLine.count = 0;
					ClearLine(countPointInLine.y);
				}
			}
			if (yMin <= int.MaxValue) 
			{
				if (countOfClearLine == 1) score += 100;
				else if (countOfClearLine == 2) score += 300;
				else if (countOfClearLine == 3) score += 700;
				else if (countOfClearLine == 4) score += 1500;
				MoveDown(yMin, countOfClearLine);
			}
		}

		public void ClearLine(int y)
		{
			for (int i = pList.Count() - 1; i >= 0; i--)
			{
				if (pList[i].y == y)
				{
					pList[i].ClearColor();
					pList.RemoveAt(i);
				}
			}
		}

		public void MoveDown(int y, int topOffset)
		{
			Figure figureHigherY = new Figure();
			foreach (Point p in pList)
			{
				if (p.y < y)
				{
					p.Clear();
					p.Offset(0, topOffset);
					figureHigherY.pList.Add(p);
				}
			}
			foreach (CountPointInLine countPointInLine in countPointInLineList)
			{
				if (countPointInLine.y < y) countPointInLine.count = 0;
			}
			figureHigherY.Draw();
			foreach (Point p in figureHigherY.pList)
			{
				AddCountPointInLine(p);
			}
		}
	}
}