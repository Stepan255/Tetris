namespace Tetris
{
	class TetrisFigure : Figure
	{
		public Select select;
		public Rotate rotate;
		protected int offsetLeft;
		protected int offsetTop;
		static int maxRotate = 4;

		public static Select RandomFigure(int numberOfFigures)
		{
			int figureNamber = new Random().Next(0, numberOfFigures);
			return (Select)Enum.GetValues(typeof(Select)).GetValue(figureNamber);
		}

		public static Rotate RandomRotate()
		{
			int figureNamber = new Random().Next(0, maxRotate);
			return (Rotate)Enum.GetValues(typeof(Rotate)).GetValue(figureNamber);
		}

		public TetrisFigure(Select select, Rotate rotate)
		{
			offsetLeft = 0;
			offsetTop = 0;
			this.select = select;
			this.rotate = rotate;
			pList = new List<Point>();
			if (select == Select.O) FigureO();
			else if (select == Select.I) FigureI(rotate);
			else if (select == Select.S) FigureS(rotate);
			else if (select == Select.Z) FigureZ(rotate);
			else if (select == Select.L) FigureL(rotate);
			else if (select == Select.J) FigureJ(rotate);
		}

		public TetrisFigure DegreeRotation90()
		{
				int indexOfRotate = Array.IndexOf(Enum.GetValues(rotate.GetType()), rotate);
				if (indexOfRotate + 1 < maxRotate) indexOfRotate += 1;
				else indexOfRotate = 0;
				Rotate newRotate = (Rotate)Enum.GetValues(typeof(Rotate)).GetValue(indexOfRotate);
				TetrisFigure tetrisFigureWhithRotate = new TetrisFigure(select, newRotate);
				tetrisFigureWhithRotate.Offset(offsetLeft, offsetTop);
				return tetrisFigureWhithRotate;
		}

		public TetrisFigure HorizontalMove(ConsoleKey key)
		{
			int movement = 0;
			if (key == ConsoleKey.RightArrow) movement = 1;
			else if (key == ConsoleKey.LeftArrow) movement = -1;
			TetrisFigure tetrisFigureWhithMove = new TetrisFigure(select, rotate);
			tetrisFigureWhithMove.Offset(offsetLeft, offsetTop);
			tetrisFigureWhithMove.Offset(movement, 0);
			return tetrisFigureWhithMove;
		}

		public TetrisFigure VerticalMove()
		{
			TetrisFigure tetrisFigureWhithMove = new TetrisFigure(select, rotate);
			tetrisFigureWhithMove.Offset(offsetLeft, offsetTop);
			tetrisFigureWhithMove.Offset(0, 1);
			return tetrisFigureWhithMove;
		}

		public TetrisFigure RewriteOn(TetrisFigure figure)
		{
			foreach (Point p in pList)
			{
				if (!figure.IsHit(p))
					p.Clear();
			}
			foreach (Point p in figure.pList)
			{
				if (!IsHit(p))
					p.Draw();
			}
			select = figure.select;
			rotate = figure.rotate;
			return figure;
		}

		internal void Offset(int left, int top)
		{
			offsetLeft += left;
			offsetTop += top;
			foreach (Point p in pList)
			{
				p.Offset(left, top);
			}
		}

		public void AddPointFigure(int x, int y)
		{
			Point p = new Point(x, y, '█');
			pList.Add(p);
		}

		public void FigureO()
		{
			AddPointFigure(1, 2);
			AddPointFigure(2, 2);
			AddPointFigure(1, 3);
			AddPointFigure(2, 3);
		}

		public void FigureI(Rotate rotate)
		{
			if (rotate == Rotate.degree0 || rotate == Rotate.degree180)
			{
				AddPointFigure(1, 0);
				AddPointFigure(1, 1);
				AddPointFigure(1, 2);
				AddPointFigure(1, 3);
			}else if (rotate == Rotate.degree90 || rotate == Rotate.degree270)
			{
				AddPointFigure(0, 2);
				AddPointFigure(1, 2);
				AddPointFigure(2, 2);
				AddPointFigure(3, 2);
			}
		}

		public void FigureS(Rotate rotate)
		{
			if (rotate == Rotate.degree0 || rotate == Rotate.degree180)
			{
				AddPointFigure(0, 2);
				AddPointFigure(1, 2);
				AddPointFigure(1, 3);
				AddPointFigure(2, 3);
			}else if (rotate == Rotate.degree90 || rotate == Rotate.degree270)
			{
				AddPointFigure(1, 1);
				AddPointFigure(1, 2);
				AddPointFigure(0, 2);
				AddPointFigure(0, 3);
			}
		}

		public void FigureZ(Rotate rotate)
		{
			if (rotate == Rotate.degree0 || rotate == Rotate.degree180)
			{
				AddPointFigure(0, 3);
				AddPointFigure(1, 2);
				AddPointFigure(1, 3);
				AddPointFigure(2, 2);
			}else if (rotate == Rotate.degree90 || rotate == Rotate.degree270)
			{
				AddPointFigure(0, 1);
				AddPointFigure(0, 2);
				AddPointFigure(1, 2);
				AddPointFigure(1, 3);
			}
		}

		public void FigureL(Rotate rotate)
		{
			if (rotate == Rotate.degree0)
			{
				AddPointFigure(1, 1);
				AddPointFigure(1, 2);
				AddPointFigure(1, 3);
				AddPointFigure(2, 3);
			}else if (rotate == Rotate.degree90)
			{
				AddPointFigure(0, 3);
				AddPointFigure(1, 3);
				AddPointFigure(2, 3);
				AddPointFigure(2, 2);
			}else if (rotate == Rotate.degree180)
			{
				AddPointFigure(1, 1);
				AddPointFigure(2, 1);
				AddPointFigure(2, 2);
				AddPointFigure(2, 3);
			}else if (rotate == Rotate.degree270)
			{
				AddPointFigure(0, 2);
				AddPointFigure(0, 3);
				AddPointFigure(1, 2);
				AddPointFigure(2, 2);
			}
		}

		public void FigureJ(Rotate rotate)
		{
			if (rotate == Rotate.degree0)
			{
				AddPointFigure(1, 1);
				AddPointFigure(1, 2);
				AddPointFigure(1, 3);
				AddPointFigure(0, 3);
			}else if (rotate == Rotate.degree90)
			{
				AddPointFigure(0, 2);
				AddPointFigure(0, 3);
				AddPointFigure(1, 3);
				AddPointFigure(2, 3);
			}else if (rotate == Rotate.degree180)
			{
				AddPointFigure(0, 1);
				AddPointFigure(1, 1);
				AddPointFigure(0, 2);
				AddPointFigure(0, 3);
			}else if (rotate == Rotate.degree270)
			{
				AddPointFigure(0, 2);
				AddPointFigure(1, 2);
				AddPointFigure(2, 2);
				AddPointFigure(2, 3);
			}
		}

	}
}