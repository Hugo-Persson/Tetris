using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Net.Sockets;
using System.IO;
using TetrisMultiplayer;

namespace TetrisServer
{
    public partial class Server : Form
    {
        
        TcpListener listener = new TcpListener(IPAddress.Any, 5001);
        List<User> users = new List<User>();
        List<TcpClient> clients = new List<TcpClient>();
        string time;
        
        
        public Server()
        {
            InitializeComponent();
            listener.Start();
            time = DateTime.Now.ToShortTimeString();
            Connect();
        }
        async void Connect()
        {
            TcpClient client = new TcpClient();
            
            client = await listener.AcceptTcpClientAsync();
            
            clients.Add(client);
            SendAllUsers(client);
            RecieveData(clients.Count-1);
            Connect();
        }

        
        async void RecieveData(int index)
        {
            
            try
            {
                byte[] buffer = new byte[1024];
                string type;
                await clients[index].GetStream().ReadAsync(buffer, 0, buffer.Length);
                MemoryStream memoryStream = new MemoryStream(buffer);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                BinaryReader binaryReader = new BinaryReader(memoryStream);
                memoryStream.Position = 0;
                type = binaryReader.ReadString();
                string fromName = "error";
                foreach(User i in users)
                {
                    if (i.index == index)
                    {
                        fromName = i.name;
                    }
                }

                //RU means Register User which is sent from a host when it is connected
                if (type == "RU")
                {
                    IPEndPoint iPEndPoint = (IPEndPoint)clients[index].Client.RemoteEndPoint;
                    IPAddress iPAddress = iPEndPoint.Address;
                    User user = new User(binaryReader.ReadString(),iPAddress, index);
                    
                    users.Add(user);
                    SendNewUser(user);
                    tbxEvents.AppendText("New user registered, Name: " + user.name + " " + time + Environment.NewLine   );
                }
                //RP means Request to Play
                else if (type == "RP")
                {
                    int sendToIndex = binaryReader.ReadInt16();
                    TcpClient client = clients[sendToIndex];
                    RequestToPlayReDirect(client, index);
                    tbxEvents.AppendText("Request to play was sent, From " + fromName + " " + time + Environment.NewLine);



                }
                //AP means Answer to Play
                else if(type == "AP")
                {
                    int sendToIndex = binaryReader.ReadInt16();
                    bool answer = binaryReader.ReadBoolean();
                    
                    
                    TcpClient client = clients[sendToIndex];
                    AnswerToPlayReDirect(client, answer,index);
                    tbxEvents.AppendText("Answer to play sent, From: " + fromName + " " + time + Environment.NewLine);
                }
                //RM means RemoveUser
                else if (type == "RM")
                {
                    foreach (User i in users)
                    {
                        if (i.index == index)
                        {
                            tbxEvents.AppendText("User removed. Name: " + i.name + " " + time + Environment.NewLine);
                            break;
                        }
                    }
                    RemoveUser(index);
                    
                }
                memoryStream.Dispose();
                
            }
            catch(Exception error)
            {
                tbxErrors.AppendText(error.ToString() + " " + time + Environment.NewLine + Environment.NewLine + Environment.NewLine);
                //MessageBox.Show(error.ToString());
                return;
            }
            RecieveData(index);
            
            
        }
        
        private async void SendAllUsers(TcpClient client)
        {
            List<User> sendUsers = users;
            
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(memoryStream);
            BinaryFormatter formatter = new BinaryFormatter();
            

            try
            {
                //UU means for Update Users
                writer.Write("UU");
                formatter.Serialize(memoryStream, sendUsers);
                byte[] buffer = memoryStream.ToArray();
                await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
                
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        private async void SendNewUser(User user)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(memoryStream);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                //NU means for New User
                writer.Write("NU");
                formatter.Serialize(memoryStream, user);
                byte[] buffer = memoryStream.ToArray();
                for(int i = 0; i < clients.Count; i++)
                {
                    //I want to send the message to everybody except the user that connected
                    if (i != user.index)
                    {
                        if (clients[i] != null && clients[i].Connected)
                        {
                            await clients[i].GetStream().WriteAsync(buffer, 0, buffer.Length);
                        }
                        
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            memoryStream.Dispose();
        }
        private async void RequestToPlayReDirect(TcpClient client, int index)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(memoryStream);
            
            try
            {
                Int16 send = (Int16)index;
                writer.Write("RP");
                writer.Write(send);
                byte[] buffer = memoryStream.ToArray();
                await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            
            }
        }
        private async void AnswerToPlayReDirect(TcpClient client, bool answer, int index)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(memoryStream);
            try
            {
                writer.Write("AP");
                writer.Write(answer);
                writer.Write((Int16)index);
                byte[] buffer = memoryStream.ToArray();
                await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            memoryStream.Dispose();
        }
        private async void RemoveUser(int index)
        {
            clients[index] = null;
            try
            {
                for(int i = 0; i < users.Count; i++)
                {
                    if (users[i].index == index) 
                    {
                        users.RemoveAt(i);
                    }
                }
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
            //RM means RemoveUser
            binaryWriter.Write("RM");
            binaryWriter.Write((Int16)index);
            byte[] buffer = memoryStream.ToArray();
            for(int i = 0; i < clients.Count; i++)
                {
                    if (i != index&& clients[i]!=null)
                    {
                        await clients[i].GetStream().WriteAsync(buffer,0,buffer.Length);
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            


        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
