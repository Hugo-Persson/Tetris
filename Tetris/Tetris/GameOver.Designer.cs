namespace Tetris
{
    partial class GameOver
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
            this.btnStartScreen = new System.Windows.Forms.Button();
            this.lblGameOver = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.tbxHighScores = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStartScreen
            // 
            this.btnStartScreen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStartScreen.Location = new System.Drawing.Point(264, 670);
            this.btnStartScreen.Name = "btnStartScreen";
            this.btnStartScreen.Size = new System.Drawing.Size(586, 56);
            this.btnStartScreen.TabIndex = 5;
            this.btnStartScreen.Text = "Start Screen";
            this.btnStartScreen.UseVisualStyleBackColor = true;
            this.btnStartScreen.Click += new System.EventHandler(this.btnStartScreen_Click);
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver.ForeColor = System.Drawing.SystemColors.Control;
            this.lblGameOver.Location = new System.Drawing.Point(415, 19);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(281, 55);
            this.lblGameOver.TabIndex = 3;
            this.lblGameOver.Text = "Game Over";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(264, 92);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(83, 29);
            this.lblScore.TabIndex = 6;
            this.lblScore.Text = "Score:";
            // 
            // tbxHighScores
            // 
            this.tbxHighScores.BackColor = System.Drawing.SystemColors.InfoText;
            this.tbxHighScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxHighScores.ForeColor = System.Drawing.SystemColors.Window;
            this.tbxHighScores.Location = new System.Drawing.Point(264, 192);
            this.tbxHighScores.Multiline = true;
            this.tbxHighScores.Name = "tbxHighScores";
            this.tbxHighScores.ReadOnly = true;
            this.tbxHighScores.Size = new System.Drawing.Size(586, 357);
            this.tbxHighScores.TabIndex = 7;
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.tbxHighScores);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnStartScreen);
            this.Controls.Add(this.lblGameOver);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "GameOver";
            this.Text = "GameOver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameOver_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartScreen;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.TextBox tbxHighScores;
    }
}