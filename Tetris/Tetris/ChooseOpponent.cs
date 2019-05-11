using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisMultiplayer;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading;


namespace Tetris
{
    public partial class ChooseOpponent : Form
    {
        List<User> opponents;
        TcpClient client = new TcpClient();
        TcpClient opponentForGame = new TcpClient();
        StartScreen startScreen;
        TcpListener listener;
        bool openMultiplayer = false;
        string name;

        public ChooseOpponent(StartScreen startScreen)
        {
            InitializeComponent();
            this.startScreen = startScreen;
            ConnectToServer();
        }
        private async void ConnectToServer()
        {
            
            try
            {
                
                IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
                await client.ConnectAsync(iPAddress, 5001);
                
                RecieveData();
                
                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());

            }

        }

        private async void RecieveData()
        {
            byte[] buffer = new byte[1024];

            try
            {
                await client.GetStream().ReadAsync(buffer, 0, buffer.Length);
                MemoryStream memoryStream = new MemoryStream(buffer);
                BinaryReader reader = new BinaryReader(memoryStream);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                string action = reader.ReadString();
                
                //RP means Request to Play
                if (action == "RP")
                {
                    int fromIndex = reader.ReadInt16();
                    string fromName = "Unknown user";
                    foreach(User i in opponents)
                    {
                        if (i.index == fromIndex)
                        {
                            fromName = i.name;
                        }
                    }

                    DialogResult answer = MessageBox.Show("Do you want to play with " + fromName, "Request to play", MessageBoxButtons.YesNo);
                    if (answer == DialogResult.Yes)
                    {
                        
                        AnswerToPlay(fromIndex, true);
                        IPAddress iPAddress = null;
                        foreach (User i in opponents)
                        {
                            if (fromIndex == i.index)
                            {
                                iPAddress = i.iPAdress;
                            }

                        }
                        if (iPAddress == null)
                        {
                            MessageBox.Show("Error in Request to play");
                        }
                        else
                        {
                            WaitForConnection(iPAddress);
                        }
                        
                    }
                    else
                    {
                    
                        AnswerToPlay(fromIndex, false);
                    }
                }
                //AP means Answer to Play
                else if (action == "AP")
                {
                    
                    bool answer = reader.ReadBoolean();
                    
                    int fromIndex = reader.ReadInt16();
                    if (answer)
                    {
                        
                        IPAddress iPAddress = null;
                        
                        foreach(User i in opponents)
                        {
                            
                            if (fromIndex == i.index)
                            {
                                
                                iPAddress = i.iPAdress;
                            }
                            
                        }
                        if (iPAddress == null)
                        {
                            MessageBox.Show("Error index is not valid in Answer to Play");
                        }
                        else
                        {
                            ConnectToOpponent(iPAddress);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("The user declined your offer to play");
                    }
                }
                //UU mean Update Users
                else if (action == "UU")
                {
                    opponents = (List<User>)binaryFormatter.Deserialize(memoryStream);
                    
                    UpdateListBox();
                }
                //NU means new user
                else if (action == "NU")
                {
                    opponents.Add((User)binaryFormatter.Deserialize(memoryStream));
                    UpdateListBox();
                }
                else if (action == "RM")
                {
                    int fromIndex = reader.ReadInt16();
                    for (int i = 0; i < opponents.Count; i++)
                    {
                        if (opponents[i].index == fromIndex)
                        {
                            opponents.RemoveAt(i);
                        }
                    }
                    UpdateListBox();
                }
                RecieveData();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            
        }
        private void UpdateListBox()
        {
            lbxOpponents.Items.Clear();
            foreach (User i in opponents)
            {
                lbxOpponents.Items.Add(i.name);
            }
            
        }

        private void ChooseOpponent_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemoveThisUser();
            
            //I need to check if it is null because one of the players listener will be null and one won't be
            if (listener != null)
            {
                //I need to stop the listener so the same computer can connect multiple times
                listener.Stop();
            }
            
            //I don't want the entire program to shut down when I call the method Close()
            if (!openMultiplayer)
            {
                Application.Exit();
            }
            
            
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            RequestToPlay(opponents[lbxOpponents.SelectedIndex].index);
            
        }

        private void lbxOpponents_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConnect.Enabled = true;
        }
        private async void RegisterUser()
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
                binaryWriter.Write("RU");
                binaryWriter.Write(name);
                byte[] buffer = memoryStream.ToArray();
                await client.GetStream().WriteAsync(buffer, 0, buffer.Length);

            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        private async void AnswerToPlay(int index, bool answer)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
                
                binaryWriter.Write("AP");
                binaryWriter.Write((Int16)index);
                
                binaryWriter.Write(answer);
                byte[] buffer = memoryStream.ToArray();
                await client.GetStream().WriteAsync(buffer, 0, buffer.Length);


            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());

            }




        }
        private async void RequestToPlay(int index)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
                binaryWriter.Write("RP");
                binaryWriter.Write(index);
                byte[] buffer = memoryStream.ToArray();
                await client.GetStream().WriteAsync(buffer, 0, buffer.Length);

            }
            catch (Exception error)
            {

                MessageBox.Show(error.ToString());
            }
            

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string input = tbxName.Text;
            if (input == "")
            {
                MessageBox.Show("Please choose a name");
                return;
            }
            if (opponents != null)
            {
                foreach (User i in opponents)
                {
                    if (input == i.name)
                    {
                        MessageBox.Show("Somebody already has that name, please choose some other name");
                        return;
                    }
                }
            }
            
            name = input;
            gbxRegister.Visible = false;
            btnConnect.Visible = true;
            lbxOpponents.Visible = true;
            RegisterUser();
        }
        private async void WaitForConnection(IPAddress iPAddress)
        {
            try
            {
                 listener = new TcpListener(iPAddress, 5001);
                listener.Start();
                opponentForGame = await listener.AcceptTcpClientAsync();
                startScreen.StartMultiplayerGame(opponentForGame);
                openMultiplayer = true;
                Close();

            }
            catch (Exception error)
            {

                MessageBox.Show(error.ToString());
            }
        }
        private async void ConnectToOpponent(IPAddress iPAddress)
        {
            try
            {
                await opponentForGame.ConnectAsync(iPAddress, 5001);
                startScreen.StartMultiplayerGame(opponentForGame);
                openMultiplayer = true;
                Close();
            }
            catch (Exception error)
            {

                MessageBox.Show(error.ToString());
            }
        }
        private async void RemoveThisUser()
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
                binaryWriter.Write("RM");
                byte[] buffer = memoryStream.ToArray();
                await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
                memoryStream.Dispose();
                binaryWriter.Dispose();
            }
            catch (Exception error)
            {

                MessageBox.Show(error.ToString());
            }
        }
    }
}
