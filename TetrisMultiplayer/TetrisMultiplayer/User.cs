using System;
using System.Net;
using System.Net.Sockets;

namespace TetrisMultiplayer
{
    [Serializable]
    public class User
    {
        public string name;
        public IPAddress iPAdress;
        public int index;


        public User(string name, IPAddress iPAdress, int index)
        {
            this.name = name;
            this.iPAdress = iPAdress;
            this.index = index;
        }
        
        
    }
}
