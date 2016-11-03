namespace TestTask
{
    partial class fmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSimulation = new System.Windows.Forms.Button();
            this.TaskTimer = new System.Windows.Forms.Timer(this.components);
            this.progressSimulation = new System.Windows.Forms.ProgressBar();
            this.tbReport = new System.Windows.Forms.TextBox();
            this.laFilePath = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSimulation
            // 
            this.btnSimulation.Location = new System.Drawing.Point(12, 12);
            this.btnSimulation.Name = "btnSimulation";
            this.btnSimulation.Size = new System.Drawing.Size(209, 23);
            this.btnSimulation.TabIndex = 0;
            this.btnSimulation.Text = "Моделювати роботу підприємства";
            this.btnSimulation.UseVisualStyleBackColor = true;
            this.btnSimulation.Click += new System.EventHandler(this.btnSimulation_Click);
            // 
            // TaskTimer
            // 
            this.TaskTimer.Interval = 1;
            this.TaskTimer.Tick += new System.EventHandler(this.TaskTimer_Tick);
            // 
            // progressSimulation
            // 
            this.progressSimulation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressSimulation.Location = new System.Drawing.Point(237, 12);
            this.progressSimulation.Maximum = 160;
            this.progressSimulation.Name = "progressSimulation";
            this.progressSimulation.Size = new System.Drawing.Size(387, 23);
            this.progressSimulation.TabIndex = 1;
            // 
            // tbReport
            // 
            this.tbReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbReport.Location = new System.Drawing.Point(12, 52);
            this.tbReport.Multiline = true;
            this.tbReport.Name = "tbReport";
            this.tbReport.ReadOnly = true;
            this.tbReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReport.Size = new System.Drawing.Size(612, 317);
            this.tbReport.TabIndex = 2;
            // 
            // laFilePath
            // 
            this.laFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.laFilePath.AutoSize = true;
            this.laFilePath.Location = new System.Drawing.Point(122, 384);
            this.laFilePath.Name = "laFilePath";
            this.laFilePath.Size = new System.Drawing.Size(0, 13);
            this.laFilePath.TabIndex = 3;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.Enabled = false;
            this.btnOpen.Location = new System.Drawing.Point(12, 379);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(104, 23);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Відкрити файл";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 410);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.laFilePath);
            this.Controls.Add(this.tbReport);
            this.Controls.Add(this.progressSimulation);
            this.Controls.Add(this.btnSimulation);
            this.Name = "fmMain";
            this.Text = "Підприємство";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSimulation;
        private System.Windows.Forms.Timer TaskTimer;
        private System.Windows.Forms.ProgressBar progressSimulation;
        private System.Windows.Forms.TextBox tbReport;
        private System.Windows.Forms.Label laFilePath;
        private System.Windows.Forms.Button btnOpen;
    }
}

