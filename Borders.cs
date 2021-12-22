namespace Tetris
{
	class Borders
	{
		List<Figure> bordersListToDraw;
		List<Figure> virtualBordersList;
		HorizontalLine downBorder;
		HorizontalLine topVirtualLineGameOver;
		public Borders(int mapWidth, int mapHeight)
		{
			bordersListToDraw = new List<Figure>();
			virtualBordersList = new List<Figure>();
			int maxHeightOfTetrisFigure = 4;
			topVirtualLineGameOver = new HorizontalLine(1, mapWidth + 1, maxHeightOfTetrisFigure - 1, '_');
			downBorder = new HorizontalLine(1, mapWidth + 1, mapHeight + maxHeightOfTetrisFigure, '_');
			VerticalLine leftVirtualBorder = new VerticalLine(0, mapHeight + maxHeightOfTetrisFigure, 0, '|');
			VerticalLine rightVirtualBorder = new VerticalLine(0, mapHeight + maxHeightOfTetrisFigure, mapWidth + 1, '|');
			VerticalLine leftBorder = new VerticalLine(maxHeightOfTetrisFigure, mapHeight + maxHeightOfTetrisFigure, 0, '|');
			VerticalLine rightBorder = new VerticalLine(maxHeightOfTetrisFigure, mapHeight + maxHeightOfTetrisFigure, mapWidth + 1, '|');

			bordersListToDraw.Add(downBorder);
			bordersListToDraw.Add(leftBorder);
			bordersListToDraw.Add(rightBorder);

			virtualBordersList.Add(downBorder);
			virtualBordersList.Add(leftVirtualBorder);
			virtualBordersList.Add(rightVirtualBorder);
		}

		public void Draw()
		{
			foreach (var border in bordersListToDraw)
			{
				border.Draw();
			}
		}

		internal bool IsHitDownBorder(TetrisFigure tetrisFigure)
		{
			if (downBorder.IsHit(tetrisFigure)) return true;
			else return false;
		}

		internal bool IsHitLineGameOver(TetrisFigure tetrisFigure)
		{
			if (topVirtualLineGameOver.IsHit(tetrisFigure)) return true;
			else return false;
		}


		internal bool IsHit(TetrisFigure tetrisFigure)
		{
			foreach (var border in virtualBordersList)
			{
				if (border.IsHit(tetrisFigure)) return true;
			}
			return false;
		}
	}
}