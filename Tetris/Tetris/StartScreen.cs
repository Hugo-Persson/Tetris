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
using System.Net;
using System.Net.Sockets;

namespace Tetris
{
    public partial class StartScreen : Form
    {
        TcpClient client = new TcpClient();
        public StartScreen()
        {
            InitializeComponent();
        }

        private void btnStarta_Click(object sender, EventArgs e)
        {
            
            SinglePlayer form1 = new SinglePlayer(this);
            
            form1.Show();
            this.Hide();
            

        }

        private void btnMultiplayer_Click(object sender, EventArgs e)
        {
            ChooseOpponent chooseOpponent = new ChooseOpponent(this);
            chooseOpponent.Show();
            Hide();

        }

        private void btnHighScore_Click(object sender, EventArgs e)
        {
            HighScore highScore = new HighScore();
            highScore.Show();
            Hide();
        }

        private void StartScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.Show();
            Hide();
          
        }
        public void StartMultiplayerGame(TcpClient client)
        {
            Multiplayer multiplayer = new Multiplayer(client,this);
            multiplayer.Show();
            Hide();
        }
        
    }
}
