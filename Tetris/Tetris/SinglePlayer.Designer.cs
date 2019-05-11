namespace Tetris
{
    partial class SinglePlayer
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
            this.lblNext = new System.Windows.Forms.Label();
            this.lblHold = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblLevelText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlGamePaused = new System.Windows.Forms.Panel();
            this.pnlGamePaused.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // lblNext
            // 
            this.lblNext.AutoSize = true;
            this.lblNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNext.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNext.Location = new System.Drawing.Point(989, 49);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(60, 25);
            this.lblNext.TabIndex = 1;
            this.lblNext.Text = "Next";
            // 
            // lblHold
            // 
            this.lblHold.AutoSize = true;
            this.lblHold.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHold.ForeColor = System.Drawing.SystemColors.Control;
            this.lblHold.Location = new System.Drawing.Point(33, 49);
            this.lblHold.Name = "lblHold";
            this.lblHold.Size = new System.Drawing.Size(60, 25);
            this.lblHold.TabIndex = 2;
            this.lblHold.Text = "Hold";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 640);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Score";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblScore.Location = new System.Drawing.Point(24, 685);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(25, 25);
            this.lblScore.TabIndex = 4;
            this.lblScore.Text = "0";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblLevel.Location = new System.Drawing.Point(29, 567);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(25, 25);
            this.lblLevel.TabIndex = 6;
            this.lblLevel.Text = "0";
            // 
            // lblLevelText
            // 
            this.lblLevelText.AutoSize = true;
            this.lblLevelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevelText.ForeColor = System.Drawing.Color.White;
            this.lblLevelText.Location = new System.Drawing.Point(24, 522);
            this.lblLevelText.Name = "lblLevelText";
            this.lblLevelText.Size = new System.Drawing.Size(69, 25);
            this.lblLevelText.TabIndex = 5;
            this.lblLevelText.Text = "Level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(667, 108);
            this.label2.TabIndex = 0;
            this.label2.Text = "Game Paused";
            // 
            // pnlGamePaused
            // 
            this.pnlGamePaused.Controls.Add(this.label2);
            this.pnlGamePaused.ForeColor = System.Drawing.SystemColors.Control;
            this.pnlGamePaused.Location = new System.Drawing.Point(1, 12);
            this.pnlGamePaused.Name = "pnlGamePaused";
            this.pnlGamePaused.Size = new System.Drawing.Size(1183, 748);
            this.pnlGamePaused.TabIndex = 8;
            this.pnlGamePaused.Visible = false;
            // 
            // SinglePlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1184, 762);
            this.Controls.Add(this.pnlGamePaused);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblLevelText);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHold);
            this.Controls.Add(this.lblNext);
            this.Name = "SinglePlayer";
            this.Text = "Tetris";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.pnlGamePaused.ResumeLayout(false);
            this.pnlGamePaused.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Label lblHold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblLevelText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlGamePaused;
    }
}

