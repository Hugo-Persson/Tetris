namespace Tetris
{
    partial class SinglePlayerPausedGame
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
            this.btnResumeGame = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnToggleMusic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnResumeGame
            // 
            this.btnResumeGame.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnResumeGame.Location = new System.Drawing.Point(137, 65);
            this.btnResumeGame.Name = "btnResumeGame";
            this.btnResumeGame.Size = new System.Drawing.Size(578, 83);
            this.btnResumeGame.TabIndex = 6;
            this.btnResumeGame.Text = "Resume Game";
            this.btnResumeGame.UseVisualStyleBackColor = true;
            this.btnResumeGame.Click += new System.EventHandler(this.btnResumeGame_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQuit.Location = new System.Drawing.Point(137, 380);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(578, 81);
            this.btnQuit.TabIndex = 4;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnToggleMusic
            // 
            this.btnToggleMusic.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnToggleMusic.Location = new System.Drawing.Point(137, 231);
            this.btnToggleMusic.Name = "btnToggleMusic";
            this.btnToggleMusic.Size = new System.Drawing.Size(578, 79);
            this.btnToggleMusic.TabIndex = 5;
            this.btnToggleMusic.Text = "Toggle Music";
            this.btnToggleMusic.UseVisualStyleBackColor = true;
            this.btnToggleMusic.Click += new System.EventHandler(this.btnToggleMusic_Click);
            // 
            // SinglePlayerPausedGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(864, 534);
            this.Controls.Add(this.btnResumeGame);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnToggleMusic);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "SinglePlayerPausedGame";
            this.Text = "SingleplayerPausedGame";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnResumeGame;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnToggleMusic;
    }
}