namespace LevelEditor {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.levelTab = new System.Windows.Forms.TabPage();
            this.infoTab = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btn1x3 = new System.Windows.Forms.ToolStripButton();
            this.btn1x2 = new System.Windows.Forms.ToolStripButton();
            this.btn3x1 = new System.Windows.Forms.ToolStripButton();
            this.btn2x1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.levelTab.SuspendLayout();
            this.infoTab.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrid.Location = new System.Drawing.Point(64, 15);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(384, 384);
            this.pnlGrid.TabIndex = 0;
            this.pnlGrid.MouseLeave += new System.EventHandler(this.pnlGrid_MouseLeave);
            this.pnlGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGrid_Paint);
            this.pnlGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlGrid_MouseDown);
            this.pnlGrid.MouseEnter += new System.EventHandler(this.pnlGrid_MouseEnter);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.btnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(461, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(51, 22);
            this.btnNew.Text = "New";
            this.btnNew.ToolTipText = "New level";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(56, 22);
            this.btnOpen.Text = "Open";
            this.btnOpen.ToolTipText = "Open existing level";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 22);
            this.btnSave.Text = "Save";
            this.btnSave.ToolTipText = "Save current level";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.levelTab);
            this.tcMain.Controls.Add(this.infoTab);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 25);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(461, 428);
            this.tcMain.TabIndex = 2;
            // 
            // levelTab
            // 
            this.levelTab.BackColor = System.Drawing.SystemColors.Control;
            this.levelTab.Controls.Add(this.toolStrip2);
            this.levelTab.Controls.Add(this.pnlGrid);
            this.levelTab.Location = new System.Drawing.Point(4, 22);
            this.levelTab.Name = "levelTab";
            this.levelTab.Padding = new System.Windows.Forms.Padding(3);
            this.levelTab.Size = new System.Drawing.Size(453, 402);
            this.levelTab.TabIndex = 0;
            this.levelTab.Text = "Level";
            // 
            // infoTab
            // 
            this.infoTab.BackColor = System.Drawing.SystemColors.Control;
            this.infoTab.Controls.Add(this.label3);
            this.infoTab.Controls.Add(this.txtDescription);
            this.infoTab.Controls.Add(this.label2);
            this.infoTab.Controls.Add(this.txtAuthor);
            this.infoTab.Controls.Add(this.label1);
            this.infoTab.Controls.Add(this.txtName);
            this.infoTab.Location = new System.Drawing.Point(4, 22);
            this.infoTab.Name = "infoTab";
            this.infoTab.Padding = new System.Windows.Forms.Padding(3);
            this.infoTab.Size = new System.Drawing.Size(453, 402);
            this.infoTab.TabIndex = 1;
            this.infoTab.Text = "Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(79, 91);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(225, 123);
            this.txtDescription.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Author:";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(79, 49);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(225, 21);
            this.txtAuthor.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Level Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(79, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(225, 21);
            this.txtName.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.CanOverflow = false;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn1x3,
            this.btn1x2,
            this.btn3x1,
            this.btn2x1});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(49, 396);
            this.toolStrip2.Stretch = true;
            this.toolStrip2.TabIndex = 1;
            // 
            // btn1x3
            // 
            this.btn1x3.AutoSize = false;
            this.btn1x3.Checked = true;
            this.btn1x3.CheckOnClick = true;
            this.btn1x3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btn1x3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn1x3.Image = global::LevelEditor.CursorResources.Block1x3;
            this.btn1x3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn1x3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn1x3.Name = "btn1x3";
            this.btn1x3.Size = new System.Drawing.Size(48, 48);
            this.btn1x3.Tag = "Block1x3";
            this.btn1x3.Text = "1x3";
            this.btn1x3.Click += new System.EventHandler(this.typeSelected);
            // 
            // btn1x2
            // 
            this.btn1x2.AutoSize = false;
            this.btn1x2.CheckOnClick = true;
            this.btn1x2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn1x2.Image = global::LevelEditor.CursorResources.Block1x2;
            this.btn1x2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn1x2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn1x2.Name = "btn1x2";
            this.btn1x2.Size = new System.Drawing.Size(48, 48);
            this.btn1x2.Tag = "Block1x2";
            this.btn1x2.Text = "1x2";
            this.btn1x2.Click += new System.EventHandler(this.typeSelected);
            // 
            // btn3x1
            // 
            this.btn3x1.AutoSize = false;
            this.btn3x1.CheckOnClick = true;
            this.btn3x1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn3x1.Image = global::LevelEditor.CursorResources.Block3x1;
            this.btn3x1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn3x1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn3x1.Name = "btn3x1";
            this.btn3x1.Size = new System.Drawing.Size(48, 48);
            this.btn3x1.Tag = "Block3x1";
            this.btn3x1.Text = "3x1";
            this.btn3x1.Click += new System.EventHandler(this.typeSelected);
            // 
            // btn2x1
            // 
            this.btn2x1.AutoSize = false;
            this.btn2x1.CheckOnClick = true;
            this.btn2x1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn2x1.Image = global::LevelEditor.CursorResources.Block2x1;
            this.btn2x1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn2x1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn2x1.Name = "btn2x1";
            this.btn2x1.Size = new System.Drawing.Size(48, 48);
            this.btn2x1.Tag = "Block2x1";
            this.btn2x1.Text = "2x1";
            this.btn2x1.Click += new System.EventHandler(this.typeSelected);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 453);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Rush Hour Level Editor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.levelTab.ResumeLayout(false);
            this.levelTab.PerformLayout();
            this.infoTab.ResumeLayout(false);
            this.infoTab.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage levelTab;
        private System.Windows.Forms.TabPage infoTab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btn1x3;
        private System.Windows.Forms.ToolStripButton btn1x2;
        private System.Windows.Forms.ToolStripButton btn3x1;
        private System.Windows.Forms.ToolStripButton btn2x1;
    }
}

