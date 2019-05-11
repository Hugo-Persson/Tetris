namespace Tetris
{
    partial class StartScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScreen));
            this.btnSingleplayer = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnHighScore = new System.Windows.Forms.Button();
            this.btnMultiplayer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSingleplayer
            // 
            this.btnSingleplayer.Location = new System.Drawing.Point(319, 342);
            this.btnSingleplayer.Name = "btnSingleplayer";
            this.btnSingleplayer.Size = new System.Drawing.Size(503, 77);
            this.btnSingleplayer.TabIndex = 0;
            this.btnSingleplayer.Text = "Singleplayer";
            this.btnSingleplayer.UseVisualStyleBackColor = true;
            this.btnSingleplayer.Click += new System.EventHandler(this.btnStarta_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(319, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(503, 324);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnInfo
            // 
            this.btnInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnInfo.Location = new System.Drawing.Point(319, 550);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(503, 71);
            this.btnInfo.TabIndex = 2;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnHighScore
            // 
            this.btnHighScore.Location = new System.Drawing.Point(319, 653);
            this.btnHighScore.Name = "btnHighScore";
            this.btnHighScore.Size = new System.Drawing.Size(503, 73);
            this.btnHighScore.TabIndex = 3;
            this.btnHighScore.Text = "Highscore";
            this.btnHighScore.UseVisualStyleBackColor = true;
            this.btnHighScore.Click += new System.EventHandler(this.btnHighScore_Click);
            // 
            // btnMultiplayer
            // 
            this.btnMultiplayer.Location = new System.Drawing.Point(319, 446);
            this.btnMultiplayer.Name = "btnMultiplayer";
            this.btnMultiplayer.Size = new System.Drawing.Size(503, 76);
            this.btnMultiplayer.TabIndex = 4;
            this.btnMultiplayer.Text = "Multiplayer";
            this.btnMultiplayer.UseVisualStyleBackColor = true;
            this.btnMultiplayer.Click += new System.EventHandler(this.btnMultiplayer_Click);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1184, 762);
            this.Controls.Add(this.btnMultiplayer);
            this.Controls.Add(this.btnHighScore);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSingleplayer);
            this.Name = "StartScreen";
            this.Text = "StartScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartScreen_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSingleplayer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnHighScore;
        private System.Windows.Forms.Button btnMultiplayer;
    }
}