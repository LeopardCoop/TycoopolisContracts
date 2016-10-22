namespace TycoopolisContracts
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contractsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cldCalender = new System.Windows.Forms.MonthCalendar();
            this.clstTodo = new System.Windows.Forms.CheckedListBox();
            this.lblTodo = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(564, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contractsToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // contractsToolStripMenuItem
            // 
            this.contractsToolStripMenuItem.Name = "contractsToolStripMenuItem";
            this.contractsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.contractsToolStripMenuItem.Text = "Contracts";
            this.contractsToolStripMenuItem.Click += new System.EventHandler(this.contractsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // cldCalender
            // 
            this.cldCalender.Location = new System.Drawing.Point(18, 33);
            this.cldCalender.Name = "cldCalender";
            this.cldCalender.TabIndex = 1;
            this.cldCalender.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.cldCalender_DateChanged);
            // 
            // clstTodo
            // 
            this.clstTodo.FormattingEnabled = true;
            this.clstTodo.Location = new System.Drawing.Point(208, 59);
            this.clstTodo.Name = "clstTodo";
            this.clstTodo.Size = new System.Drawing.Size(344, 136);
            this.clstTodo.TabIndex = 2;
            this.clstTodo.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clstTodo_ItemCheck);
            // 
            // lblTodo
            // 
            this.lblTodo.AutoSize = true;
            this.lblTodo.Location = new System.Drawing.Point(204, 36);
            this.lblTodo.Name = "lblTodo";
            this.lblTodo.Size = new System.Drawing.Size(120, 20);
            this.lblTodo.TabIndex = 3;
            this.lblTodo.Text = "today\'s todo-list:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 208);
            this.Controls.Add(this.lblTodo);
            this.Controls.Add(this.clstTodo);
            this.Controls.Add(this.cldCalender);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Text = "TycoopolisContracts";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contractsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.MonthCalendar cldCalender;
        private System.Windows.Forms.CheckedListBox clstTodo;
        private System.Windows.Forms.Label lblTodo;
    }
}

