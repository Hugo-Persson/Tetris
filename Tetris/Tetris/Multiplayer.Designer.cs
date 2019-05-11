namespace Tetris
{
    partial class Multiplayer
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
            this.components = new System.ComponentModel.Container();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblLevelText = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHold = new System.Windows.Forms.Label();
            this.lblNext = new System.Windows.Forms.Label();
            this.lblOpponentScoreText = new System.Windows.Forms.Label();
            this.lblOpponentScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblLevel.Location = new System.Drawing.Point(87, 568);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(25, 25);
            this.lblLevel.TabIndex = 12;
            this.lblLevel.Text = "0";
            // 
            // lblLevelText
            // 
            this.lblLevelText.AutoSize = true;
            this.lblLevelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevelText.ForeColor = System.Drawing.Color.White;
            this.lblLevelText.Location = new System.Drawing.Point(82, 523);
            this.lblLevelText.Name = "lblLevelText";
            this.lblLevelText.Size = new System.Drawing.Size(69, 25);
            this.lblLevelText.TabIndex = 11;
            this.lblLevelText.Text = "Level";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblScore.Location = new System.Drawing.Point(82, 686);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(25, 25);
            this.lblScore.TabIndex = 10;
            this.lblScore.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(77, 641);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Score";
            // 
            // lblHold
            // 
            this.lblHold.AutoSize = true;
            this.lblHold.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHold.ForeColor = System.Drawing.SystemColors.Control;
            this.lblHold.Location = new System.Drawing.Point(91, 50);
            this.lblHold.Name = "lblHold";
            this.lblHold.Size = new System.Drawing.Size(60, 25);
            this.lblHold.TabIndex = 8;
            this.lblHold.Text = "Hold";
            // 
            // lblNext
            // 
            this.lblNext.AutoSize = true;
            this.lblNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNext.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNext.Location = new System.Drawing.Point(1047, 50);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(60, 25);
            this.lblNext.TabIndex = 7;
            this.lblNext.Text = "Next";
            // 
            // lblOpponentScoreText
            // 
            this.lblOpponentScoreText.AutoSize = true;
            this.lblOpponentScoreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpponentScoreText.ForeColor = System.Drawing.SystemColors.Control;
            this.lblOpponentScoreText.Location = new System.Drawing.Point(1052, 652);
            this.lblOpponentScoreText.Name = "lblOpponentScoreText";
            this.lblOpponentScoreText.Size = new System.Drawing.Size(189, 25);
            this.lblOpponentScoreText.TabIndex = 13;
            this.lblOpponentScoreText.Text = "Opponent Score:";
            // 
            // lblOpponentScore
            // 
            this.lblOpponentScore.AutoSize = true;
            this.lblOpponentScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpponentScore.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblOpponentScore.Location = new System.Drawing.Point(1052, 686);
            this.lblOpponentScore.Name = "lblOpponentScore";
            this.lblOpponentScore.Size = new System.Drawing.Size(25, 25);
            this.lblOpponentScore.TabIndex = 14;
            this.lblOpponentScore.Text = "0";
            // 
            // Multiplayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1870, 761);
            this.Controls.Add(this.lblOpponentScore);
            this.Controls.Add(this.lblOpponentScoreText);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblLevelText);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHold);
            this.Controls.Add(this.lblNext);
            this.Name = "Multiplayer";
            this.Text = "Multiplayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Multiplayer_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblLevelText;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHold;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Label lblOpponentScoreText;
        private System.Windows.Forms.Label lblOpponentScore;
    }
}