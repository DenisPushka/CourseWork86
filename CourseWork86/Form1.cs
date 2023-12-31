namespace CourseWork86
{
    /// <summary>
    /// ������� �����.
    /// </summary>
    public partial class Form1: Form
    {
        private readonly Graphics _graphics;
        private readonly Pen _drawPen = new(Color.Black, 1);
        private Figure _figure;

        /// <summary>
        /// ��������� ��� ���
        /// </summary>
        private int[] _setQ = new int[2];

        /// <summary>
        /// ������ �����
        /// </summary>
        private readonly List<Figure> _figures = new();

        /// <summary>
        /// �����
        /// </summary>
        private readonly Bitmap _bitmap;

        /// <summary>
        /// ����� �������������� ��������
        /// </summary>
        private int _operation;

        #region For move figure

        private bool _checkFigure;
        private Point _pictureBoxMousePosition;
        private Figure _figureForMove;

        #endregion

        public Form1()
        {
            InitializeComponent();
            _bitmap = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
            _graphics = Graphics.FromImage(_bitmap);
            _figure = new Figure(pictureBoxMain.Width, pictureBoxMain.Height, _graphics, _drawPen, _drawPen.Color);
            _operation = -1;
            MouseWheel += GeometricTransformation;
        }

        /// <summary>
        /// ���������� ������� "������� ����"
        /// </summary>
        private void PictureMouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxMousePosition = e.Location;
            switch (_operation)
            {
                // ��������
                case -3:
                    if (SearchSelectFigure(e))
                    {
                        if (_figures.Any(figure => figure == _figureForMove))
                        {
                            _figures.Remove(_figureForMove);
                        }
                    }
                    else
                        _checkFigure = false;

                    break;
                // ���������
                // ��������� ���������
                case -2:
                    switch (SelectFigureComboBox.SelectedIndex)
                    {
                        case 0:
                            CreateUgle2(e);
                            break;
                        case 1:
                            CreateRhomb(e);
                            break;
                    }

                    _figure.Color = _drawPen.Color;
                    _figure.DrawPen = _drawPen;
                    _figures.Add(_figure.Cloning());
                    _figure = new Figure(pictureBoxMain.Width, pictureBoxMain.Height, _graphics,
                        new Pen(_drawPen.Color), _drawPen.Color);
                    break;
                // ���������� �����
                case -1 when e.Button == MouseButtons.Left:
                    {
                        _figure.AddVertex(e.X, e.Y);
                        break;
                    }
                // �������� ������
                case -1 when e.Button == MouseButtons.Right:
                    {
                        _figure.DrawPen = _drawPen;
                        _figures.Add(_figure.Cloning());
                        _figure = new Figure(pictureBoxMain.Width, pictureBoxMain.Height, _graphics,
                            new Pen(_drawPen.Color), _drawPen.Color);
                        break;
                    }
                // �����������
                case 0:
                    if (SearchSelectFigure(e))
                    {
                        _graphics.DrawEllipse(new Pen(Color.Blue), e.X - 2, e.Y - 2, 10, 10);
                        _checkFigure = true;
                    }
                    else
                        _checkFigure = false;

                    break;
            }

            if (SearchSelectFigure(e))
            {
                TakeFigure.Checked = true;
            }

            Render();
        }

        /// <summary>
        /// ���������.
        /// </summary>
        private void Render()
        {
            _graphics.Clear(Color.White);

            if (_operation == -1)
            {
                _figure.PaintingLineInFigure();
            }

            foreach (var fig in _figures)
            {
                if (!fig.IsHaveTmo)
                {
                    fig.Fill();
                }
                else
                {
                    Tmo(fig, fig.ConnectAfterTmo);
                }
            }

            pictureBoxMain.Image = _bitmap;
        }

        /// <summary>
        /// ���������� ������� "������� ����".
        /// </summary>
        private void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _operation == 0 & _checkFigure)
            {
                Render();

                if (_figureForMove.IsHaveTmo)
                {
                    _figureForMove.Move(e.X - _pictureBoxMousePosition.X, e.Y - _pictureBoxMousePosition.Y);
                    _figureForMove.ConnectAfterTmo.Move(e.X - _pictureBoxMousePosition.X,
                        e.Y - _pictureBoxMousePosition.Y);

                    Tmo(_figureForMove, _figureForMove.ConnectAfterTmo);
                    pictureBoxMain.Image = _bitmap;
                }
                else
                {
                    _figureForMove.Move(e.X - _pictureBoxMousePosition.X, e.Y - _pictureBoxMousePosition.Y);
                }

                _pictureBoxMousePosition = e.Location;
            }
        }

        /// <summary>
        /// ���������� ������� �� ������������� �������� ��� �������������� ���������������.
        /// </summary>
        private void GeometricTransformation(object sender, MouseEventArgs e)
        {
            if (_figures.Count == 0 || !TakeFigure.Checked)
            {
                return;
            }

            if (_figureForMove.IsHaveTmo)
            {
                OperationGeometric(_figureForMove, e);
                OperationGeometric(_figureForMove.ConnectAfterTmo, e);
                PaintTmo(_figureForMove);
            }
            else
                OperationGeometric(_figureForMove, e);

            Render();
        }

        /// <summary>
        /// ��� ��� 2 ��������.
        /// </summary>
        private void PaintTmo(Figure figureBuff)
        {
            figureBuff.DrawPen.Color = figureBuff.Color =
                figureBuff.ConnectAfterTmo.DrawPen.Color = figureBuff.ConnectAfterTmo.Color = Color.White;

            Tmo(figureBuff, figureBuff.ConnectAfterTmo);
        }

        /// <summary>
        /// �������������� ��������������.
        /// </summary>
        private void OperationGeometric(Figure figureBuff, MouseEventArgs e)
        {
            switch (_operation)
            {
                // ��������.
                case 1:
                    figureBuff.Rotation(e.Delta, Angle);
                    break;
                // ���������������.
                case 2:
                    figureBuff.Zoom(e.Delta);
                    break;
                // ���������.
                case 3:
                    figureBuff.Mirror(e);
                    break;
            }

            Render();
        }

        /// <summary>
        /// ����� ������������ �����. ���� ���� ��������� �����, �� ������������ ������ ������������ ������.
        /// </summary>
        /// <param name="figure">�������� ������.</param>
        /// <returns>������, ������� ����� ����������� � �������, ���������� � ��������. ���� ����� ���, �� ������������ null/</returns>
        private Figure? SearchIntersection(Figure figure)
        {
            foreach (var t in _figures)
                if (CheckInputVertexFirstFigureToSecondFigure(figure, t)
                    || CheckInputVertexFirstFigureToSecondFigure(t, figure))
                {
                    if (figure.Equals(t))
                        continue;
                    return t;
                }

            return null;
        }

        /// <summary>
        /// �������� ��������� �������1 � ������� 2 �� ��������� ������ ������1 � ������ 2
        /// </summary>
        /// <param name="figureOne">������ 1</param>
        /// <param name="figureSecond">������ 2</param>
        private static bool CheckInputVertexFirstFigureToSecondFigure(Figure figureOne, Figure figureSecond) =>
            figureOne.Vertexes
                .Any(vertex => figureSecond
                    .ThisFigure((int)vertex.X, (int)vertex.Y));

        /// <summary>
        /// ����� ������ � ���������� <paramref name="e"/>.
        /// </summary>
        /// <param name="e">���������� ����.</param>
        /// <returns>True - � ������ ������.</returns>
        private bool SearchSelectFigure(MouseEventArgs e)
        {
            for (var index = 0; index < _figures.Count; index++)
                if (_figures[index].ThisFigure(e.X, e.Y))
                {
                    _figureForMove = _figures[index];
                    _figureForMove.IndexMove = index;
                    return true;
                }

            return false;
        }

        private void SelectFigure(object sender, EventArgs e) => _operation = -2;

        private void SelectGt(object sender, EventArgs e) => _operation = GTComboBox.SelectedIndex;

        /// <summary>
        /// ���������� ������� ������� �� ������ "������� � ��������� ���������".
        /// </summary>
        private void ToPaint_Click(object sender, EventArgs e) => _operation = -1;

        /// <summary>
        /// ���������� �������, ����� �����.
        /// </summary>
        private void SelectColor(object sender, EventArgs e) =>
            _drawPen.Color = SelectColorComboBox.SelectedIndex switch
            {
                0 => Color.Black,
                1 => Color.Red,
                2 => Color.Blue,
                3 => Color.Green,
                _ => _drawPen.Color
            };

        #region ���������� ����� � �������

        /// <summary>
        /// �������� ������ - "��� 2".
        /// </summary>
        private void CreateUgle2(MouseEventArgs e)
        {
            var size = (float)numericForPolinom.Value;
            _figure.Vertexes = new List<Vertex>
            {
                new(e.X - size, e.Y - size),
                new(e.X, e.Y - size),
                new(e.X, e.Y),
                new(e.X + size, e.Y),
                new(e.X + size, e.Y + size),
                new(e.X - size, e.Y + size),
            };
        }

        /// <summary>
        /// �������� ������ - "����".
        /// </summary>
        private void CreateRhomb(MouseEventArgs e)
        {
            var size = (float)numericForPolinom.Value;
            _figure.Vertexes = new List<Vertex>
            {
                new Vertex(e.X - size, e.Y),
                new Vertex(e.X, e.Y - size),
                new Vertex(e.X + size, e.Y),
                new Vertex(e.X, e.Y + size),
            };
        }

        /// <summary>
        /// ������ �����.
        /// </summary>
        private void DrawBezier()
        {
            const double dt = 0.01;
            var t = dt;
            var listVertexes = _figure.Vertexes.ToList();
            double xPred = listVertexes[0].X;
            double yPred = listVertexes[0].Y;
            var newFigure = new List<Vertex>();
            while (t < 1)
            {
                double x = 0;
                double y = 0;

                for (var i = 0; i < listVertexes.Count; i++)
                {
                    var b = Polinom(i, listVertexes.Count - 1, (float)t);
                    x += listVertexes[i].X * b;
                    y += listVertexes[i].Y * b;
                }

                newFigure.Add(new Vertex((float)x, (float)y));
                _graphics.DrawLine(_drawPen, new Point((int)xPred, (int)yPred), new Point((int)x, (int)y));
                t += dt;
                xPred = x;
                yPred = y;
            }

            _figure.IsFunction = true;
            _figure.Vertexes = newFigure;
        }

        /// <summary>
        /// ���������� ��������.
        /// </summary>
        private static double Polinom(int i, int n, float t) =>
            Factorial(n) / (Factorial(i) * Factorial(n - i))
            * (float)Math.Pow(t, i) *
            (float)Math.Pow(1 - t, n - i);

        /// <summary>
        /// ���������� ����������.
        /// </summary>
        /// <param name="n">�� ���� �������.</param>
        /// <returns>����������� ���������.</returns>
        private static double Factorial(int n)
        {
            double x = 1;
            for (var i = 1; i <= n; i++)
                x *= i;

            return x;
        }

        #endregion

        private void PaintBZ_Click(object sender, EventArgs e)
        {
            if (_figure.Vertexes.Count >= 3)
            {
                // �������� ��� �������
                DrawBezier();

                // ���������� ��� � ������ �����.
                _figure.IsFunction = true;
                _figures.Add(_figure.Cloning());
                _figure = new Figure(pictureBoxMain.Width, pictureBoxMain.Height, _graphics, _drawPen, _drawPen.Color);

                Render();
            }
        }

        /// <summary>
        /// ���������� ������� ������� �� ������ "������� ������".
        /// </summary>
        private void ButtonClear__Click(object sender, EventArgs e)
        {
            _figures.Clear();
            _figure = new Figure(pictureBoxMain.Width, pictureBoxMain.Height, _graphics, new Pen(_drawPen.Color),
                _drawPen.Color);
            pictureBoxMain.Image = _bitmap;
            _graphics.Clear(Color.White);
            _operation = -1;
        }

        /// <summary>
        /// ���������� ������� ������� �� ������ "�������� ������".
        /// </summary>
        private void DeleteFigure__Click(object sender, EventArgs e) => _operation = -3;

        #region ���

        /// <summary>
        /// �������� ���������-������������� ��������
        /// </summary>
        /// <param name="figure1">������ ������ ��� ���.</param>
        /// <param name="figure2">������ ������ ��� ���.</param>
        private void Tmo(Figure figure1, Figure figure2)
        {
            var arr = figure1.SearchYMinAndMax();
            var arr2 = figure2.SearchYMinAndMax();

            figure1.IsHaveTmo = figure2.IsHaveTmo = true;
            var minY = arr[0] < arr2[0] ? arr[0] : arr2[0];
            var maxY = arr[1] > arr2[1] ? arr[1] : arr2[1];

            for (var y = (int)minY; y < maxY; y++)
            {
                var a = figure1.CalculationListXrAndXl(y);
                var xAl = a[0];
                var xAr = a[1];
                var b = figure2.CalculationListXrAndXl(y);
                var xBl = b[0];
                var xBr = b[1];
                if (xAl.Count == 0 && xBl.Count == 0)
                    continue;

                #region ���������� ������� arrayM

                var arrayM = new M[xAl.Count * 2 + xBl.Count * 2];
                for (var i = 0; i < xAl.Count; i++)
                    arrayM[i] = new M(xAl[i], 2);

                var nM = xAl.Count;
                for (var i = 0; i < xAr.Count; i++)
                    arrayM[nM + i] = new M(xAr[i], -2);

                nM += xAr.Count;
                for (var i = 0; i < xBl.Count; i++)
                    arrayM[nM + i] = new M(xBl[i], 1);

                nM += xBl.Count;
                for (var i = 0; i < xBr.Count; i++)
                    arrayM[nM + i] = new M(xBr[i], -1);
                nM += xBr.Count;

                #endregion

                // ����������.
                SortArrayM(arrayM);

                var q = 0;
                var xrl = new List<int>();
                var xrr = new List<int>();

                // ������ ������ ��� ������ ������� ��������.
                if (arrayM[0].X >= 0 && arrayM[0].Dq < 0)
                {
                    xrl.Add(0);
                    q = -arrayM[1].Dq;
                }

                for (var i = 0; i < nM; i++)
                {
                    var x = arrayM[i].X;
                    var qNew = q + arrayM[i].Dq;
                    if (!IncludeQInSetQ(q) && IncludeQInSetQ(qNew))
                        xrl.Add((int)x);
                    else if (IncludeQInSetQ(q) && !IncludeQInSetQ(qNew))
                        xrr.Add((int)x);

                    q = qNew;
                }

                // ���� �� ������� ������ ������� ���������� ��������.
                if (IncludeQInSetQ(q))
                    xrr.Add(pictureBoxMain.Height);

                for (var i = 0; i < xrr.Count; i++)
                    _graphics.DrawLine(_drawPen, new Point(xrr[i], y), new Point(xrl[i], y));
            }
        }

        /// <summary>
        /// �������� ��������� Q � ��������� setQ.
        /// </summary>
        /// <param name="q">����������� �����.</param>
        /// <returns>True - � ������ ������.</returns>
        private bool IncludeQInSetQ(int q) => _setQ[0] <= q && q <= _setQ[1];

        /// <summary>
        /// ���������� �� �.
        /// </summary>
        private static void SortArrayM(IList<M> arrayM)
        {
            for (var write = 0; write < arrayM.Count; write++)
                for (var sort = 0; sort < arrayM.Count - 1; sort++)
                    if (arrayM[sort].X > arrayM[sort + 1].X)
                    {
                        var buff = new M(arrayM[sort + 1].X, arrayM[sort + 1].Dq);
                        arrayM[sort + 1] = arrayM[sort];
                        arrayM[sort] = buff;
                    }
        }

        /// <summary>
        /// ���������� ������� ������� �� ������ "��������� ��������� ���".
        /// </summary>
        private void ButtonForTMO__Click(object sender, EventArgs e)
        {
            if (_figures.Count > 1 && TakeFigure.Checked)
            {
                var secondFigure = SearchIntersection(_figureForMove);

                if (secondFigure == null || secondFigure.IsHaveTmo)
                {
                    return;
                }

                _figureForMove.Color = secondFigure.Color = Color.White;
                _figureForMove.Fill();
                secondFigure.Fill();

                Tmo(_figureForMove, secondFigure);
                _figureForMove.ConnectAfterTmo = secondFigure;
                secondFigure.ConnectAfterTmo = _figureForMove;
            }

            pictureBoxMain.Image = _bitmap;
        }

        /// <summary>
        /// ����� ���.
        /// </summary>
        private void SelectTMOComboBox_SelectedIndexChanged(object sender, EventArgs e) =>
            _setQ = SelectTMOComboBox.SelectedIndex switch
            {
                0 => new[] { 1, 3 }, // �����������.
                1 => new[] { 3, 3 }, // �����������.
                2 => new[] { 1, 2 }, // ������������ ��������.
                3 => new[] { 2, 2 }, // �������� �/�.
                4 => new[] { 1, 1 }, // �������� �/�.
                _ => _setQ
            };

        #endregion
    }
}