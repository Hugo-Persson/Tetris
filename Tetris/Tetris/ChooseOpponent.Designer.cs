namespace Tetris
{
    partial class ChooseOpponent
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
            this.lbxOpponents = new System.Windows.Forms.ListBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.gbxRegister = new System.Windows.Forms.GroupBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.gbxRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxOpponents
            // 
            this.lbxOpponents.BackColor = System.Drawing.SystemColors.InfoText;
            this.lbxOpponents.ColumnWidth = 300;
            this.lbxOpponents.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxOpponents.ForeColor = System.Drawing.SystemColors.Window;
            this.lbxOpponents.FormattingEnabled = true;
            this.lbxOpponents.ItemHeight = 25;
            this.lbxOpponents.Items.AddRange(new object[] {
            "Error"});
            this.lbxOpponents.Location = new System.Drawing.Point(78, 162);
            this.lbxOpponents.MultiColumn = true;
            this.lbxOpponents.Name = "lbxOpponents";
            this.lbxOpponents.Size = new System.Drawing.Size(1039, 529);
            this.lbxOpponents.TabIndex = 0;
            this.lbxOpponents.Visible = false;
            this.lbxOpponents.SelectedIndexChanged += new System.EventHandler(this.lbxOpponents_SelectedIndexChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConnect.Location = new System.Drawing.Point(999, 710);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(118, 40);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Visible = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // gbxRegister
            // 
            this.gbxRegister.BackColor = System.Drawing.SystemColors.Control;
            this.gbxRegister.Controls.Add(this.btnRegister);
            this.gbxRegister.Controls.Add(this.tbxName);
            this.gbxRegister.Controls.Add(this.lblName);
            this.gbxRegister.Location = new System.Drawing.Point(182, 13);
            this.gbxRegister.Name = "gbxRegister";
            this.gbxRegister.Size = new System.Drawing.Size(835, 127);
            this.gbxRegister.TabIndex = 2;
            this.gbxRegister.TabStop = false;
            this.gbxRegister.Text = "Register";
            // 
            // btnRegister
            // 
            this.btnRegister.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRegister.Location = new System.Drawing.Point(562, 40);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(142, 38);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxName.Location = new System.Drawing.Point(202, 40);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(276, 38);
            this.tbxName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblName.Location = new System.Drawing.Point(30, 40);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(86, 31);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // ChooseOpponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1184, 762);
            this.Controls.Add(this.gbxRegister);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lbxOpponents);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Name = "ChooseOpponent";
            this.Text = "ChooseOpponent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChooseOpponent_FormClosing);
            this.gbxRegister.ResumeLayout(false);
            this.gbxRegister.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxOpponents;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox gbxRegister;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label lblName;
    }
}