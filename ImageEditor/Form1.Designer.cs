﻿namespace ImageEditor
{
    partial class Form1
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
            this.toolStripFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxBg = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BgTablePlainColour = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonBgPlainColourChoose = new System.Windows.Forms.Button();
            this.pictureBoxBgPlainColourPreview = new System.Windows.Forms.PictureBox();
            this.colorDialogBgPlainColour = new System.Windows.Forms.ColorDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxBg.SuspendLayout();
            this.BgTablePlainColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBgPlainColourPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(893, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripFile
            // 
            this.toolStripFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFileNew,
            this.toolStripFileOpen,
            this.toolStripFileSave,
            this.toolStripSeparator1,
            this.toolStripFileExit});
            this.toolStripFile.Name = "toolStripFile";
            this.toolStripFile.Size = new System.Drawing.Size(37, 20);
            this.toolStripFile.Text = "File";
            // 
            // toolStripFileNew
            // 
            this.toolStripFileNew.Name = "toolStripFileNew";
            this.toolStripFileNew.Size = new System.Drawing.Size(103, 22);
            this.toolStripFileNew.Text = "New";
            this.toolStripFileNew.Click += new System.EventHandler(this.toolStripFileNew_Click);
            // 
            // toolStripFileOpen
            // 
            this.toolStripFileOpen.Name = "toolStripFileOpen";
            this.toolStripFileOpen.Size = new System.Drawing.Size(103, 22);
            this.toolStripFileOpen.Text = "Open";
            this.toolStripFileOpen.Click += new System.EventHandler(this.toolStripFileOpen_Click);
            // 
            // toolStripFileSave
            // 
            this.toolStripFileSave.Name = "toolStripFileSave";
            this.toolStripFileSave.Size = new System.Drawing.Size(103, 22);
            this.toolStripFileSave.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // toolStripFileExit
            // 
            this.toolStripFileExit.Name = "toolStripFileExit";
            this.toolStripFileExit.Size = new System.Drawing.Size(103, 22);
            this.toolStripFileExit.Text = "Exit";
            this.toolStripFileExit.Click += new System.EventHandler(this.toolStripFileExit_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(893, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxBg);
            this.splitContainer1.Size = new System.Drawing.Size(893, 482);
            this.splitContainer1.SplitterDistance = 297;
            this.splitContainer1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxBg
            // 
            this.groupBoxBg.Controls.Add(this.listView1);
            this.groupBoxBg.Controls.Add(this.BgTablePlainColour);
            this.groupBoxBg.Controls.Add(this.comboBox1);
            this.groupBoxBg.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxBg.Location = new System.Drawing.Point(0, 0);
            this.groupBoxBg.Name = "groupBoxBg";
            this.groupBoxBg.Size = new System.Drawing.Size(592, 143);
            this.groupBoxBg.TabIndex = 0;
            this.groupBoxBg.TabStop = false;
            this.groupBoxBg.Text = "Background";
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Plain Colour"});
            this.comboBox1.Location = new System.Drawing.Point(3, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(586, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // BgTablePlainColour
            // 
            this.BgTablePlainColour.ColumnCount = 2;
            this.BgTablePlainColour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BgTablePlainColour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BgTablePlainColour.Controls.Add(this.buttonBgPlainColourChoose, 0, 0);
            this.BgTablePlainColour.Controls.Add(this.pictureBoxBgPlainColourPreview, 1, 0);
            this.BgTablePlainColour.Dock = System.Windows.Forms.DockStyle.Top;
            this.BgTablePlainColour.Location = new System.Drawing.Point(3, 37);
            this.BgTablePlainColour.Name = "BgTablePlainColour";
            this.BgTablePlainColour.RowCount = 1;
            this.BgTablePlainColour.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.61728F));
            this.BgTablePlainColour.Size = new System.Drawing.Size(586, 35);
            this.BgTablePlainColour.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 72);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(586, 68);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // buttonBgPlainColourChoose
            // 
            this.buttonBgPlainColourChoose.AutoSize = true;
            this.buttonBgPlainColourChoose.Location = new System.Drawing.Point(3, 3);
            this.buttonBgPlainColourChoose.Name = "buttonBgPlainColourChoose";
            this.buttonBgPlainColourChoose.Size = new System.Drawing.Size(85, 23);
            this.buttonBgPlainColourChoose.TabIndex = 0;
            this.buttonBgPlainColourChoose.Text = "Choose colour";
            this.buttonBgPlainColourChoose.UseVisualStyleBackColor = true;
            this.buttonBgPlainColourChoose.Click += new System.EventHandler(this.buttonBgPlainColourChoose_Click);
            // 
            // pictureBoxBgPlainColourPreview
            // 
            this.pictureBoxBgPlainColourPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxBgPlainColourPreview.Location = new System.Drawing.Point(296, 3);
            this.pictureBoxBgPlainColourPreview.Name = "pictureBoxBgPlainColourPreview";
            this.pictureBoxBgPlainColourPreview.Size = new System.Drawing.Size(29, 29);
            this.pictureBoxBgPlainColourPreview.TabIndex = 1;
            this.pictureBoxBgPlainColourPreview.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(893, 531);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxBg.ResumeLayout(false);
            this.BgTablePlainColour.ResumeLayout(false);
            this.BgTablePlainColour.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBgPlainColourPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripFileOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripFileExit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripFileNew;
        private System.Windows.Forms.GroupBox groupBoxBg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel BgTablePlainColour;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonBgPlainColourChoose;
        private System.Windows.Forms.PictureBox pictureBoxBgPlainColourPreview;
        private System.Windows.Forms.ColorDialog colorDialogBgPlainColour;
    }
}

