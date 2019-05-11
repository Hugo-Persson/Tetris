using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tetris
{
    public partial class GameOver : Form
    {
        HighScores highScores;
        public GameOver()
        {
            InitializeComponent();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("HighScores.hs", FileMode.Open, FileAccess.Read);
            highScores = (HighScores)formatter.Deserialize(stream);
            stream.Dispose();
            lblScore.Text += Shapes.score;
            tbxHighScores.Text = highScores.ToString();

        }

        private void btnStartScreen_Click(object sender, EventArgs e)
        {
            Shapes.level = 0;
            Shapes.score = 0;
            Shapes.savedCubes.Clear();
            Shapes.clearedRows = 0;

            StartScreen startScreen = new StartScreen();
            Hide();
            startScreen.Show();
        }

        private void GameOver_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
