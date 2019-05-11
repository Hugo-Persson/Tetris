using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Tetris
{
    public partial class Multiplayer : Form
    {
        bool musicPlaying = false;
        int InstantDropDistance = 0;
        Point gridTop = Shapes.startPos;
        Point startPosition;
        Shapes activeShape;
        Shapes ghostShape;

        int[] nextFigure = new int[3];
        int hold = 100;
        bool holdPossible = true;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer("Tetris.wav");
        Random random = new Random();
        bool onlyCloseForm = false;
        TcpClient client = new TcpClient();
        List<Cubes> allCubes = new List<Cubes>();
        string[,] opponentCubes = new string[10, 20];
        StartScreen startScreen;

        public Multiplayer(TcpClient client,StartScreen startScreen)
        {
            InitializeComponent();
            startPosition = new Point(gridTop.X, gridTop.Y + Shapes.gridSize);
            //player.Play();
            this.client = client;
            for (int i = 0; i < nextFigure.Length; i++)
            {


                nextFigure[i] = random.Next(7);
            }
            NewSymbol(out activeShape, startPosition, nextFigure[0]);
            UpdateNext();
            UpdateGhostShape();
            DoubleBuffered = true;
            allCubes.AddRange(activeShape.activeCubes);
            SendCubes();
            RecieveData();
            this.startScreen = startScreen;
        }
        async void RecieveData()
        {
            
            byte[] buffer = new byte[2000];
            try
            {
                await client.GetStream().ReadAsync(buffer, 0, buffer.Length);
                MemoryStream memoryStream = new MemoryStream(buffer);
                BinaryReader binaryReader = new BinaryReader(memoryStream);
                string action = binaryReader.ReadString();
                //UC means UpdateCubes
                if (action == "UC")

                {
                    string score = binaryReader.ReadString();
                    lblOpponentScore.Text = score;
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    opponentCubes = (string[,])binaryFormatter.Deserialize(memoryStream);
                }
                
                if (Visible == true)
                {
                    //DC means disconnect
                    if (action == "DC")
                    {

                        MessageBox.Show("Opponent has disconnected");
                        ReturnToStartscreen();
                    }
                    //GO means game over
                    else if (action == "GO")
                    {
                        MessageBox.Show("Opponent has lost, You win");
                        ReturnToStartscreen();
                    }
                }
                
                
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
                return;
            }

            if (Visible == true)
            {
                RecieveData();
            }
            
            
            Invalidate();

        }
        async void SendCubes()
        {
            allCubes.Clear();
            allCubes.AddRange(activeShape.activeCubes);
            allCubes.AddRange(Shapes.savedCubes);
            string[,] sendColors = new string[10,20];
            for(int n=0; n < 10; n++)
            {
                for(int c = 0; c < 20; c++)
                {
                    sendColors[n, c] = "";
                }
            }
            
            
            foreach(Cubes i in allCubes)
            {
                string color = "";
                if (i.color == Color.Cyan)
                {
                    color = "c";
                }
                else if (i.color == Color.Blue)
                {
                    color = "b";

                }
                else if (i.color == Color.Red)
                {
                    color = "r";
                }
                else if (i.color == Color.Green)
                {
                    color = "g";
                }
                else if (i.color == Color.Purple)
                {
                    color = "p";
                }
                else if (i.color == Color.Orange)
                {
                    color = "o";
                }
                else if(i.color == Color.Yellow)
                {
                    color = "y";
                }
                sendColors[Shapes.ColumnNumber(i), Shapes.RowNumber(i)] = color;
            }
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
            binaryWriter.Write("UC");
            binaryWriter.Write(Shapes.score.ToString());
            binaryFormatter.Serialize(memoryStream, sendColors);
            byte[] buffer = memoryStream.ToArray();
            
            memoryStream.Dispose();

            try
            {
                await client.GetStream().WriteAsync(buffer, 0, buffer.Count());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                Timer.Enabled = false;
                return;
                
            }
        }
        private void Multiplayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            SendDisconnect();
            if (!onlyCloseForm)
            {
                Application.Exit();
            }
            
        }




        private void Timer_Tick(object sender, EventArgs e)
        {
            if (activeShape.MinimumY())
            {

                ReachedMinimumY();
            }
            else
            {
                if (Timer.Interval == 40)
                {
                    Shapes.score++;
                    lblScore.Text = Shapes.score.ToString();
                    
                }
                activeShape.Fall();

            }
            

            Invalidate();
            SendCubes();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DrawBackground(g);

            for (int i = 0; i < nextFigure.Length; i++)
            {
                NewSymbol(out Shapes shape, new Point(1000, 170 + i * 140), nextFigure[i]);
                shape.Draw(g);
            }



            foreach (Cubes i in Shapes.savedCubes)
            {
                i.Draw(g);
            }
            ghostShape.Draw(g);
            activeShape.Draw(g);
            DrawOpponentCubes(g);
            
            if (hold != 100)
            {

                NewSymbol(out Shapes holdShape, new Point(45, 200), hold);
                holdShape.Draw(g);
            }
            

        }
        void DrawBackground(Graphics g)
        {

            for (int i = 0; i < 20; i++)
            {
                for (int n = 0; n < 10; n++)
                {
                    g.DrawRectangle(new Pen(Color.LightGray), (gridTop.X + 900) - Shapes.gridSize * 4 + n * Shapes.gridSize, gridTop.Y + Shapes.gridSize * i, Shapes.gridSize, Shapes.gridSize);
                    g.DrawRectangle(new Pen(Color.LightGray), gridTop.X - Shapes.gridSize * 4 + n * Shapes.gridSize, gridTop.Y + Shapes.gridSize * i, Shapes.gridSize, Shapes.gridSize);
                }
            }
        }
        void DrawOpponentCubes(Graphics g)
        {
            Point opponentGridStartPos = new Point(Shapes.maxLeftPos, gridTop.Y);
            List<Cubes> cubes = new List<Cubes>();
            Color color = Color.Black ;
            for(int i = 0; i < 10; i++)
            {
                for(int n = 0; n < 20; n++)
                {
                    if (opponentCubes[i, n] == "c")
                    {
                        color = Color.Cyan;
                    }
                    else if (opponentCubes[i, n] == "b")
                    {
                        color = Color.Blue;
                    }
                    else if (opponentCubes[i, n] == "r")
                    {
                        color = Color.Red;

                    }
                    else if (opponentCubes[i, n] == "g")
                    {
                        color = Color.Green;
                    }
                    else if (opponentCubes[i, n] == "p")
                    {
                        color = Color.Purple;
                    }
                    else if (opponentCubes[i, n] == "o")
                    {
                        color = Color.Orange;
                    }
                    else if (opponentCubes[i, n] == "y")
                    {
                        color = Color.Yellow;
                    }
                    if (color != Color.Black)
                    {
                        cubes.Add(new Cubes(new Point(opponentGridStartPos.X +900+ (i * Shapes.gridSize), opponentGridStartPos.Y + (n * Shapes.gridSize)), color));
                    }
                    color = Color.Black;
                }
            }
            foreach(Cubes c in cubes)
            {
                c.Draw(g);
            }
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {

            base.OnKeyDown(e);
            
            if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Left))
            {

                activeShape.MoveLeft();
            }
            else if ((e.KeyCode == Keys.D || e.KeyCode == Keys.Right))
            {
                activeShape.MoveRight();
            }

            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {



                Timer.Interval = 40;

            }
            else if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                activeShape.Rotate();

            }
            
            else if (e.KeyCode == Keys.C)
            {
                if (holdPossible)
                {

                    int temp = hold;
                    if (activeShape is Square)
                    {
                        hold = 0;
                    }
                    else if (activeShape is L1)
                    {
                        hold = 1;
                    }
                    else if (activeShape is L2)
                    {
                        hold = 2;
                    }
                    else if (activeShape is TSymbol)
                    {
                        hold = 3;
                    }
                    else if (activeShape is S1)
                    {
                        hold = 4;
                    }
                    else if (activeShape is S2)
                    {
                        hold = 5;
                    }
                    else if (activeShape is Stick)
                    {
                        hold = 6;
                    }

                    if (temp == 100)
                    {
                        NewSymbol(out activeShape, startPosition, nextFigure[0]);
                        UpdateNext();
                    }
                    else
                    {
                        NewSymbol(out activeShape, startPosition, temp);
                    }
                    holdPossible = false;
                }


                 
            }
            else if (e.KeyCode == Keys.Space)
            {
                ghostShape.ToggleGhostShape();
                activeShape = ghostShape;
                ReachedMinimumY();
                Shapes.score += InstantDropDistance;
                lblScore.Text = Shapes.score.ToString();
            }
            UpdateGhostShape();
            Invalidate();
            SendCubes();
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                Timer.Interval = IntervalForTimer();
            }

        }

        void ReachedMinimumY()
        {
            bool over = false;
            if (activeShape.currentPos == startPosition)
            {
                SendGameOver();
                GameOver();
                over = true;
            }
            activeShape.SaveCubes();
            
            
            if (!over)
            {
                NewSymbol(out activeShape, startPosition, nextFigure[0]);
                UpdateNext();
                holdPossible = true;
                Shapes.ClearRows();
                if (Shapes.clearedRows >= 10)
                {
                    Shapes.clearedRows -= 10;
                    Shapes.level++;

                    lblLevel.Text = Shapes.level.ToString();
                    Timer.Interval = IntervalForTimer();
                }
                lblScore.Text = Shapes.score.ToString();
            }


            Invalidate();

        }
        private async void SendGameOver()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
            binaryWriter.Write("GO");

            try
            {
                await client.GetStream().WriteAsync(memoryStream.ToArray(),0,memoryStream.ToArray().Length);
            }
            catch (Exception error)
            {

                MessageBox.Show(error.ToString());
                return;
            }
            memoryStream.Dispose();
            binaryWriter.Dispose();
        }
        private async void SendDisconnect()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
            binaryWriter.Write("DC");
            try
            {
                await client.GetStream().WriteAsync(memoryStream.ToArray(), 0, memoryStream.ToArray().Length);
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            memoryStream.Dispose();
            binaryWriter.Dispose();
        }
        void LoadHighScores(out HighScores highScores)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("HighScores.hs", FileMode.Open, FileAccess.Read);
            highScores = (HighScores)formatter.Deserialize(stream);
            stream.Dispose();
        }
        int IntervalForTimer()
        {
            return (int)(1000 * Math.Pow(0.75, Shapes.level));
        }
        
        void NewSymbol(out Shapes shape, Point startPosition, int number)
        {
            switch (number)
            {
                case 0:
                    shape = new Square(startPosition);
                    break;
                case 1:
                    shape = new L1(startPosition);
                    break;
                case 2:
                    shape = new L2(startPosition);
                    break;
                case 3:
                    shape = new TSymbol(startPosition);
                    break;
                case 4:
                    shape = new S1(startPosition);
                    break;
                case 5:
                    shape = new S2(startPosition);
                    break;
                case 6:
                    shape = new Stick(startPosition);
                    break;
                default:
                    shape = null;
                    MessageBox.Show("Number not valid");
                    break;
            }



        }
        void UpdateNext()
        {
            for (int i = 0; i < nextFigure.Length - 1; i++)
            {
                nextFigure[i] = nextFigure[i + 1];
            }


            nextFigure[2] = random.Next(7);
            UpdateGhostShape();

        }
        void UpdateGhostShape()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, activeShape);

                memoryStream.Position = 0;
                ghostShape = (Shapes)binaryFormatter.Deserialize(memoryStream);
            }

            InstantDropDistance = 0;
            ghostShape.ToggleGhostShape();
            while (!ghostShape.MinimumY())
            {
                InstantDropDistance++;
                ghostShape.Fall();
            }
            Invalidate();
        }
        private void GameOver()
        {
            player.Stop();
            if (Timer.Enabled)
            {
                Timer.Enabled = false;

                HighScores highScores;
                LoadHighScores(out highScores);

                //Jag testar för 10 för det betyder att scoret inte är större än något highscore
                if (highScores.CheckForNewHighScore(Shapes.score) == 10)
                {
                    GameOver gameOver = new GameOver();
                    Hide();
                    gameOver.Show();
                }
                else if (highScores.CheckForNewHighScore(Shapes.score) <= 4)
                {
                    NewHighScore newHighScore = new NewHighScore();
                    Hide();
                    newHighScore.Show();
                }
                else
                {
                    MessageBox.Show("CheckForNewHighScore error");
                }



               
            }
        }
        private void ToggleMusic()
        {
            if (musicPlaying)
            {
                player.Stop();
                musicPlaying = false;
            }
            else
            {
                player.PlayLooping();
                musicPlaying = true;
            }
        }
        private void ReturnToStartscreen()
        {
            startScreen.Show();
            onlyCloseForm = true;
            Close();

        }

    }
}
