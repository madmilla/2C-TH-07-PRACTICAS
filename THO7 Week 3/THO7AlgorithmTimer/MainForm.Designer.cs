﻿namespace THO7AlgorithmTimerApplication
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Input = new System.Windows.Forms.GroupBox();
            this.InputPictureBox = new System.Windows.Forms.PictureBox();
            this.AlgorithmGroupBox = new System.Windows.Forms.GroupBox();
            this.OutputToInput = new System.Windows.Forms.Button();
            this.AlgoListBox = new System.Windows.Forms.ListBox();
            this.AlgoButton = new System.Windows.Forms.Button();
            this.OutputGroupBox = new System.Windows.Forms.GroupBox();
            this.OutputPictureBox = new System.Windows.Forms.PictureBox();
            this.InfoGroupBox = new System.Windows.Forms.GroupBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.backgroundAlgorithmWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.Input.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputPictureBox)).BeginInit();
            this.AlgorithmGroupBox.SuspendLayout();
            this.OutputGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutputPictureBox)).BeginInit();
            this.InfoGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1336, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPictureToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openPictureToolStripMenuItem
            // 
            this.openPictureToolStripMenuItem.Name = "openPictureToolStripMenuItem";
            this.openPictureToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openPictureToolStripMenuItem.Text = "Open Picture";
            this.openPictureToolStripMenuItem.Click += new System.EventHandler(this.openPictureToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Input
            // 
            this.Input.Controls.Add(this.InputPictureBox);
            this.Input.Location = new System.Drawing.Point(29, 64);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(302, 344);
            this.Input.TabIndex = 1;
            this.Input.TabStop = false;
            this.Input.Text = "Original";
            this.Input.Enter += new System.EventHandler(this.Input_Enter);
            // 
            // InputPictureBox
            // 
            this.InputPictureBox.Location = new System.Drawing.Point(0, 19);
            this.InputPictureBox.Name = "InputPictureBox";
            this.InputPictureBox.Size = new System.Drawing.Size(296, 319);
            this.InputPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.InputPictureBox.TabIndex = 0;
            this.InputPictureBox.TabStop = false;
            this.InputPictureBox.DoubleClick += new System.EventHandler(this.openPictureToolStripMenuItem_Click);
            // 
            // AlgorithmGroupBox
            // 
            this.AlgorithmGroupBox.Controls.Add(this.OutputToInput);
            this.AlgorithmGroupBox.Controls.Add(this.AlgoListBox);
            this.AlgorithmGroupBox.Controls.Add(this.AlgoButton);
            this.AlgorithmGroupBox.Location = new System.Drawing.Point(337, 64);
            this.AlgorithmGroupBox.Name = "AlgorithmGroupBox";
            this.AlgorithmGroupBox.Size = new System.Drawing.Size(170, 344);
            this.AlgorithmGroupBox.TabIndex = 2;
            this.AlgorithmGroupBox.TabStop = false;
            this.AlgorithmGroupBox.Text = "Algorithm";
            // 
            // OutputToInput
            // 
            this.OutputToInput.Location = new System.Drawing.Point(87, 19);
            this.OutputToInput.Name = "OutputToInput";
            this.OutputToInput.Size = new System.Drawing.Size(75, 23);
            this.OutputToInput.TabIndex = 2;
            this.OutputToInput.Text = "<--";
            this.OutputToInput.UseVisualStyleBackColor = true;
            this.OutputToInput.Click += new System.EventHandler(this.OutputToInputButton_Click);
            // 
            // AlgoListBox
            // 
            this.AlgoListBox.FormattingEnabled = true;
            this.AlgoListBox.Location = new System.Drawing.Point(6, 48);
            this.AlgoListBox.Name = "AlgoListBox";
            this.AlgoListBox.Size = new System.Drawing.Size(156, 160);
            this.AlgoListBox.TabIndex = 1;
            this.AlgoListBox.SelectedIndexChanged += new System.EventHandler(this.AlgoListBox_SelectedIndexChanged);
            // 
            // AlgoButton
            // 
            this.AlgoButton.Location = new System.Drawing.Point(6, 19);
            this.AlgoButton.Name = "AlgoButton";
            this.AlgoButton.Size = new System.Drawing.Size(75, 23);
            this.AlgoButton.TabIndex = 0;
            this.AlgoButton.Text = "start";
            this.AlgoButton.UseVisualStyleBackColor = true;
            this.AlgoButton.Click += new System.EventHandler(this.AlgoButton_Click);
            // 
            // OutputGroupBox
            // 
            this.OutputGroupBox.Controls.Add(this.OutputPictureBox);
            this.OutputGroupBox.Location = new System.Drawing.Point(821, 64);
            this.OutputGroupBox.Name = "OutputGroupBox";
            this.OutputGroupBox.Size = new System.Drawing.Size(302, 344);
            this.OutputGroupBox.TabIndex = 3;
            this.OutputGroupBox.TabStop = false;
            this.OutputGroupBox.Text = "Output";
            // 
            // OutputPictureBox
            // 
            this.OutputPictureBox.Location = new System.Drawing.Point(6, 16);
            this.OutputPictureBox.Name = "OutputPictureBox";
            this.OutputPictureBox.Size = new System.Drawing.Size(290, 319);
            this.OutputPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OutputPictureBox.TabIndex = 0;
            this.OutputPictureBox.TabStop = false;
            this.OutputPictureBox.DoubleClick += new System.EventHandler(this.OutputPictureBox_DoubleClick);
            // 
            // InfoGroupBox
            // 
            this.InfoGroupBox.Controls.Add(this.button1);
            this.InfoGroupBox.Controls.Add(this.ClearButton);
            this.InfoGroupBox.Controls.Add(this.InfoLabel);
            this.InfoGroupBox.Location = new System.Drawing.Point(1129, 64);
            this.InfoGroupBox.Name = "InfoGroupBox";
            this.InfoGroupBox.Size = new System.Drawing.Size(200, 344);
            this.InfoGroupBox.TabIndex = 4;
            this.InfoGroupBox.TabStop = false;
            this.InfoGroupBox.Text = "Info";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(119, 312);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 1;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoLabel.Location = new System.Drawing.Point(3, 16);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(0, 13);
            this.InfoLabel.TabIndex = 0;
            // 
            // backgroundAlgorithmWorker
            // 
            this.backgroundAlgorithmWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundAlgorithmWorker_DoWork);
            this.backgroundAlgorithmWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundAlgorithmWorker_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(513, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 344);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(290, 319);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Check differences";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 433);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.InfoGroupBox);
            this.Controls.Add(this.OutputGroupBox);
            this.Controls.Add(this.AlgorithmGroupBox);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "THO7 Algorithm Timer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Input.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InputPictureBox)).EndInit();
            this.AlgorithmGroupBox.ResumeLayout(false);
            this.OutputGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OutputPictureBox)).EndInit();
            this.InfoGroupBox.ResumeLayout(false);
            this.InfoGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox Input;
        private System.Windows.Forms.GroupBox AlgorithmGroupBox;
        private System.Windows.Forms.GroupBox OutputGroupBox;
        private System.Windows.Forms.PictureBox InputPictureBox;
        private System.Windows.Forms.PictureBox OutputPictureBox;
        private System.Windows.Forms.GroupBox InfoGroupBox;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.ListBox AlgoListBox;
        private System.Windows.Forms.Button AlgoButton;
        private System.Windows.Forms.Button OutputToInput;
        private System.Windows.Forms.Button ClearButton;
        private System.ComponentModel.BackgroundWorker backgroundAlgorithmWorker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}

