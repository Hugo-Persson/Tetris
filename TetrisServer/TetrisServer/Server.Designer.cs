namespace TetrisServer
{
    partial class Server
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
            this.tbxEvents = new System.Windows.Forms.TextBox();
            this.lblEvents = new System.Windows.Forms.Label();
            this.lblErrors = new System.Windows.Forms.Label();
            this.tbxErrors = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbxEvents
            // 
            this.tbxEvents.Location = new System.Drawing.Point(30, 77);
            this.tbxEvents.Multiline = true;
            this.tbxEvents.Name = "tbxEvents";
            this.tbxEvents.ReadOnly = true;
            this.tbxEvents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxEvents.Size = new System.Drawing.Size(286, 481);
            this.tbxEvents.TabIndex = 0;
            this.tbxEvents.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // lblEvents
            // 
            this.lblEvents.AutoSize = true;
            this.lblEvents.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvents.ForeColor = System.Drawing.SystemColors.Control;
            this.lblEvents.Location = new System.Drawing.Point(25, 36);
            this.lblEvents.Name = "lblEvents";
            this.lblEvents.Size = new System.Drawing.Size(78, 25);
            this.lblEvents.TabIndex = 1;
            this.lblEvents.Text = "Events";
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrors.ForeColor = System.Drawing.SystemColors.Control;
            this.lblErrors.Location = new System.Drawing.Point(404, 36);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(70, 25);
            this.lblErrors.TabIndex = 3;
            this.lblErrors.Text = "Errors";
            // 
            // tbxErrors
            // 
            this.tbxErrors.Location = new System.Drawing.Point(409, 77);
            this.tbxErrors.Multiline = true;
            this.tbxErrors.Name = "tbxErrors";
            this.tbxErrors.ReadOnly = true;
            this.tbxErrors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxErrors.Size = new System.Drawing.Size(286, 481);
            this.tbxErrors.TabIndex = 4;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1018, 593);
            this.Controls.Add(this.tbxErrors);
            this.Controls.Add(this.lblErrors);
            this.Controls.Add(this.lblEvents);
            this.Controls.Add(this.tbxEvents);
            this.Name = "Server";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxEvents;
        private System.Windows.Forms.Label lblEvents;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.TextBox tbxErrors;
    }
}

