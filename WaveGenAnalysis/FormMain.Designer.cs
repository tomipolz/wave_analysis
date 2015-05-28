namespace WaveGenAnalysis
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSelectCSVFile = new System.Windows.Forms.Button();
            this.progressBarAxisProgress = new System.Windows.Forms.ProgressBar();
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.checkBoxDrawGraph = new System.Windows.Forms.CheckBox();
            this.listBoxCollection = new System.Windows.Forms.ListBox();
            this.labelXRange = new System.Windows.Forms.Label();
            this.labelYRange = new System.Windows.Forms.Label();
            this.textBoxXRange = new System.Windows.Forms.TextBox();
            this.textBoxYRange = new System.Windows.Forms.TextBox();
            this.textBoxFrequency = new System.Windows.Forms.TextBox();
            this.labelFrequency = new System.Windows.Forms.Label();
            this.labelCurrentFile = new System.Windows.Forms.Label();
            this.labelFileHistory = new System.Windows.Forms.Label();
            this.textBoxThreshold = new System.Windows.Forms.TextBox();
            this.labelThreshold = new System.Windows.Forms.Label();
            this.textBoxReanalyse = new System.Windows.Forms.TextBox();
            this.labelReanalyse = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.buttonOutputCSVFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSelectCSVFile
            // 
            this.buttonSelectCSVFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSelectCSVFile.Location = new System.Drawing.Point(12, 349);
            this.buttonSelectCSVFile.Name = "buttonSelectCSVFile";
            this.buttonSelectCSVFile.Size = new System.Drawing.Size(97, 23);
            this.buttonSelectCSVFile.TabIndex = 0;
            this.buttonSelectCSVFile.Text = "Select CSV file(s)";
            this.buttonSelectCSVFile.UseVisualStyleBackColor = true;
            this.buttonSelectCSVFile.Click += new System.EventHandler(this.buttonSelectCSVFile_Click);
            // 
            // progressBarAxisProgress
            // 
            this.progressBarAxisProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarAxisProgress.Location = new System.Drawing.Point(307, 349);
            this.progressBarAxisProgress.Name = "progressBarAxisProgress";
            this.progressBarAxisProgress.Size = new System.Drawing.Size(566, 23);
            this.progressBarAxisProgress.TabIndex = 3;
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxGraph.Location = new System.Drawing.Point(12, 25);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(942, 240);
            this.pictureBoxGraph.TabIndex = 4;
            this.pictureBoxGraph.TabStop = false;
            // 
            // checkBoxDrawGraph
            // 
            this.checkBoxDrawGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxDrawGraph.AutoSize = true;
            this.checkBoxDrawGraph.Checked = true;
            this.checkBoxDrawGraph.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDrawGraph.Location = new System.Drawing.Point(218, 353);
            this.checkBoxDrawGraph.Name = "checkBoxDrawGraph";
            this.checkBoxDrawGraph.Size = new System.Drawing.Size(83, 17);
            this.checkBoxDrawGraph.TabIndex = 5;
            this.checkBoxDrawGraph.Text = "Draw Graph";
            this.checkBoxDrawGraph.UseVisualStyleBackColor = true;
            this.checkBoxDrawGraph.CheckedChanged += new System.EventHandler(this.checkBoxDrawGraph_CheckedChanged);
            // 
            // listBoxCollection
            // 
            this.listBoxCollection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxCollection.FormattingEnabled = true;
            this.listBoxCollection.Location = new System.Drawing.Point(15, 283);
            this.listBoxCollection.Name = "listBoxCollection";
            this.listBoxCollection.Size = new System.Drawing.Size(588, 56);
            this.listBoxCollection.TabIndex = 6;
            this.listBoxCollection.DoubleClick += new System.EventHandler(this.listBoxCollection_DoubleClick);
            // 
            // labelXRange
            // 
            this.labelXRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelXRange.AutoSize = true;
            this.labelXRange.Location = new System.Drawing.Point(800, 274);
            this.labelXRange.Name = "labelXRange";
            this.labelXRange.Size = new System.Drawing.Size(49, 13);
            this.labelXRange.TabIndex = 7;
            this.labelXRange.Text = "X Range";
            // 
            // labelYRange
            // 
            this.labelYRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelYRange.AutoSize = true;
            this.labelYRange.Location = new System.Drawing.Point(799, 300);
            this.labelYRange.Name = "labelYRange";
            this.labelYRange.Size = new System.Drawing.Size(49, 13);
            this.labelYRange.TabIndex = 8;
            this.labelYRange.Text = "Y Range";
            // 
            // textBoxXRange
            // 
            this.textBoxXRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxXRange.Location = new System.Drawing.Point(855, 271);
            this.textBoxXRange.Name = "textBoxXRange";
            this.textBoxXRange.ReadOnly = true;
            this.textBoxXRange.Size = new System.Drawing.Size(100, 20);
            this.textBoxXRange.TabIndex = 9;
            // 
            // textBoxYRange
            // 
            this.textBoxYRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxYRange.Location = new System.Drawing.Point(854, 297);
            this.textBoxYRange.Name = "textBoxYRange";
            this.textBoxYRange.ReadOnly = true;
            this.textBoxYRange.Size = new System.Drawing.Size(100, 20);
            this.textBoxYRange.TabIndex = 10;
            // 
            // textBoxFrequency
            // 
            this.textBoxFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFrequency.Location = new System.Drawing.Point(694, 271);
            this.textBoxFrequency.Name = "textBoxFrequency";
            this.textBoxFrequency.ReadOnly = true;
            this.textBoxFrequency.Size = new System.Drawing.Size(100, 20);
            this.textBoxFrequency.TabIndex = 12;
            // 
            // labelFrequency
            // 
            this.labelFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFrequency.AutoSize = true;
            this.labelFrequency.Location = new System.Drawing.Point(609, 274);
            this.labelFrequency.Name = "labelFrequency";
            this.labelFrequency.Size = new System.Drawing.Size(79, 13);
            this.labelFrequency.TabIndex = 11;
            this.labelFrequency.Text = "Frequency (Hz)";
            // 
            // labelCurrentFile
            // 
            this.labelCurrentFile.AutoSize = true;
            this.labelCurrentFile.Location = new System.Drawing.Point(12, 9);
            this.labelCurrentFile.Name = "labelCurrentFile";
            this.labelCurrentFile.Size = new System.Drawing.Size(60, 13);
            this.labelCurrentFile.TabIndex = 13;
            this.labelCurrentFile.Text = "Current File";
            // 
            // labelFileHistory
            // 
            this.labelFileHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFileHistory.AutoSize = true;
            this.labelFileHistory.Location = new System.Drawing.Point(15, 267);
            this.labelFileHistory.Name = "labelFileHistory";
            this.labelFileHistory.Size = new System.Drawing.Size(213, 13);
            this.labelFileHistory.TabIndex = 14;
            this.labelFileHistory.Text = "File History - Double click item to load graph";
            // 
            // textBoxThreshold
            // 
            this.textBoxThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxThreshold.Location = new System.Drawing.Point(693, 297);
            this.textBoxThreshold.Name = "textBoxThreshold";
            this.textBoxThreshold.Size = new System.Drawing.Size(100, 20);
            this.textBoxThreshold.TabIndex = 15;
            this.textBoxThreshold.Text = "65";
            // 
            // labelThreshold
            // 
            this.labelThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelThreshold.AutoSize = true;
            this.labelThreshold.Location = new System.Drawing.Point(609, 300);
            this.labelThreshold.Name = "labelThreshold";
            this.labelThreshold.Size = new System.Drawing.Size(78, 13);
            this.labelThreshold.TabIndex = 16;
            this.labelThreshold.Text = "Threshold (Y%)";
            // 
            // textBoxReanalyse
            // 
            this.textBoxReanalyse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxReanalyse.Location = new System.Drawing.Point(854, 323);
            this.textBoxReanalyse.Name = "textBoxReanalyse";
            this.textBoxReanalyse.Size = new System.Drawing.Size(100, 20);
            this.textBoxReanalyse.TabIndex = 17;
            this.textBoxReanalyse.Text = "10";
            // 
            // labelReanalyse
            // 
            this.labelReanalyse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelReanalyse.AutoSize = true;
            this.labelReanalyse.Location = new System.Drawing.Point(749, 326);
            this.labelReanalyse.Name = "labelReanalyse";
            this.labelReanalyse.Size = new System.Drawing.Size(99, 13);
            this.labelReanalyse.TabIndex = 18;
            this.labelReanalyse.Text = "Analyse X part (X%)";
            // 
            // buttonCheck
            // 
            this.buttonCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCheck.Location = new System.Drawing.Point(879, 349);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonCheck.TabIndex = 19;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // buttonOutputCSVFile
            // 
            this.buttonOutputCSVFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOutputCSVFile.Location = new System.Drawing.Point(115, 349);
            this.buttonOutputCSVFile.Name = "buttonOutputCSVFile";
            this.buttonOutputCSVFile.Size = new System.Drawing.Size(97, 23);
            this.buttonOutputCSVFile.TabIndex = 20;
            this.buttonOutputCSVFile.Text = "Output CSV file";
            this.buttonOutputCSVFile.UseVisualStyleBackColor = true;
            this.buttonOutputCSVFile.Click += new System.EventHandler(this.buttonOutputCSVFile_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 384);
            this.Controls.Add(this.buttonOutputCSVFile);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.labelReanalyse);
            this.Controls.Add(this.textBoxReanalyse);
            this.Controls.Add(this.labelThreshold);
            this.Controls.Add(this.textBoxThreshold);
            this.Controls.Add(this.labelFileHistory);
            this.Controls.Add(this.labelCurrentFile);
            this.Controls.Add(this.textBoxFrequency);
            this.Controls.Add(this.labelFrequency);
            this.Controls.Add(this.textBoxYRange);
            this.Controls.Add(this.textBoxXRange);
            this.Controls.Add(this.labelYRange);
            this.Controls.Add(this.labelXRange);
            this.Controls.Add(this.listBoxCollection);
            this.Controls.Add(this.checkBoxDrawGraph);
            this.Controls.Add(this.pictureBoxGraph);
            this.Controls.Add(this.progressBarAxisProgress);
            this.Controls.Add(this.buttonSelectCSVFile);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(982, 422);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResizeBegin += new System.EventHandler(this.FormMain_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.FormMain_ResizeEnd);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSelectCSVFile;
        private System.Windows.Forms.ProgressBar progressBarAxisProgress;
        private System.Windows.Forms.PictureBox pictureBoxGraph;
        private System.Windows.Forms.CheckBox checkBoxDrawGraph;
        private System.Windows.Forms.ListBox listBoxCollection;
        private System.Windows.Forms.Label labelXRange;
        private System.Windows.Forms.Label labelYRange;
        private System.Windows.Forms.TextBox textBoxXRange;
        private System.Windows.Forms.TextBox textBoxYRange;
        private System.Windows.Forms.TextBox textBoxFrequency;
        private System.Windows.Forms.Label labelFrequency;
        private System.Windows.Forms.Label labelCurrentFile;
        private System.Windows.Forms.Label labelFileHistory;
        private System.Windows.Forms.TextBox textBoxThreshold;
        private System.Windows.Forms.Label labelThreshold;
        private System.Windows.Forms.TextBox textBoxReanalyse;
        private System.Windows.Forms.Label labelReanalyse;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonOutputCSVFile;
    }
}

