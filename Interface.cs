namespace Tetris
{
	class Interface
	{
		public int score;
		int topForScore;
		int topForNextFigure;
		int left;
		TetrisFigure nextFigure;
		public Interface(int mapWidth, TetrisFigure nextFigure)
		{
			this.nextFigure = nextFigure;
			score = 0;
			topForScore = 1;
			topForNextFigure = 5;
			left = mapWidth + 5;
		}

		public void Draw()
		{
			Console.SetCursorPosition(left, topForScore);
			Console.Write(score);
			Console.SetCursorPosition(left, topForNextFigure - 1);
			Console.Write("Следующая фигура:");
			nextFigure.Offset(left, topForNextFigure);
			nextFigure.Draw();
		}

		public void RewriteFigure(TetrisFigure tetrisFigure)
		{
			nextFigure.Clear();
			nextFigure = tetrisFigure;
			nextFigure.Offset(left, topForNextFigure);
			nextFigure.Draw();
		}

		public void ReWriteScore(int newScore)
		{
			if (score != newScore)
			{
				{
					for (int i = 0; i < score.ToString().Length; i++)
					{
						Console.SetCursorPosition(left + i, topForScore);
						Console.Write(' ');
					}
					Console.SetCursorPosition(left, topForScore);
					score = newScore;
					Console.Write(score);
				}
			}
		}

		public static void WriteGameOver(string textGameOver, string textScore, int mapWidth, int mapHeight)
		{
			Console.SetCursorPosition(mapWidth / 2, mapHeight / 2 - 2);
			Console.Write(textGameOver);
			Console.SetCursorPosition(mapWidth / 2, mapHeight / 2 - 1);
			Console.Write(textScore);
			Console.SetCursorPosition(mapWidth / 2, mapHeight / 2);
			Console.Write("Для начала нажмите ENTER");
			Console.SetCursorPosition(mapWidth / 2, mapHeight / 2 + 1);
			Console.Write("Для выхода из программы нажмите ESC");
		}
	}
}