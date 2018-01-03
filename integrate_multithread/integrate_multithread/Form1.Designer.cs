namespace integrate_multithread
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnSettings = new System.Windows.Forms.Panel();
            this.tbThreadsNum = new System.Windows.Forms.NumericUpDown();
            this.gbGridType = new System.Windows.Forms.GroupBox();
            this.rbIrregular = new System.Windows.Forms.RadioButton();
            this.rbRegular = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAccuracy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClearResults = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.cbFunction = new System.Windows.Forms.ComboBox();
            this.lbFunction = new System.Windows.Forms.Label();
            this.tbLowerLimit = new System.Windows.Forms.TextBox();
            this.tbUpperLimit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbIntMethod = new System.Windows.Forms.GroupBox();
            this.rbSimpson = new System.Windows.Forms.RadioButton();
            this.rbTrapezoidal = new System.Windows.Forms.RadioButton();
            this.rbRectangle = new System.Windows.Forms.RadioButton();
            this.dgResults = new System.Windows.Forms.DataGridView();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.ThreadNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntegralValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.pnSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbThreadsNum)).BeginInit();
            this.gbGridType.SuspendLayout();
            this.gbIntMethod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(763, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // pnSettings
            // 
            this.pnSettings.Controls.Add(this.tbThreadsNum);
            this.pnSettings.Controls.Add(this.gbGridType);
            this.pnSettings.Controls.Add(this.label3);
            this.pnSettings.Controls.Add(this.tbAccuracy);
            this.pnSettings.Controls.Add(this.label2);
            this.pnSettings.Controls.Add(this.btnClearResults);
            this.pnSettings.Controls.Add(this.btnSolve);
            this.pnSettings.Controls.Add(this.cbFunction);
            this.pnSettings.Controls.Add(this.lbFunction);
            this.pnSettings.Controls.Add(this.tbLowerLimit);
            this.pnSettings.Controls.Add(this.tbUpperLimit);
            this.pnSettings.Controls.Add(this.label1);
            this.pnSettings.Controls.Add(this.gbIntMethod);
            this.pnSettings.Location = new System.Drawing.Point(563, 27);
            this.pnSettings.Name = "pnSettings";
            this.pnSettings.Size = new System.Drawing.Size(200, 478);
            this.pnSettings.TabIndex = 2;
            // 
            // tbThreadsNum
            // 
            this.tbThreadsNum.Location = new System.Drawing.Point(3, 365);
            this.tbThreadsNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbThreadsNum.Name = "tbThreadsNum";
            this.tbThreadsNum.Size = new System.Drawing.Size(188, 20);
            this.tbThreadsNum.TabIndex = 11;
            this.tbThreadsNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gbGridType
            // 
            this.gbGridType.Controls.Add(this.rbIrregular);
            this.gbGridType.Controls.Add(this.rbRegular);
            this.gbGridType.Location = new System.Drawing.Point(3, 211);
            this.gbGridType.Name = "gbGridType";
            this.gbGridType.Size = new System.Drawing.Size(188, 66);
            this.gbGridType.TabIndex = 3;
            this.gbGridType.TabStop = false;
            this.gbGridType.Text = "Сетка";
            // 
            // rbIrregular
            // 
            this.rbIrregular.AutoSize = true;
            this.rbIrregular.Location = new System.Drawing.Point(6, 42);
            this.rbIrregular.Name = "rbIrregular";
            this.rbIrregular.Size = new System.Drawing.Size(107, 17);
            this.rbIrregular.TabIndex = 1;
            this.rbIrregular.Text = "Неравномерная";
            this.rbIrregular.UseVisualStyleBackColor = true;
            // 
            // rbRegular
            // 
            this.rbRegular.AutoSize = true;
            this.rbRegular.Checked = true;
            this.rbRegular.Location = new System.Drawing.Point(6, 19);
            this.rbRegular.Name = "rbRegular";
            this.rbRegular.Size = new System.Drawing.Size(94, 17);
            this.rbRegular.TabIndex = 0;
            this.rbRegular.TabStop = true;
            this.rbRegular.Text = "Равномерная";
            this.rbRegular.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Число потоков";
            // 
            // tbAccuracy
            // 
            this.tbAccuracy.Location = new System.Drawing.Point(3, 315);
            this.tbAccuracy.Name = "tbAccuracy";
            this.tbAccuracy.Size = new System.Drawing.Size(188, 20);
            this.tbAccuracy.TabIndex = 9;
            this.tbAccuracy.Text = "0,00001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Точность";
            // 
            // btnClearResults
            // 
            this.btnClearResults.Location = new System.Drawing.Point(116, 409);
            this.btnClearResults.Name = "btnClearResults";
            this.btnClearResults.Size = new System.Drawing.Size(75, 28);
            this.btnClearResults.TabIndex = 7;
            this.btnClearResults.Text = "Очистить";
            this.btnClearResults.UseVisualStyleBackColor = true;
            this.btnClearResults.Click += new System.EventHandler(this.btnClearResults_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(3, 409);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 28);
            this.btnSolve.TabIndex = 6;
            this.btnSolve.Text = "Вычислить";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // cbFunction
            // 
            this.cbFunction.FormattingEnabled = true;
            this.cbFunction.Items.AddRange(new object[] {
            "sin(x)",
            "e^x",
            "1/(x*e^x)",
            "1/ln(x)"});
            this.cbFunction.Location = new System.Drawing.Point(3, 25);
            this.cbFunction.Name = "cbFunction";
            this.cbFunction.Size = new System.Drawing.Size(188, 21);
            this.cbFunction.TabIndex = 5;
            // 
            // lbFunction
            // 
            this.lbFunction.AutoSize = true;
            this.lbFunction.Location = new System.Drawing.Point(6, 9);
            this.lbFunction.Name = "lbFunction";
            this.lbFunction.Size = new System.Drawing.Size(53, 13);
            this.lbFunction.TabIndex = 4;
            this.lbFunction.Text = "Функция";
            // 
            // tbLowerLimit
            // 
            this.tbLowerLimit.Location = new System.Drawing.Point(3, 72);
            this.tbLowerLimit.Name = "tbLowerLimit";
            this.tbLowerLimit.Size = new System.Drawing.Size(45, 20);
            this.tbLowerLimit.TabIndex = 3;
            this.tbLowerLimit.Text = "0,000001";
            // 
            // tbUpperLimit
            // 
            this.tbUpperLimit.Location = new System.Drawing.Point(75, 72);
            this.tbUpperLimit.Name = "tbUpperLimit";
            this.tbUpperLimit.Size = new System.Drawing.Size(45, 20);
            this.tbUpperLimit.TabIndex = 2;
            this.tbUpperLimit.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Отрезок интегрирования";
            // 
            // gbIntMethod
            // 
            this.gbIntMethod.Controls.Add(this.rbSimpson);
            this.gbIntMethod.Controls.Add(this.rbTrapezoidal);
            this.gbIntMethod.Controls.Add(this.rbRectangle);
            this.gbIntMethod.Location = new System.Drawing.Point(3, 115);
            this.gbIntMethod.Name = "gbIntMethod";
            this.gbIntMethod.Size = new System.Drawing.Size(188, 90);
            this.gbIntMethod.TabIndex = 0;
            this.gbIntMethod.TabStop = false;
            this.gbIntMethod.Text = "Метод";
            // 
            // rbSimpson
            // 
            this.rbSimpson.AutoSize = true;
            this.rbSimpson.Location = new System.Drawing.Point(6, 65);
            this.rbSimpson.Name = "rbSimpson";
            this.rbSimpson.Size = new System.Drawing.Size(76, 17);
            this.rbSimpson.TabIndex = 2;
            this.rbSimpson.Text = "Симпсона";
            this.rbSimpson.UseVisualStyleBackColor = true;
            // 
            // rbTrapezoidal
            // 
            this.rbTrapezoidal.AutoSize = true;
            this.rbTrapezoidal.Location = new System.Drawing.Point(6, 42);
            this.rbTrapezoidal.Name = "rbTrapezoidal";
            this.rbTrapezoidal.Size = new System.Drawing.Size(74, 17);
            this.rbTrapezoidal.TabIndex = 1;
            this.rbTrapezoidal.Text = "Трапеций";
            this.rbTrapezoidal.UseVisualStyleBackColor = true;
            // 
            // rbRectangle
            // 
            this.rbRectangle.AutoSize = true;
            this.rbRectangle.Checked = true;
            this.rbRectangle.Location = new System.Drawing.Point(6, 19);
            this.rbRectangle.Name = "rbRectangle";
            this.rbRectangle.Size = new System.Drawing.Size(117, 17);
            this.rbRectangle.TabIndex = 0;
            this.rbRectangle.TabStop = true;
            this.rbRectangle.Text = "Прямоугольников";
            this.rbRectangle.UseVisualStyleBackColor = true;
            // 
            // dgResults
            // 
            this.dgResults.AllowUserToAddRows = false;
            this.dgResults.AllowUserToDeleteRows = false;
            this.dgResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ThreadNumber,
            this.Time,
            this.IntegralValue});
            this.dgResults.Location = new System.Drawing.Point(0, 27);
            this.dgResults.Name = "dgResults";
            this.dgResults.ReadOnly = true;
            this.dgResults.Size = new System.Drawing.Size(557, 478);
            this.dgResults.TabIndex = 3;
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusText});
            this.StatusBar.Location = new System.Drawing.Point(0, 508);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(763, 22);
            this.StatusBar.TabIndex = 4;
            this.StatusBar.Text = "Строка состояния";
            // 
            // StatusText
            // 
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(0, 17);
            // 
            // ThreadNumber
            // 
            this.ThreadNumber.HeaderText = "Число потоков";
            this.ThreadNumber.Name = "ThreadNumber";
            this.ThreadNumber.ReadOnly = true;
            this.ThreadNumber.Width = 99;
            // 
            // Time
            // 
            this.Time.HeaderText = "Время, мс";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 78;
            // 
            // IntegralValue
            // 
            this.IntegralValue.HeaderText = "Значение интеграла";
            this.IntegralValue.Name = "IntegralValue";
            this.IntegralValue.ReadOnly = true;
            this.IntegralValue.Width = 123;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 530);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.dgResults);
            this.Controls.Add(this.pnSettings);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Интегрирование";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnSettings.ResumeLayout(false);
            this.pnSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbThreadsNum)).EndInit();
            this.gbGridType.ResumeLayout(false);
            this.gbGridType.PerformLayout();
            this.gbIntMethod.ResumeLayout(false);
            this.gbIntMethod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Panel pnSettings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAccuracy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClearResults;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.ComboBox cbFunction;
        private System.Windows.Forms.Label lbFunction;
        private System.Windows.Forms.TextBox tbLowerLimit;
        private System.Windows.Forms.TextBox tbUpperLimit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbIntMethod;
        private System.Windows.Forms.RadioButton rbSimpson;
        private System.Windows.Forms.RadioButton rbTrapezoidal;
        private System.Windows.Forms.RadioButton rbRectangle;
        private System.Windows.Forms.DataGridView dgResults;
        private System.Windows.Forms.GroupBox gbGridType;
        private System.Windows.Forms.RadioButton rbIrregular;
        private System.Windows.Forms.RadioButton rbRegular;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusText;
        private System.Windows.Forms.NumericUpDown tbThreadsNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThreadNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntegralValue;
    }
}

