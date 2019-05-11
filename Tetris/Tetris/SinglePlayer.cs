using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tetris
{
    public partial class SinglePlayer : Form
    {
        int InstantDropDistance = 0;
        Point gridTop = Shapes.startPos;
        Point startPosition;
        Shapes activeShape;
        Shapes ghostShape;
        bool musicPlaying = false;
        int[] nextShape = new int[3];
        int hold = 100;
        bool holdPossible = true;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer("Tetris.wav");
        Random random = new Random();
        bool gamePaused = false;
         
        StartScreen startScreen; 
        public SinglePlayer(StartScreen startScreen)
        {

            InitializeComponent();
            this.startScreen = startScreen;
            startPosition = new Point(gridTop.X, gridTop.Y + Shapes.gridSize);

            

            for (int i = 0; i < nextShape.Length; i++)
            {


                nextShape[i] = random.Next(7);
            }
            NewShape(out activeShape, startPosition, nextShape[0]);
            NewNextShape();
            UpdateGhostShape();
            DoubleBuffered = true;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (activeShape.MinimumY())
            {

                ReachedMinimumY();
            }
            else
            {
                activeShape.Fall();
                if (Timer.Interval == 40)
                {
                    Shapes.score++;
                    lblScore.Text = Shapes.score.ToString();
                }
            }
            
            Invalidate();



        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Background(g);

            for (int i = 0; i < nextShape.Length; i++)
            {
                Shapes shape;
                NewShape(out shape, new Point(1000, 170 + i * 140), nextShape[i]);
                shape.Draw(g);
            }



            foreach (Cubes i in Shapes.savedCubes)
            {
                i.Draw(g);
            }
            ghostShape.Draw(g);
            activeShape.Draw(g);
            if (hold != 100)
            {

                Shapes holdShape;
                NewShape(out holdShape, new Point(45, 200), hold);
                holdShape.Draw(g);
            }


        }

        void Background(Graphics g)
        {

            for (int i = 0; i < 20; i++)
            {
                for (int n = 0; n < 10; n++)
                {
                    g.DrawRectangle(new Pen(Color.LightGray), gridTop.X - Shapes.gridSize * 4 + n * Shapes.gridSize, gridTop.Y + Shapes.gridSize * i, Shapes.gridSize, Shapes.gridSize);
                }
            }
        }

        
        protected override void OnKeyDown(KeyEventArgs e)
        {

            base.OnKeyDown(e);
            
            if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Left) && !gamePaused)
            {

                activeShape.MoveLeft();
            }
            else if ((e.KeyCode == Keys.D || e.KeyCode == Keys.Right) && !gamePaused)
            {
                activeShape.MoveRight();
            }

            else if ((e.KeyCode == Keys.S || e.KeyCode == Keys.Down) && !gamePaused)
            {



                Timer.Interval = 40;

            }
            else if ((e.KeyCode == Keys.W || e.KeyCode == Keys.Up) && !gamePaused)
            {
                activeShape.Rotate();

            }
            else if ((e.KeyCode == Keys.Escape))
            {
                TooglePauseGame();
            }
            else if ((e.KeyCode == Keys.C) && !gamePaused)
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
                        NewShape(out activeShape, startPosition, nextShape[0]);
                        NewNextShape();
                    }
                    else
                    {
                        NewShape(out activeShape, startPosition, temp);
                    }
                    holdPossible = false;
                }



            }
            else if ((e.KeyCode == Keys.Space) && !gamePaused)
            {
                ghostShape.ToggleGhostShape();
                activeShape = ghostShape;
                ReachedMinimumY();
                Shapes.score += InstantDropDistance;
                lblScore.Text = Shapes.score.ToString();
            }
            UpdateGhostShape();
            Invalidate();


        }
        public void TooglePauseGame()
        {
            
            Timer.Enabled = !Timer.Enabled;
            gamePaused = !gamePaused;
            pnlGamePaused.Visible = !pnlGamePaused.Visible;
            if (gamePaused)
            {
                SinglePlayerPausedGame singlePlayerPausedGame = new SinglePlayerPausedGame(this);
                singlePlayerPausedGame.Show();
            }
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
                GameOver();
                over = true;
            }
            
            activeShape.SaveCubes();
            
            if (!over)
            {
                NewShape(out activeShape, startPosition, nextShape[0]);
                NewNextShape();
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
                
                UpdateGhostShape();
                Invalidate();
            }


            

        }
        void LoadHighScores(out HighScores highScores)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("HighScores.hs", FileMode.Open, FileAccess.Read);
            highScores = (HighScores)formatter.Deserialize(stream);
            stream.Dispose();
        }
        /// <summary>
        /// Returns the interval the timer should have
        /// </summary>
        /// <returns></returns>
        int IntervalForTimer()
        {
            return (int)(1000 * Math.Pow(0.75, Shapes.level));
        }
        /// <summary>
        /// Creates a new shape objekt and assigns that to the Shapes objekt you send, 
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="startPosition"></param>
        /// <param name="number"></param>
        void NewShape(out Shapes shape, Point startPosition, int number)
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
        /// <summary>
        /// Generate a new next shape and update the array
        /// </summary>
        void NewNextShape()
        {
            for (int i = 0; i < nextShape.Length - 1; i++)
            {
                nextShape[i] = nextShape[i + 1];
            }


            nextShape[2] = random.Next(7);


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (startScreen.Visible == false)
            {
                Application.Exit();
            }
            player.Stop();
            
            
        }
        /// <summary>
        /// Update the position of the ghost shape
        /// </summary>
        void UpdateGhostShape()
        {
            //I need to serialize and then deserialize the object because I want a deep copy and not a shallow copy
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, activeShape);

                memoryStream.Position = 0;
                ghostShape = (Shapes)binaryFormatter.Deserialize(memoryStream);
            }


            ghostShape.ToggleGhostShape();
            InstantDropDistance = 0;
            while (!ghostShape.MinimumY())
            {

                ghostShape.Fall();
                InstantDropDistance++;
            }
            Invalidate();
        }
        public void ToggleMusic()
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
        public void GoBackToStartScreen()
        {
            startScreen.Show();
            Close();
        }
        private void btnResumeGame_Click(object sender, EventArgs e)
        {
            TooglePauseGame();
        }

        private void btnToggleMusic_Click(object sender, EventArgs e)
        {
            ToggleMusic();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void GameOver()
        {
            player.Stop();
            //I check if the timer is enabled because I don't want the program to run the code twice which can happen if the timer interval is small enough

            if (Timer.Enabled)
            {
                Timer.Enabled = false;

                HighScores highScores;
                LoadHighScores(out highScores);

                //I test for 10 because it means that it is not a new highscore
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

        

    }
}
