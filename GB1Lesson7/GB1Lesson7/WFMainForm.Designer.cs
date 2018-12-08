namespace GB1Lesson7
{
    partial class WFMainForm
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
            this.MainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.gameDoublerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gameGuessNumberToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MainMenu
            // 
            this.MainMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameDoublerToolStripMenuItem1,
            this.gameGuessNumberToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(50, 20);
            this.MainMenu.Text = "Menu";
            // 
            // gameDoublerToolStripMenuItem1
            // 
            this.gameDoublerToolStripMenuItem1.Name = "gameDoublerToolStripMenuItem1";
            this.gameDoublerToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.gameDoublerToolStripMenuItem1.Text = "Game Doubler";
            this.gameDoublerToolStripMenuItem1.Click += new System.EventHandler(this.MenuItemGameDoubler_Click);
            // 
            // gameGuessNumberToolStripMenuItem1
            // 
            this.gameGuessNumberToolStripMenuItem1.Name = "gameGuessNumberToolStripMenuItem1";
            this.gameGuessNumberToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.gameGuessNumberToolStripMenuItem1.Text = "Game Guess Number";
            this.gameGuessNumberToolStripMenuItem1.Click += new System.EventHandler(this.MenuItemGameGuessNumber_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // WFMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 454);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WFMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MainMenu;
        private System.Windows.Forms.ToolStripMenuItem gameDoublerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gameGuessNumberToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}