namespace GB1Lesson7
{
    partial class WFDoubler
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
            this.ButtonPlusOne = new System.Windows.Forms.Button();
            this.ButtonMultiplyByTwo = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.LabelCurrentNumber = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ListLastOperations = new System.Windows.Forms.ListView();
            this.LabelLastOperations = new System.Windows.Forms.Label();
            this.ButtonRevert = new System.Windows.Forms.Button();
            this.LabelCurrent = new System.Windows.Forms.Label();
            this.LabelExpected = new System.Windows.Forms.Label();
            this.LabelExpectedNumber = new System.Windows.Forms.Label();
            this.LabelTotalOperations = new System.Windows.Forms.Label();
            this.LabelTotalOperationsCount = new System.Windows.Forms.Label();
            this.LabelGameStatusBar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonPlusOne
            // 
            this.ButtonPlusOne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonPlusOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonPlusOne.Location = new System.Drawing.Point(12, 40);
            this.ButtonPlusOne.Name = "ButtonPlusOne";
            this.ButtonPlusOne.Size = new System.Drawing.Size(100, 30);
            this.ButtonPlusOne.TabIndex = 0;
            this.ButtonPlusOne.Text = "+1";
            this.ButtonPlusOne.UseVisualStyleBackColor = true;
            this.ButtonPlusOne.Click += new System.EventHandler(this.ButtonPlusOne_Click);
            // 
            // ButtonMultiplyByTwo
            // 
            this.ButtonMultiplyByTwo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonMultiplyByTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonMultiplyByTwo.Location = new System.Drawing.Point(12, 80);
            this.ButtonMultiplyByTwo.Name = "ButtonMultiplyByTwo";
            this.ButtonMultiplyByTwo.Size = new System.Drawing.Size(100, 30);
            this.ButtonMultiplyByTwo.TabIndex = 1;
            this.ButtonMultiplyByTwo.Text = "x2";
            this.ButtonMultiplyByTwo.UseVisualStyleBackColor = true;
            this.ButtonMultiplyByTwo.Click += new System.EventHandler(this.ButtonMultiplyByTwo_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonReset.Location = new System.Drawing.Point(12, 120);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(100, 30);
            this.ButtonReset.TabIndex = 2;
            this.ButtonReset.Text = "Reset";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // LabelCurrentNumber
            // 
            this.LabelCurrentNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelCurrentNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelCurrentNumber.Location = new System.Drawing.Point(115, 61);
            this.LabelCurrentNumber.Margin = new System.Windows.Forms.Padding(0);
            this.LabelCurrentNumber.Name = "LabelCurrentNumber";
            this.LabelCurrentNumber.Size = new System.Drawing.Size(100, 37);
            this.LabelCurrentNumber.TabIndex = 3;
            this.LabelCurrentNumber.Text = "200";
            this.LabelCurrentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemNewGame,
            this.MenuItemExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(330, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemNewGame
            // 
            this.MenuItemNewGame.Name = "MenuItemNewGame";
            this.MenuItemNewGame.Size = new System.Drawing.Size(76, 20);
            this.MenuItemNewGame.Text = "New game";
            this.MenuItemNewGame.Click += new System.EventHandler(this.MenuItemNewGame_Click);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.Size = new System.Drawing.Size(72, 20);
            this.MenuItemExit.Text = "End game";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // ListLastOperations
            // 
            this.ListLastOperations.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListLastOperations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListLastOperations.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListLastOperations.HoverSelection = true;
            this.ListLastOperations.LabelWrap = false;
            this.ListLastOperations.Location = new System.Drawing.Point(224, 42);
            this.ListLastOperations.MultiSelect = false;
            this.ListLastOperations.Name = "ListLastOperations";
            this.ListLastOperations.Scrollable = false;
            this.ListLastOperations.ShowGroups = false;
            this.ListLastOperations.Size = new System.Drawing.Size(21, 108);
            this.ListLastOperations.TabIndex = 5;
            this.ListLastOperations.TileSize = new System.Drawing.Size(10, 10);
            this.ListLastOperations.UseCompatibleStateImageBehavior = false;
            this.ListLastOperations.View = System.Windows.Forms.View.SmallIcon;
            // 
            // LabelLastOperations
            // 
            this.LabelLastOperations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelLastOperations.Location = new System.Drawing.Point(253, 43);
            this.LabelLastOperations.Name = "LabelLastOperations";
            this.LabelLastOperations.Size = new System.Drawing.Size(66, 28);
            this.LabelLastOperations.TabIndex = 6;
            this.LabelLastOperations.Text = "operations stack";
            this.LabelLastOperations.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonRevert
            // 
            this.ButtonRevert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonRevert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonRevert.Location = new System.Drawing.Point(256, 112);
            this.ButtonRevert.Name = "ButtonRevert";
            this.ButtonRevert.Size = new System.Drawing.Size(63, 38);
            this.ButtonRevert.TabIndex = 7;
            this.ButtonRevert.Text = "Revert";
            this.ButtonRevert.UseVisualStyleBackColor = true;
            this.ButtonRevert.Click += new System.EventHandler(this.ButtonRevert_Click);
            // 
            // LabelCurrent
            // 
            this.LabelCurrent.AutoSize = true;
            this.LabelCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelCurrent.Location = new System.Drawing.Point(145, 42);
            this.LabelCurrent.Name = "LabelCurrent";
            this.LabelCurrent.Size = new System.Drawing.Size(47, 13);
            this.LabelCurrent.TabIndex = 8;
            this.LabelCurrent.Text = "current";
            this.LabelCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelExpected
            // 
            this.LabelExpected.AutoSize = true;
            this.LabelExpected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelExpected.Location = new System.Drawing.Point(139, 111);
            this.LabelExpected.Name = "LabelExpected";
            this.LabelExpected.Size = new System.Drawing.Size(59, 13);
            this.LabelExpected.TabIndex = 9;
            this.LabelExpected.Text = "expected";
            this.LabelExpected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelExpectedNumber
            // 
            this.LabelExpectedNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelExpectedNumber.Location = new System.Drawing.Point(122, 125);
            this.LabelExpectedNumber.Name = "LabelExpectedNumber";
            this.LabelExpectedNumber.Size = new System.Drawing.Size(90, 25);
            this.LabelExpectedNumber.TabIndex = 10;
            this.LabelExpectedNumber.Text = "200";
            this.LabelExpectedNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelTotalOperations
            // 
            this.LabelTotalOperations.AutoSize = true;
            this.LabelTotalOperations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelTotalOperations.Location = new System.Drawing.Point(256, 90);
            this.LabelTotalOperations.Name = "LabelTotalOperations";
            this.LabelTotalOperations.Size = new System.Drawing.Size(32, 13);
            this.LabelTotalOperations.TabIndex = 11;
            this.LabelTotalOperations.Text = "total";
            this.LabelTotalOperations.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelTotalOperationsCount
            // 
            this.LabelTotalOperationsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelTotalOperationsCount.Location = new System.Drawing.Point(287, 84);
            this.LabelTotalOperationsCount.Name = "LabelTotalOperationsCount";
            this.LabelTotalOperationsCount.Size = new System.Drawing.Size(26, 22);
            this.LabelTotalOperationsCount.TabIndex = 11;
            this.LabelTotalOperationsCount.Text = "0";
            this.LabelTotalOperationsCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelGameStatusBar
            // 
            this.LabelGameStatusBar.Enabled = false;
            this.LabelGameStatusBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelGameStatusBar.ForeColor = System.Drawing.Color.Blue;
            this.LabelGameStatusBar.Location = new System.Drawing.Point(5, 157);
            this.LabelGameStatusBar.Name = "LabelGameStatusBar";
            this.LabelGameStatusBar.Size = new System.Drawing.Size(320, 17);
            this.LabelGameStatusBar.TabIndex = 12;
            this.LabelGameStatusBar.Text = "Get expected number in minimum actions!";
            this.LabelGameStatusBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(245, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(9, 7);
            this.label1.TabIndex = 13;
            this.label1.Text = "<";
            // 
            // WFDoubler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 177);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelGameStatusBar);
            this.Controls.Add(this.LabelTotalOperationsCount);
            this.Controls.Add(this.LabelTotalOperations);
            this.Controls.Add(this.LabelExpectedNumber);
            this.Controls.Add(this.LabelExpected);
            this.Controls.Add(this.LabelCurrent);
            this.Controls.Add(this.ButtonRevert);
            this.Controls.Add(this.LabelLastOperations);
            this.Controls.Add(this.ListLastOperations);
            this.Controls.Add(this.LabelCurrentNumber);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.ButtonMultiplyByTwo);
            this.Controls.Add(this.ButtonPlusOne);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WFDoubler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Doubler Game";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonPlusOne;
        private System.Windows.Forms.Button ButtonMultiplyByTwo;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Label LabelCurrentNumber;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNewGame;
        private System.Windows.Forms.ListView ListLastOperations;
        private System.Windows.Forms.Label LabelLastOperations;
        private System.Windows.Forms.Button ButtonRevert;
        private System.Windows.Forms.Label LabelCurrent;
        private System.Windows.Forms.Label LabelExpected;
        private System.Windows.Forms.Label LabelExpectedNumber;
        private System.Windows.Forms.Label LabelTotalOperations;
        private System.Windows.Forms.Label LabelTotalOperationsCount;
        private System.Windows.Forms.Label LabelGameStatusBar;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.Label label1;
    }
}

