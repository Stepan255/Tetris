namespace Tetris
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Clear();
			Borders borders = new Borders(10, 20);
			borders.Draw();
			InstalledFigure installedFigure = new InstalledFigure(10, 20);
			bool gameOver = false;
			while (!gameOver)
			{
				installedFigure.CheckLine();
				TetrisFigure tetrisFigure = new TetrisFigure(TetrisFigure.RandomFigure(6), TetrisFigure.RandomRotate());
				tetrisFigure.Offset(4, 0);
				tetrisFigure.Draw();
				while (true)
				{
					int timeStep = 200;
					while (timeStep > 0)
					{
						if (Console.KeyAvailable)
						{
							ConsoleKeyInfo key = Console.ReadKey();
							if (key.Key == ConsoleKey.UpArrow)
							{
								TetrisFigure tetrisFigureWhithRotate = tetrisFigure.DegreeRotation90();
								if (!borders.IsHit(tetrisFigureWhithRotate) && !installedFigure.IsHit(tetrisFigureWhithRotate))
									tetrisFigure = tetrisFigure.RewriteOn(tetrisFigureWhithRotate);
							}
							else if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.LeftArrow)
							{
								TetrisFigure FigureMove = tetrisFigure.HorizontalMove(key.Key);
								if (!borders.IsHit(FigureMove) && !installedFigure.IsHit(FigureMove))
									tetrisFigure = tetrisFigure.RewriteOn(FigureMove);
							}
							else if (key.Key == ConsoleKey.DownArrow) timeStep = 0;
						}
						int timeToSleep = 10;
						timeStep -= timeToSleep;
						Thread.Sleep(timeToSleep);
					}
					TetrisFigure tetrisFigureMove = tetrisFigure.VerticalMove();
					if (!borders.IsHitDownBorder(tetrisFigureMove) && !installedFigure.IsHit(tetrisFigureMove))
						tetrisFigure = tetrisFigure.RewriteOn(tetrisFigureMove);
					else
					{
						if (borders.IsHitLineGameOver(tetrisFigure)) gameOver = true;
						else installedFigure.Add(tetrisFigure);
						break;
					}

				}
			}

		}
	}
}