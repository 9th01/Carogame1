
namespace Carogame
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
            this.components = new System.ComponentModel.Container();
            this.pnlChessBoard = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.prsCoolDown = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLan = new System.Windows.Forms.Button();
            this.picBox2 = new System.Windows.Forms.PictureBox();
            this.txbIP = new System.Windows.Forms.TextBox();
            this.tntName = new System.Windows.Forms.TextBox();
            this.tmCoolDown = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quytToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStrart = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlChessBoard
            // 
            this.pnlChessBoard.BackColor = System.Drawing.SystemColors.Control;
            this.pnlChessBoard.Location = new System.Drawing.Point(2, 33);
            this.pnlChessBoard.Name = "pnlChessBoard";
            this.pnlChessBoard.Size = new System.Drawing.Size(577, 449);
            this.pnlChessBoard.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(585, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(218, 233);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::Carogame.Properties.Resources.p;
            this.pictureBox1.Location = new System.Drawing.Point(3, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 204);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.btnStrart);
            this.panel3.Controls.Add(this.prsCoolDown);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnLan);
            this.panel3.Controls.Add(this.picBox2);
            this.panel3.Controls.Add(this.txbIP);
            this.panel3.Controls.Add(this.tntName);
            this.panel3.Location = new System.Drawing.Point(585, 272);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(218, 210);
            this.panel3.TabIndex = 2;
            // 
            // prsCoolDown
            // 
            this.prsCoolDown.Location = new System.Drawing.Point(3, 36);
            this.prsCoolDown.Name = "prsCoolDown";
            this.prsCoolDown.Size = new System.Drawing.Size(125, 29);
            this.prsCoolDown.TabIndex = 5;
            this.prsCoolDown.Click += new System.EventHandler(this.prsCoolDown_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Script MT Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(25, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "5 in a line to win";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnLan
            // 
            this.btnLan.Location = new System.Drawing.Point(12, 111);
            this.btnLan.Name = "btnLan";
            this.btnLan.Size = new System.Drawing.Size(94, 29);
            this.btnLan.TabIndex = 3;
            this.btnLan.Text = "CONNECT";
            this.btnLan.UseVisualStyleBackColor = true;
            this.btnLan.Click += new System.EventHandler(this.button1_Click);
            // 
            // picBox2
            // 
            this.picBox2.BackColor = System.Drawing.SystemColors.Control;
            this.picBox2.Location = new System.Drawing.Point(131, 0);
            this.picBox2.Name = "picBox2";
            this.picBox2.Size = new System.Drawing.Size(81, 96);
            this.picBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox2.TabIndex = 2;
            this.picBox2.TabStop = false;
            // 
            // txbIP
            // 
            this.txbIP.Location = new System.Drawing.Point(3, 69);
            this.txbIP.Name = "txbIP";
            this.txbIP.Size = new System.Drawing.Size(125, 27);
            this.txbIP.TabIndex = 1;
            this.txbIP.Text = "\r\n192.168.255";
            // 
            // tntName
            // 
            this.tntName.Location = new System.Drawing.Point(3, 3);
            this.tntName.Name = "tntName";
            this.tntName.Size = new System.Drawing.Size(125, 27);
            this.tntName.TabIndex = 0;
            this.tntName.TextChanged += new System.EventHandler(this.tntName_TextChanged);
            // 
            // tmCoolDown
            // 
            this.tmCoolDown.Tick += new System.EventHandler(this.prsCoolDown_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(815, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.quytToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // quytToolStripMenuItem
            // 
            this.quytToolStripMenuItem.Name = "quytToolStripMenuItem";
            this.quytToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.quytToolStripMenuItem.Text = "Quit";
            this.quytToolStripMenuItem.Click += new System.EventHandler(this.quytToolStripMenuItem_Click);
            // 
            // btnStrart
            // 
            this.btnStrart.Location = new System.Drawing.Point(112, 111);
            this.btnStrart.Name = "btnStrart";
            this.btnStrart.Size = new System.Drawing.Size(94, 29);
            this.btnStrart.TabIndex = 6;
            this.btnStrart.Text = "START";
            this.btnStrart.UseVisualStyleBackColor = true;
            this.btnStrart.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 484);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlChessBoard);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Game Caro Lan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Show);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlChessBoard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLan;
        private System.Windows.Forms.PictureBox picBox2;
        private System.Windows.Forms.TextBox txbIP;
        private System.Windows.Forms.TextBox tntName;
        private System.Windows.Forms.Timer tmCoolDown;
        private System.Windows.Forms.ProgressBar prsCoolDown;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quytToolStripMenuItem;
        private System.Windows.Forms.Button btnStrart;
    }
}

