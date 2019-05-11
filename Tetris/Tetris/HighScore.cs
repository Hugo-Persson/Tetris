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
    public partial class HighScore : Form
    {
        HighScores highScores;
        public HighScore()
        {
            InitializeComponent();
            
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("HighScores.hs", FileMode.Open, FileAccess.Read);
            highScores = (HighScores)formatter.Deserialize(stream);
            stream.Dispose();
            tbxHighScores.Text = highScores.ToString();
        }


        private void HighScore_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnStartScreen_Click(object sender, EventArgs e)
        {
            StartScreen startScreen = new StartScreen();
            Hide();
            startScreen.Show();
        }
    }
}
