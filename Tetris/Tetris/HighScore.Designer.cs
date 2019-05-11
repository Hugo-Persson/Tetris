namespace Tetris
{
    partial class HighScore
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
            this.lblHighsScore = new System.Windows.Forms.Label();
            this.btnStartScreen = new System.Windows.Forms.Button();
            this.tbxHighScores = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblHighsScore
            // 
            this.lblHighsScore.AutoSize = true;
            this.lblHighsScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighsScore.ForeColor = System.Drawing.SystemColors.Control;
            this.lblHighsScore.Location = new System.Drawing.Point(459, 9);
            this.lblHighsScore.Name = "lblHighsScore";
            this.lblHighsScore.Size = new System.Drawing.Size(272, 55);
            this.lblHighsScore.TabIndex = 0;
            this.lblHighsScore.Text = "High Score";
            // 
            // btnStartScreen
            // 
            this.btnStartScreen.Location = new System.Drawing.Point(301, 676);
            this.btnStartScreen.Name = "btnStartScreen";
            this.btnStartScreen.Size = new System.Drawing.Size(586, 56);
            this.btnStartScreen.TabIndex = 2;
            this.btnStartScreen.Text = "Start Screen";
            this.btnStartScreen.UseVisualStyleBackColor = true;
            this.btnStartScreen.Click += new System.EventHandler(this.btnStartScreen_Click);
            // 
            // tbxHighScores
            // 
            this.tbxHighScores.BackColor = System.Drawing.SystemColors.InfoText;
            this.tbxHighScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxHighScores.ForeColor = System.Drawing.SystemColors.Window;
            this.tbxHighScores.Location = new System.Drawing.Point(301, 150);
            this.tbxHighScores.Multiline = true;
            this.tbxHighScores.Name = "tbxHighScores";
            this.tbxHighScores.ReadOnly = true;
            this.tbxHighScores.Size = new System.Drawing.Size(586, 357);
            this.tbxHighScores.TabIndex = 3;
            // 
            // HighScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1184, 762);
            this.Controls.Add(this.tbxHighScores);
            this.Controls.Add(this.btnStartScreen);
            this.Controls.Add(this.lblHighsScore);
            this.Name = "HighScore";
            this.Text = "HighScore";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HighScore_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHighsScore;
        private System.Windows.Forms.Button btnStartScreen;
        private System.Windows.Forms.TextBox tbxHighScores;
    }
}