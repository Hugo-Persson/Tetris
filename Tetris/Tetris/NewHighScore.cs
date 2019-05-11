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
    public partial class NewHighScore : Form
    {
        public NewHighScore()
        {
            InitializeComponent();
            lblScore.Text += " " + Shapes.score;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HighScores highScores;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("HighScores.hs", FileMode.Open, FileAccess.Read);
            highScores = (HighScores)formatter.Deserialize(stream);
            stream.Dispose();
            Stream saveStream = new FileStream("HighScores.hs", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            highScores.ChangeHighScore(highScores.CheckForNewHighScore(Shapes.score), tbxName.Text, Shapes.score);
            formatter.Serialize(saveStream, highScores);
            saveStream.Dispose();

            GameOver gameOver = new GameOver();
            
            Hide();
            gameOver.Show();
            
        }
    }
}
