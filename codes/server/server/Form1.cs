using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.IO;

namespace server
{



    public struct sockecList
    {
        //this is the struct in order to keep socketlist with client name
        public Socket socketName;
        public string clientName;
        public List<string> pendingInvitationList;
    }

    public struct offlineInfo
    {
        public string message;
        public string offlineClientName;
    }

    public partial class Form1 : Form
    {

        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<sockecList> clientSockets = new List<sockecList>();
        List<string> clientNames = new List<string>();// This is a list that contains names connected.
        List<string> allClientNames = new List<string>();// This is a list that contains all the names from txt file
        string nameOfClient;


        List<offlineInfo> offlineInfoList = new List<offlineInfo>();//This list includes messages that have to send to offline clients


        bool terminating = false;
        bool listening = false;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);

            //read users from database 
            string[] lines = System.IO.File.ReadAllLines(@"../../../db.txt");


            // Add all the names from txt to allClientNames.
            foreach (string line in lines)
            {
                allClientNames.Add(line);

            }

            InitializeComponent();
            InitializeFriendDB();



        }

        //listen button
        private void button_listen_Click(object sender, EventArgs e)
        {
            int serverPort;

            if (Int32.TryParse(textBox_port.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                listening = true;
                button_listen.Enabled = false;

                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();
                logs.AppendText("Started listening on port: " + serverPort + "\n");



            }
            else
            {
                logs.AppendText("Please check port number \n");
            }
        }

        private void Accept()
        {
            while (listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();
                    // Taking name of the user
                    Byte[] buffer = new Byte[64];
                    newClient.Receive(buffer);

                    string clientName = Encoding.Default.GetString(buffer);
                    clientName = clientName.Substring(0, clientName.IndexOf("\0"));

                    if (!clientNames.Contains(clientName) && allClientNames.Contains(clientName))
                    {
                        var temp = new sockecList();

                        clientNames.Add(clientName);

                        //Buraya listeden cek edip yeni listede pending request varsa tekrar at.


                        temp.clientName = clientName;
                        temp.socketName = newClient;
                        clientSockets.Add(temp);

                        string connectionMessage = clientName + " is connected.\n";
                        logs.AppendText(connectionMessage);
                        Byte[] buf = Encoding.Default.GetBytes(connectionMessage);
                        newClient.Send(buf);
                        Thread receiveThread = new Thread(Receive);
                        receiveThread.Start();

                        Thread onlineLogThread = new Thread(logOnlineClients);
                        onlineLogThread.Start();


                        Thread offlineLogThread = new Thread(logOfflineClients);
                        offlineLogThread.Start();

                        /*
                        int offlineIndex = 0;

                        offlineInfo temp = new offlineInfo();

                        temp.clientName = nameOfClient;

                       for(int i = 0; i<offlineInfoList.Count(); i++)
                        {

                        }




                        foreach (offlineInfo info in offlineInfoList)
                        {
                            if (info.offlineClientName == clientName)//Burda isim yanlis geliyor galiba yarin bakicam
                            {
                                Byte[] bufForMessage = Encoding.Default.GetBytes(info.message);
                                newClient.Send(bufForMessage);

                                offlineInfoList.Remove(info);

                                break;

                            }
                        }
                        */

                        for (int i = offlineInfoList.Count - 1; i >= 0; i--)
                        {
                            if (offlineInfoList[i].offlineClientName == clientName)
                            {
                                Byte[] bufForMessage = Encoding.Default.GetBytes(offlineInfoList[i].message);
                                newClient.Send(bufForMessage);

                                offlineInfoList.RemoveAt(i);
                            }
                        }


                    }
                    else if (!allClientNames.Contains(clientName))
                    {
                        string errorMessage = "WARNING! " + "There is no " + clientName + " in db file.\n";
                        Byte[] buf = Encoding.Default.GetBytes(errorMessage);
                        logs.AppendText(errorMessage);
                        newClient.Send(buf);
                    }
                    else if (clientNames.Contains(clientName))
                    {
                        string errorMessage = "WARNING! " + clientName + " is already connected.\n";
                        Byte[] buf = Encoding.Default.GetBytes(errorMessage);
                        logs.AppendText(errorMessage);
                        newClient.Send(buf);
                    }


                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        logs.AppendText("The socket stopped working.\n");
                    }

                }
            }
        }

        private void Receive()
        {
            Socket thisClient = clientSockets[clientSockets.Count() - 1].socketName;
            bool connected = true;



            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer3 = new Byte[64];
                    thisClient.Receive(buffer3);

                    //the message that comes from client
                    String incomingMessage = Encoding.Default.GetString(buffer3);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                    logs.AppendText("incoming message => " + incomingMessage + "\n");

                    //if private message has arrived
                    if(incomingMessage.Contains("private"))
                    {
                        //name of receiver
                        int temp = incomingMessage.IndexOf(">") + 1;

                        string receiver = incomingMessage.Substring(temp, incomingMessage.Length - temp);

                        // string whoRemoved = incomingMessage.Substring(temp, incomingMessage.Length - (temp + 1));


                        //name of sender
                        string sender = incomingMessage.Substring(0, incomingMessage.IndexOf(":"));

                        // pure message
                        //string pureMessage = incomingMessage.Substring(incomingMessage.IndexOf(','), incomingMessage.IndexOf('|'));

                        sendPrivateMessage(sender, receiver,incomingMessage);
                    }


                    //if somebody removed somebody from his/her list
                    if(incomingMessage.Contains("removed"))
                    {

                        //name of receiver
                        int temp = incomingMessage.IndexOf(">") + 1;

                        string whoRemoved = incomingMessage.Substring(temp, incomingMessage.Length - temp);

                       // string whoRemoved = incomingMessage.Substring(temp, incomingMessage.Length - (temp + 1));


                        //name of sender
                        string whoRemove = incomingMessage.Substring(0, incomingMessage.IndexOf(":"));

                        removeFriend(whoRemove, whoRemoved);

                    }

                    if (incomingMessage.Contains("accepted"))
                    {

                        //name of receiver
                        int temp = incomingMessage.IndexOf(">") + 1;

                        //string nameOfAccepted = incomingMessage.Substring(temp, incomingMessage.Length - temp);
                        string whoAccepted = incomingMessage.Substring(temp, incomingMessage.Length - (temp+1));




                        //name of sender
                        string whoAccept = incomingMessage.Substring(0, incomingMessage.IndexOf(":"));


                        acceptInvation(whoAccept, whoAccepted);
                        //UpdateFriendDB(whoAccept, whoAccepted);
                    }


                    if (incomingMessage.Contains("rejected"))
                    {

                        //name of receiver
                        int temp = incomingMessage.IndexOf(">") + 1;

                        string whoRejected = incomingMessage.Substring(temp, incomingMessage.Length - temp);



                        //name of sender
                        string whoReject = incomingMessage.Substring(0, incomingMessage.IndexOf(":"));


                        rejectInvation(whoReject, whoRejected);
                    }



                    if (incomingMessage.Contains("add"))
                    {

                        //name of receiver
                        int temp = incomingMessage.IndexOf(">") + 1;
                        string nameOfReceiverOfInvation = incomingMessage.Substring(temp, incomingMessage.Length - temp);



                        //name of sender
                        string nameOfSender = incomingMessage.Substring(0, incomingMessage.IndexOf(":"));


                        friendInvitation(nameOfSender, nameOfReceiverOfInvation);


                    }

                    //if the message contains disconnected  which means client clicked to disconnect button
                    if (incomingMessage.Contains("disconnected"))
                    {
                        //take the name of client
                        string name = incomingMessage.Substring(0, incomingMessage.IndexOf(" disconnected"));

                        //make it equal to global variable nameofclient in order to use it in later
                        nameOfClient = name;



                        //remove this client from clientsockets

                        int indexOfThisClient = 0;

                        for (int i = 0; i < clientSockets.Count(); i++)
                        {
                            if (clientSockets[i].socketName == thisClient)
                            {
                                indexOfThisClient = i;
                                break;
                            }
                        }

                        clientSockets.RemoveAt(indexOfThisClient);


                        //remove his name from active client names in order to make it able to reconnect
                        clientNames.Remove(name);

                        thisClient.Close();

                        connected = false;

                        logOnlineClients();

                        logOfflineClients();


                    }
                    //if send all  button clicked
                    if(incomingMessage.Contains("sendall"))
                    {
                        string notification = incomingMessage.Substring(0, incomingMessage.IndexOf("."));


                        Byte[] buf = Encoding.Default.GetBytes(notification);

                        //for each active client send the message

                        for (int i = 0; i < clientSockets.Count(); i++)
                        {
                            Socket client = clientSockets[i].socketName;
                            client.Send(buf);
                        }


                    }
                }
                catch
                {


                    if (!terminating)
                    {
                        //when client close the connection via clicking x button on upper right corner  delete it names from active list

                        clientNames.Remove(nameOfClient);

                        //s clientSockets.Remove(thisClient);



                        thisClient.Close();

                        connected = false;

                    }

                }
            }
        }

        private void sendPrivateMessage(string sender,string receiver,string message)
        {
            string notification = message.Substring(0, message.IndexOf("."));
             notification = notification + "\n";
            if (clientNames.Contains(receiver))
            {

                Byte[] buf = Encoding.Default.GetBytes(notification);


                int indexOfReceiver = 0;

                for (int i = 0; i < clientSockets.Count(); i++)
                {
                    if (clientSockets[i].clientName == receiver)
                    {
                        indexOfReceiver = i;
                        break;
                    }

                }

                Socket receiverClient = clientSockets[indexOfReceiver].socketName;
                receiverClient.Send(buf);


            }
            else
            {
                offlineInfo info = new offlineInfo();
                info.message = notification;
                info.offlineClientName = receiver;
                offlineInfoList.Add(info);
            }

        }
        private void friendInvitation(string sender, string receiver)
        {


            string notification = sender + ": wants to add you in his/her friendslist. You can accept or reject this request. \n \n";
            //if receiver is online send that notification to receiver

            if (clientNames.Contains(receiver))
            {

                Byte[] buf = Encoding.Default.GetBytes(notification);


                int indexOfReceiver = 0;

                for (int i = 0; i < clientSockets.Count(); i++)
                {
                    if (clientSockets[i].clientName == receiver)
                    {
                        indexOfReceiver = i;
                        break;
                    }

                }

                Socket receiverClient = clientSockets[indexOfReceiver].socketName;
                receiverClient.Send(buf);


            }
            //if not online
            else
            {

                offlineInfo info = new offlineInfo();
                info.message = notification;
                info.offlineClientName = receiver;
                offlineInfoList.Add(info);

            }




        }

        //this function for keeping track of online clients
        private void logOnlineClients()
        {
            onlineClientsLogs.Clear();

            for (int i = 0; i < clientNames.Count(); i++)
            {
                if (!onlineClientsLogs.Text.Contains(clientNames[i]))
                {
                    onlineClientsLogs.AppendText(clientNames[i] + "\n");

                }


            }

            totalOnlineClientCount.Text = clientNames.Count().ToString();


        }

        //this function for keeping track of offline clients
        private void logOfflineClients()
        {

            offlineClientsLogs.Clear();
            var offlineClients = allClientNames.Except(clientNames).ToList();

            for (int i = 0; i < offlineClients.Count(); i++)
            {
                if (!offlineClientsLogs.Text.Contains(offlineClients[i]))
                {
                    offlineClientsLogs.AppendText(offlineClients[i] + "\n");
                }
            }

            totalOffilneClientsCount.Text = offlineClients.Count().ToString();

        }

        private void acceptInvation(string whoAccept, string whoAccepted)
        {

            string notification = whoAccept + ": accepted your friend request !. ";
            //if receiver is online send that notification to receiver

            if (clientNames.Contains(whoAccepted))
            {

                Byte[] buf = Encoding.Default.GetBytes(notification);


                int indexOfReceiver = 0;

                for (int i = 0; i < clientSockets.Count(); i++)
                {
                    if (clientSockets[i].clientName == whoAccepted)
                    {
                        indexOfReceiver = i;
                        break;
                    }

                }

                Socket receiverClient = clientSockets[indexOfReceiver].socketName;

                UpdateFriendDB(whoAccept, whoAccepted);


                receiverClient.Send(buf);


            }
            //if not online
            else
            {
                offlineInfo info = new offlineInfo();
                info.message = notification;
                info.offlineClientName = whoAccepted;
                offlineInfoList.Add(info);

            }



        }

        private void removeFriend(string whoRemove, string whoRemoved)
        {


            string notification = whoRemove + ": removed you from his/her friend list !. ";

            if (clientNames.Contains(whoRemoved))
            {

                Byte[] buf = Encoding.Default.GetBytes(notification);


                int indexOfReceiver = 0;

                for (int i = 0; i < clientSockets.Count(); i++)
                {
                    if (clientSockets[i].clientName == whoRemoved)
                    {
                        indexOfReceiver = i;
                        break;
                    }

                }

                Socket receiverClient = clientSockets[indexOfReceiver].socketName;

                receiverClient.Send(buf);


            }
            else
            {
                offlineInfo info = new offlineInfo();
                info.message = notification;
                info.offlineClientName = whoRemoved;
                offlineInfoList.Add(info);
            }

            removeFromDb(whoRemove, whoRemoved);

        }

        private void rejectInvation(string whoReject, string whoRejected)
        {
            string notification = whoReject + ": rejected your friend request !. ";
            //if receiver is online send that notification to receiver

            if (clientNames.Contains(whoRejected))
            {

                Byte[] buf = Encoding.Default.GetBytes(notification);


                int indexOfReceiver = 0;

                for (int i = 0; i < clientSockets.Count(); i++)
                {
                    if (clientSockets[i].clientName == whoRejected)
                    {
                        indexOfReceiver = i;
                        break;
                    }

                }

                Socket receiverClient = clientSockets[indexOfReceiver].socketName;

                receiverClient.Send(buf);


            }
            //if not online
            else
            {
                offlineInfo info = new offlineInfo();
                info.message = notification;
                info.offlineClientName = whoRejected;
                offlineInfoList.Add(info);

            }


        }


        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }

        private void InitializeFriendDB()
        {
            string[] lines = System.IO.File.ReadAllLines(@"../../../friendlistDB.txt");
            List<string> listOfLines = new List<string>(lines);

            if (listOfLines[0] == "0")
            {
                for(int i = 0; i < listOfLines.Count(); i++)
                {
                    if (i == 0) { listOfLines[i] = "1"; }
                    else
                    {
                        listOfLines[i] += "()";
                    }

                }

                var newDB = listOfLines.ToArray();

                System.IO.File.WriteAllLines(@"../../../friendlistDB.txt", newDB);
            }

        }

        private void UpdateFriendDB(string user1, string user2)
        {
            string[] lines = System.IO.File.ReadAllLines(@"../../../friendlistDB.txt");
            List<string> listOfLines = new List<string>(lines);

            for (int i = 0; i < listOfLines.Count(); i++)
            {
                string str_list = listOfLines[i].Split(')')[0];
                string str_username = listOfLines[i].Split('(')[0];
                if (str_username.Contains(user1))
                {
                    listOfLines[i] = str_list + user2 + ",)";
                }
                if (str_username.Contains(user2))
                {
                    listOfLines[i] = str_list + user1 + ",)";
                }
            }

            var newDB = listOfLines.ToArray();
  //write friends from your friendlist file
            System.IO.File.WriteAllLines(@"../../../friendlistDB.txt", newDB);
        }

        private void removeFromDb(string user1, string user2)
        {

            //take friends from your friendlist file
            string[] lines = System.IO.File.ReadAllLines(@"../../../friendlistDB.txt");
            List<string> listOfLines = new List<string>(lines);

            for (int i = 1; i < listOfLines.Count(); i++)
            {
                string str_list = listOfLines[i].Split(')')[0];
                string str_username = listOfLines[i].Split('(')[0];
                int start = listOfLines[i].IndexOf('(') + 1;
                int length = listOfLines[i].IndexOf(')') - listOfLines[i].IndexOf('(') - 1;
                string friends = listOfLines[i].Substring(start, length);

                if (str_username.Contains(user1))
                {
                    string friendName = "";

                    for (int j = 0; j < friends.Count(); j++)
                    {
                        if (user2 == friendName)
                        {
                            friends = friends.Remove(j - friendName.Length, friendName.Length+1);
                            listOfLines[i] = user1 + "(" + friends + ")";
                            friendName = "";
                        }
                        else if (friends[j] != ',')
                        {
                            friendName += friends[j];
                        }
                        else if (friends[j] == ',')
                        {
                            friendName = "";
                        }
                    }
                }
                if (str_username.Contains(user2))
                {
                    string friendName = "";

                    for (int j = 0; j < friends.Count(); j++)
                    {
                        if (user1 == friendName)
                        {
                            friends = friends.Remove(j - friendName.Length, friendName.Length+1);
                            listOfLines[i] = user2 + "(" + friends + ")";
                            friendName = "";
                        }
                        else if(friends[j]!=',')
                        {
                            friendName += friends[j];
                        }
                        else if(friends[j] == ',')
                        {
                            friendName = "";
                        }
                    }

                }
            }

            var newDB = listOfLines.ToArray();

            //write to your friendList path
            System.IO.File.WriteAllLines(@"../../../friendlistDB.txt", newDB);
        }

    }
}
