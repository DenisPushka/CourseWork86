namespace CourseWork86
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxMain = new PictureBox();
            SelectColorComboBox = new ComboBox();
            SelectTMOComboBox = new ComboBox();
            SelectFigureComboBox = new ComboBox();
            GTComboBox = new ComboBox();
            ButtonForTMO_ = new Button();
            PaintBZ = new Button();
            ToPaint = new Button();
            ButtonClear_ = new Button();
            DeleteFigure_ = new Button();
            TakeFigure = new CheckBox();
            Angle = new TextBox();
            label1 = new Label();
            numericForPolinom = new NumericUpDown();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericForPolinom).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxMain
            // 
            pictureBoxMain.BackColor = SystemColors.Window;
            pictureBoxMain.BorderStyle = BorderStyle.Fixed3D;
            pictureBoxMain.Dock = DockStyle.Left;
            pictureBoxMain.Location = new Point(0, 0);
            pictureBoxMain.Name = "pictureBoxMain";
            pictureBoxMain.Size = new Size(778, 568);
            pictureBoxMain.TabIndex = 0;
            pictureBoxMain.TabStop = false;
            pictureBoxMain.MouseDown += PictureMouseDown;
            pictureBoxMain.MouseMove += PictureBoxMouseMove;
            // 
            // SelectColorComboBox
            // 
            SelectColorComboBox.FormattingEnabled = true;
            SelectColorComboBox.Items.AddRange(new object[] { "Черный", "Красный", "Синий", "Зеленый" });
            SelectColorComboBox.Location = new Point(784, 12);
            SelectColorComboBox.Name = "SelectColorComboBox";
            SelectColorComboBox.Size = new Size(121, 23);
            SelectColorComboBox.TabIndex = 1;
            SelectColorComboBox.Text = "Цвет";
            SelectColorComboBox.SelectedIndexChanged += SelectColor;
            // 
            // SelectTMOComboBox
            // 
            SelectTMOComboBox.FormattingEnabled = true;
            SelectTMOComboBox.Items.AddRange(new object[] { "Объединение", "Пересечение", "Симметрическая разность", "Разность А/В", "Разность В/А" });
            SelectTMOComboBox.Location = new Point(953, 12);
            SelectTMOComboBox.Name = "SelectTMOComboBox";
            SelectTMOComboBox.Size = new Size(148, 23);
            SelectTMOComboBox.TabIndex = 2;
            SelectTMOComboBox.TabStop = false;
            SelectTMOComboBox.Text = "ТМО";
            SelectTMOComboBox.SelectedIndexChanged += SelectTMOComboBox_SelectedIndexChanged;
            // 
            // SelectFigureComboBox
            // 
            SelectFigureComboBox.FormattingEnabled = true;
            SelectFigureComboBox.Items.AddRange(new object[] { "Угл 2", "Ромб" });
            SelectFigureComboBox.Location = new Point(784, 71);
            SelectFigureComboBox.Name = "SelectFigureComboBox";
            SelectFigureComboBox.Size = new Size(121, 23);
            SelectFigureComboBox.TabIndex = 3;
            SelectFigureComboBox.Text = "Выбор фигуры";
            SelectFigureComboBox.SelectedIndexChanged += SelectFigure;
            // 
            // GTComboBox
            // 
            GTComboBox.FormattingEnabled = true;
            GTComboBox.Items.AddRange(new object[] { "Перемещение", "Поворот вокруг центра фигуры на 45 градусов", "Пропорциональное масштабирование относительно центра фигуры", "Зеркальное отражение относительно горизонтальной прямой" });
            GTComboBox.Location = new Point(784, 203);
            GTComboBox.Name = "GTComboBox";
            GTComboBox.Size = new Size(317, 23);
            GTComboBox.TabIndex = 4;
            GTComboBox.Text = "Геометрические преобразования";
            GTComboBox.SelectedIndexChanged += SelectGt;
            // 
            // ButtonForTMO_
            // 
            ButtonForTMO_.Location = new Point(953, 58);
            ButtonForTMO_.Name = "ButtonForTMO_";
            ButtonForTMO_.Size = new Size(148, 47);
            ButtonForTMO_.TabIndex = 5;
            ButtonForTMO_.Text = "Применить выбранное ТМО";
            ButtonForTMO_.UseVisualStyleBackColor = true;
            ButtonForTMO_.Click += ButtonForTMO__Click;
            // 
            // PaintBZ
            // 
            PaintBZ.Location = new Point(784, 128);
            PaintBZ.Name = "PaintBZ";
            PaintBZ.Size = new Size(121, 43);
            PaintBZ.TabIndex = 6;
            PaintBZ.Text = "Нарисовать кривую Безье";
            PaintBZ.UseVisualStyleBackColor = true;
            PaintBZ.Click += PaintBZ_Click;
            // 
            // ToPaint
            // 
            ToPaint.Location = new Point(953, 128);
            ToPaint.Name = "ToPaint";
            ToPaint.Size = new Size(148, 43);
            ToPaint.TabIndex = 7;
            ToPaint.Text = "Перейти в свободное рисование";
            ToPaint.UseVisualStyleBackColor = true;
            ToPaint.Click += ToPaint_Click;
            // 
            // ButtonClear_
            // 
            ButtonClear_.Location = new Point(784, 259);
            ButtonClear_.Name = "ButtonClear_";
            ButtonClear_.Size = new Size(121, 39);
            ButtonClear_.TabIndex = 8;
            ButtonClear_.Text = "Очистка экрана";
            ButtonClear_.UseVisualStyleBackColor = true;
            ButtonClear_.Click += ButtonClear__Click;
            // 
            // DeleteFigure_
            // 
            DeleteFigure_.Location = new Point(953, 259);
            DeleteFigure_.Name = "DeleteFigure_";
            DeleteFigure_.Size = new Size(148, 39);
            DeleteFigure_.TabIndex = 9;
            DeleteFigure_.Text = "Удаление фигуры";
            DeleteFigure_.UseVisualStyleBackColor = true;
            DeleteFigure_.Click += DeleteFigure__Click;
            // 
            // TakeFigure
            // 
            TakeFigure.AutoSize = true;
            TakeFigure.Location = new Point(788, 361);
            TakeFigure.Name = "TakeFigure";
            TakeFigure.Size = new Size(117, 19);
            TakeFigure.TabIndex = 10;
            TakeFigure.Text = "Фигура выбрана";
            TakeFigure.UseVisualStyleBackColor = true;
            // 
            // Angle
            // 
            Angle.Location = new Point(953, 322);
            Angle.Name = "Angle";
            Angle.Size = new Size(100, 23);
            Angle.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(794, 325);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 12;
            label1.Text = "Угол поворота";
            // 
            // numericForPolinom
            // 
            numericForPolinom.Location = new Point(788, 419);
            numericForPolinom.Maximum = new decimal(new int[] { 250, 0, 0, 0 });
            numericForPolinom.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            numericForPolinom.Name = "numericForPolinom";
            numericForPolinom.Size = new Size(120, 23);
            numericForPolinom.TabIndex = 13;
            numericForPolinom.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(784, 401);
            label2.Name = "label2";
            label2.Size = new Size(218, 15);
            label2.TabIndex = 14;
            label2.Text = "Размер ребра для создания полинома";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MintCream;
            ClientSize = new Size(1110, 568);
            Controls.Add(label2);
            Controls.Add(numericForPolinom);
            Controls.Add(label1);
            Controls.Add(Angle);
            Controls.Add(TakeFigure);
            Controls.Add(DeleteFigure_);
            Controls.Add(ButtonClear_);
            Controls.Add(ToPaint);
            Controls.Add(PaintBZ);
            Controls.Add(ButtonForTMO_);
            Controls.Add(GTComboBox);
            Controls.Add(SelectFigureComboBox);
            Controls.Add(SelectTMOComboBox);
            Controls.Add(SelectColorComboBox);
            Controls.Add(pictureBoxMain);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Курсовая работа";
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericForPolinom).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxMain;
        private ComboBox SelectColorComboBox;
        private ComboBox SelectTMOComboBox;
        private ComboBox SelectFigureComboBox;
        private ComboBox GTComboBox;
        private Button ButtonForTMO_;
        private Button PaintBZ;
        private Button ToPaint;
        private Button ButtonClear_;
        private Button DeleteFigure_;
        private CheckBox TakeFigure;
        private TextBox Angle;
        private Label label1;
        private NumericUpDown numericForPolinom;
        private Label label2;
    }
}