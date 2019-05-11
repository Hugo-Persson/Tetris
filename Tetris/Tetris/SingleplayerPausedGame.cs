using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class SinglePlayerPausedGame : Form
    {
        SinglePlayer singlePlayer;
        public SinglePlayerPausedGame(SinglePlayer singlePlayer)
        {
            InitializeComponent();
            this.singlePlayer = singlePlayer;
        }

        private void btnResumeGame_Click(object sender, EventArgs e)
        {
            singlePlayer.TooglePauseGame();
            Close();
        }

        private void btnToggleMusic_Click(object sender, EventArgs e)
        {
            singlePlayer.ToggleMusic();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            singlePlayer.GoBackToStartScreen();
            //I clear the static values of shapes
            Shapes.level = 0;
            Shapes.score = 0;
            Shapes.savedCubes.Clear();
            Shapes.clearedRows = 0;
            Close();
        }
    }
}
