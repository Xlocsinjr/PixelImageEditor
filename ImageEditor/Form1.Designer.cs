namespace ImageEditor
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxBg = new System.Windows.Forms.GroupBox();
            this.flowLayoutBgStars = new System.Windows.Forms.FlowLayoutPanel();
            this.StarsCheckBox = new System.Windows.Forms.CheckBox();
            this.StarsRegenButton = new System.Windows.Forms.Button();
            this.TrackbarBgStars = new System.Windows.Forms.TrackBar();
            this.labelBgStars = new System.Windows.Forms.Label();
            this.listViewBgChoose = new System.Windows.Forms.ListView();
            this.BgTablePlainColour = new System.Windows.Forms.TableLayoutPanel();
            this.buttonBgPlainColourChoose = new System.Windows.Forms.Button();
            this.pictureBoxBgPlainColourPreview = new System.Windows.Forms.PictureBox();
            this.comboBoxBg = new System.Windows.Forms.ComboBox();
            this.colorDialogBgPlainColour = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.exportImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxBg.SuspendLayout();
            this.flowLayoutBgStars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackbarBgStars)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(986, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripFile
            // 
            this.toolStripFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFileNew,
            this.exportImageToolStripMenuItem,
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
            this.toolStrip1.Size = new System.Drawing.Size(986, 25);
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
            this.splitContainer1.Size = new System.Drawing.Size(986, 482);
            this.splitContainer1.SplitterDistance = 636;
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
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBoxBg
            // 
            this.groupBoxBg.AutoSize = true;
            this.groupBoxBg.Controls.Add(this.flowLayoutBgStars);
            this.groupBoxBg.Controls.Add(this.listViewBgChoose);
            this.groupBoxBg.Controls.Add(this.BgTablePlainColour);
            this.groupBoxBg.Controls.Add(this.comboBoxBg);
            this.groupBoxBg.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxBg.Location = new System.Drawing.Point(0, 0);
            this.groupBoxBg.Name = "groupBoxBg";
            this.groupBoxBg.Size = new System.Drawing.Size(346, 213);
            this.groupBoxBg.TabIndex = 0;
            this.groupBoxBg.TabStop = false;
            this.groupBoxBg.Text = "Background";
            // 
            // flowLayoutBgStars
            // 
            this.flowLayoutBgStars.Controls.Add(this.StarsCheckBox);
            this.flowLayoutBgStars.Controls.Add(this.StarsRegenButton);
            this.flowLayoutBgStars.Controls.Add(this.TrackbarBgStars);
            this.flowLayoutBgStars.Controls.Add(this.labelBgStars);
            this.flowLayoutBgStars.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutBgStars.Location = new System.Drawing.Point(3, 140);
            this.flowLayoutBgStars.Name = "flowLayoutBgStars";
            this.flowLayoutBgStars.Size = new System.Drawing.Size(340, 70);
            this.flowLayoutBgStars.TabIndex = 3;
            // 
            // StarsCheckBox
            // 
            this.StarsCheckBox.AutoSize = true;
            this.StarsCheckBox.Location = new System.Drawing.Point(3, 3);
            this.StarsCheckBox.Name = "StarsCheckBox";
            this.StarsCheckBox.Size = new System.Drawing.Size(50, 17);
            this.StarsCheckBox.TabIndex = 0;
            this.StarsCheckBox.Text = "Stars";
            this.StarsCheckBox.UseVisualStyleBackColor = true;
            this.StarsCheckBox.CheckedChanged += new System.EventHandler(this.StarsCheckBox_CheckedChanged);
            // 
            // StarsRegenButton
            // 
            this.StarsRegenButton.Location = new System.Drawing.Point(59, 3);
            this.StarsRegenButton.Name = "StarsRegenButton";
            this.StarsRegenButton.Size = new System.Drawing.Size(75, 23);
            this.StarsRegenButton.TabIndex = 1;
            this.StarsRegenButton.Text = "Regenerate";
            this.StarsRegenButton.UseVisualStyleBackColor = true;
            this.StarsRegenButton.Click += new System.EventHandler(this.StarsCheckBox_CheckedChanged);
            // 
            // TrackbarBgStars
            // 
            this.TrackbarBgStars.LargeChange = 1;
            this.TrackbarBgStars.Location = new System.Drawing.Point(140, 3);
            this.TrackbarBgStars.Maximum = 20;
            this.TrackbarBgStars.Minimum = 1;
            this.TrackbarBgStars.Name = "TrackbarBgStars";
            this.TrackbarBgStars.Size = new System.Drawing.Size(177, 45);
            this.TrackbarBgStars.TabIndex = 2;
            this.TrackbarBgStars.Value = 1;
            this.TrackbarBgStars.ValueChanged += new System.EventHandler(this.TrackbarBgStars_ValueChanged);
            // 
            // labelBgStars
            // 
            this.labelBgStars.AutoSize = true;
            this.labelBgStars.Location = new System.Drawing.Point(3, 51);
            this.labelBgStars.Name = "labelBgStars";
            this.labelBgStars.Size = new System.Drawing.Size(35, 13);
            this.labelBgStars.TabIndex = 3;
            this.labelBgStars.Text = "label1";
            // 
            // listViewBgChoose
            // 
            this.listViewBgChoose.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewBgChoose.HideSelection = false;
            this.listViewBgChoose.Location = new System.Drawing.Point(3, 72);
            this.listViewBgChoose.Name = "listViewBgChoose";
            this.listViewBgChoose.Size = new System.Drawing.Size(340, 68);
            this.listViewBgChoose.TabIndex = 2;
            this.listViewBgChoose.UseCompatibleStateImageBehavior = false;
            this.listViewBgChoose.View = System.Windows.Forms.View.Tile;
            this.listViewBgChoose.SelectedIndexChanged += new System.EventHandler(this.listViewBgChoose_SelectedIndexChanged);
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
            this.BgTablePlainColour.Size = new System.Drawing.Size(340, 35);
            this.BgTablePlainColour.TabIndex = 1;
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
            this.pictureBoxBgPlainColourPreview.Location = new System.Drawing.Point(173, 3);
            this.pictureBoxBgPlainColourPreview.Name = "pictureBoxBgPlainColourPreview";
            this.pictureBoxBgPlainColourPreview.Size = new System.Drawing.Size(29, 29);
            this.pictureBoxBgPlainColourPreview.TabIndex = 1;
            this.pictureBoxBgPlainColourPreview.TabStop = false;
            // 
            // comboBoxBg
            // 
            this.comboBoxBg.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxBg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBg.FormattingEnabled = true;
            this.comboBoxBg.Items.AddRange(new object[] {
            "Plain Colour",
            "Background images"});
            this.comboBoxBg.Location = new System.Drawing.Point(3, 16);
            this.comboBoxBg.Name = "comboBoxBg";
            this.comboBoxBg.Size = new System.Drawing.Size(340, 21);
            this.comboBoxBg.TabIndex = 0;
            this.comboBoxBg.SelectedIndexChanged += new System.EventHandler(this.comboBoxBg_SelectedIndexChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            this.saveFileDialog1.Title = "Export image";
            // 
            // exportImageToolStripMenuItem
            // 
            this.exportImageToolStripMenuItem.Name = "exportImageToolStripMenuItem";
            this.exportImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportImageToolStripMenuItem.Text = "Export image";
            this.exportImageToolStripMenuItem.Click += new System.EventHandler(this.exportImageToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(986, 531);
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
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxBg.ResumeLayout(false);
            this.flowLayoutBgStars.ResumeLayout(false);
            this.flowLayoutBgStars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackbarBgStars)).EndInit();
            this.BgTablePlainColour.ResumeLayout(false);
            this.BgTablePlainColour.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBgPlainColourPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripFile;
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
        private System.Windows.Forms.ComboBox comboBoxBg;
        private System.Windows.Forms.ListView listViewBgChoose;
        private System.Windows.Forms.Button buttonBgPlainColourChoose;
        private System.Windows.Forms.PictureBox pictureBoxBgPlainColourPreview;
        private System.Windows.Forms.ColorDialog colorDialogBgPlainColour;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutBgStars;
        private System.Windows.Forms.CheckBox StarsCheckBox;
        private System.Windows.Forms.Button StarsRegenButton;
        private System.Windows.Forms.TrackBar TrackbarBgStars;
        private System.Windows.Forms.Label labelBgStars;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem exportImageToolStripMenuItem;
    }
}

