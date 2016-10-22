namespace TycoopolisContracts
{
    partial class OptionsWindow
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
            this.lblSavepath = new System.Windows.Forms.Label();
            this.txtSavepath = new System.Windows.Forms.TextBox();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSavepath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSavepath
            // 
            this.lblSavepath.AutoSize = true;
            this.lblSavepath.Location = new System.Drawing.Point(13, 17);
            this.lblSavepath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSavepath.Name = "lblSavepath";
            this.lblSavepath.Size = new System.Drawing.Size(79, 20);
            this.lblSavepath.TabIndex = 0;
            this.lblSavepath.Text = "Save-path:";
            // 
            // txtSavepath
            // 
            this.txtSavepath.Location = new System.Drawing.Point(107, 14);
            this.txtSavepath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSavepath.Name = "txtSavepath";
            this.txtSavepath.ReadOnly = true;
            this.txtSavepath.Size = new System.Drawing.Size(412, 27);
            this.txtSavepath.TabIndex = 1;
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(381, 51);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(170, 35);
            this.btnAbort.TabIndex = 2;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(203, 51);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(170, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSavepath
            // 
            this.btnSavepath.Location = new System.Drawing.Point(524, 14);
            this.btnSavepath.Margin = new System.Windows.Forms.Padding(1);
            this.btnSavepath.Name = "btnSavepath";
            this.btnSavepath.Size = new System.Drawing.Size(27, 27);
            this.btnSavepath.TabIndex = 4;
            this.btnSavepath.Text = "...";
            this.btnSavepath.UseVisualStyleBackColor = true;
            this.btnSavepath.Click += new System.EventHandler(this.btnSavepath_Click);
            // 
            // OptionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 96);
            this.Controls.Add(this.btnSavepath);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.txtSavepath);
            this.Controls.Add(this.lblSavepath);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "OptionsWindow";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSavepath;
        private System.Windows.Forms.TextBox txtSavepath;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSavepath;
    }
}