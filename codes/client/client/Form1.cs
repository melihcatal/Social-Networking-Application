using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace client
{
    public struct friend
    {        //this is the struct in order to use in friendlist to keep track of if they are already friend or not.

        public string name;
        public Boolean alreadyFriend;

    }
    public partial class Form1 : Form
    {
        string name = "";
        bool terminating = false;
        bool connected = false;
        Socket clientSocket;

        List<friend> friendList = new List<friend>();// This is a list that contains all the friends that avaliable to send request

        List<string> waitingInvationsList = new List<string>(); //this list for track the waiting invations to approve by client

        List<string> pendingRequests = new List<string>(); //this list for track the pending requests which sent by client



        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();



        }

        //button connect clicked
        private void button_connect_Click(object sender, EventArgs e)
        {
            name = textBox_name.Text;
            button_remove_friend.Enabled = true;


            //if name part is not empty try to connect
            if (name != "" && textBox_ip.Text != "" && textBox_port.Text != "")
            {


                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                string IP = textBox_ip.Text;


                int portNum;
                if (Int32.TryParse(textBox_port.Text, out portNum))
                {
                    try
                    {
                        clientSocket.Connect(IP, portNum);
                        button_connect.Enabled = false;
                        textBox_message.Enabled = true;
                        button_send.Enabled = true;
                        connected = true;

                        Byte[] buffer = new Byte[64];
                        Byte[] buffer2 = new Byte[64];
                        buffer = Encoding.Default.GetBytes(name);
                        clientSocket.Send(buffer);
                        clientSocket.Receive(buffer2);

                        string connectionMessage = Encoding.Default.GetString(buffer2);
                        if (connectionMessage[0] == 'W')
                        {
                            logs.AppendText(connectionMessage);
                            button_connect.Enabled = true;
                            button_disconnect.Enabled = false;
                            textBox_ip.Enabled = true;
                            textBox_port.Enabled = true;
                            textBox_name.Enabled = true;
                            textBox_message.Enabled = false;
                            button_send.Enabled = false;
                        }
                        else
                        {       //connection succeed
                            button_connect.Enabled = false;
                            button_disconnect.Enabled = true;
                            textBox_ip.Enabled = false;
                            textBox_port.Enabled = false;
                            textBox_name.Enabled = false;
                            waitingInvations.Enabled = true;
                            button_acceptInvation.Enabled = true;
                            button_rejectInvation.Enabled = true;

                            Thread receiveThread = new Thread(Receive);
                            receiveThread.Start();



                            logs.AppendText("Connected to the server!\n");

                            //we are adding the friendlist
                            addFriendList();



                        }


                    }
                    catch
                    {
                        logs.AppendText("Could not connect to the server!\n");
                        button_connect.Enabled = true;

                    }
                }



            }
            else
            {
                logs.AppendText("Make sure that you fill all fields \n");
            }
        }

        //disconnect button click
        private void button_disconnect_Click(object sender, EventArgs e)
        {
            if (clientSocket != null)
            {
                endConnection();
            }



        }


        //get notifications about invations from server
        private void getNotifications(string incomingMessage, string whoRequested)
        {
            if (whoRequested != name)
            {
                notifyIcon1.ShowBalloonTip(1000, "Hey " + name + " New Notification for you !", incomingMessage, ToolTipIcon.Info);

                //put the request to notifications box
                notificationsBox.AppendText(incomingMessage + "\n");
                //insert that name to waiting invitations list

                if (!waitingInvationsList.Contains(whoRequested))
                {
                    waitingInvationsList.Add(whoRequested);



                    showNewFriendList();
                }
            }




            //show waiting invations
            showWaitingInvations();


        }

        //if this user is accepted this function runs
        private void accepted(string whoAccepted)
        {

            //a temp value in order to update friendlist
            var temp = new friend();

            temp.name = whoAccepted;
            temp.alreadyFriend = true;

            for (int i = 0; i < friendList.Count(); i++)
            {
                if (friendList[i].name == whoAccepted)
                {
                    //now we are friend !! so we made alreadyfriend true for which friend name == who accept us
                    friendList[i] = temp;

                    break;
                }

            }

            //updating pending requests. since we received no pending request so remove it from list and update friendlist and also pending list text box
            pendingRequests.Remove(whoAccepted);
            showFriendsList();
            pendingRequestsFunction();

        }

        //we are rejected by whorejected delete it from pending request. dont touch for friendlist . we can send invitations again
        private void rejected(string whoRejected)
        {
            pendingRequests.Remove(whoRejected);
            pendingRequestsFunction();

            showNewFriendList();

        }


        private void showFriendsList()
        {
            alreadyFriendsList.Items.Clear();

            for (int i = 0; i < friendList.Count(); i++)
            {
                //if we are already friend and we dont print ourself and alreadyfriend text box does not contain our name put our name to there
                if (friendList[i].alreadyFriend == true && friendList[i].name != name && !alreadyFriendsList.Items.Contains(friendList[i].name))
                {
                    alreadyFriendsList.Items.Add(friendList[i].name);
                }
            }

            if (alreadyFriendsList.Items.Count > 0)
            {
                button_remove_friend.Enabled = true;
                button_send_private.Enabled = true;
            }
            else
            {
                button_remove_friend.Enabled = true;
                button_send_private.Enabled = false;

            }

            //we are updating the add new friend text box also. for example fatih terim accepted us . so we should not send them any more invations so delete fatih from list
            showNewFriendList();
        }
        //receiving from server
        private void Receive()
        {
            while (connected)
            {
                try
                {
                    Byte[] buffer3 = new Byte[128];
                    clientSocket.Receive(buffer3);

                    string incomingMessage = Encoding.Default.GetString(buffer3);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    int nameEnd = incomingMessage.IndexOf(':');

                    string whoRequested = incomingMessage.Substring(0, nameEnd);
                    // if(incomingMessage.Contains("sendall") || incomingMessage.Contains("private") || incomingMessage.Contains)

                    //if somebody invitated us
                    if (incomingMessage.Contains("friendslist") && whoRequested != name)
                    {
                        getNotifications(incomingMessage, whoRequested);
                    }

                    //if we are accepted
                    if (incomingMessage.Contains("accepted"))
                    {
                        notifyIcon1.ShowBalloonTip(1000, "Hey " + name + " New Notification for you !", incomingMessage, ToolTipIcon.Info);

                        notificationsBox.AppendText(incomingMessage);
                        accepted(whoRequested);
                    }

                    //if we are rejected
                    else if (incomingMessage.Contains("rejected"))
                    {
                        notifyIcon1.ShowBalloonTip(1000, "Hey " + name + " New Notification for you !", incomingMessage, ToolTipIcon.Info);

                        notificationsBox.AppendText(incomingMessage);
                        rejected(whoRequested);


                    }

                    //if we are removed
                    else if (incomingMessage.Contains("removed"))
                    {
                        notifyIcon1.ShowBalloonTip(1000, "Hey " + name + " New Notification for you !", incomingMessage, ToolTipIcon.Info);
                        notificationsBox.AppendText(incomingMessage);
                        removed(whoRequested);
                    }

                    else if (incomingMessage.Contains("private"))
                    {
                        notifyIcon1.ShowBalloonTip(1000, "Hey " + name + " New Notification for you !", incomingMessage, ToolTipIcon.Info);
                        notificationsBox.AppendText(incomingMessage);
                    }

                    else
                    {
                        //if message is not coming from client itself print it to log
                        if (!(incomingMessage.Substring(0, nameEnd) == name))
                        {
                            logs.AppendText(incomingMessage + "\n");
                        }
                    }



                }
                catch
                {
                    if (!terminating && button_disconnect.Enabled == true)
                    {
                        logs.AppendText("The server has disconnected\n");
                        button_connect.Enabled = true;
                        textBox_message.Enabled = false;
                        button_send.Enabled = false;
                        endConnection();
                    }

                    clientSocket.Close();
                    connected = false;
                }

            }
        }

        private void removed(string whoRemoved)
        {

            //a temp value in order to update friendlist
            var temp = new friend();

            temp.name = whoRemoved;
            temp.alreadyFriend = false;

            for (int i = 0; i < friendList.Count(); i++)
            {
                if (friendList[i].name == whoRemoved && friendList[i].alreadyFriend == true)
                {
                    friendList[i] = temp;

                    break;
                }

            }
            showFriendsList();
            showNewFriendList();
        }
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (connected == true)
            {
                endConnection();
                Environment.Exit(0);

            }
            else
            {
                Environment.Exit(0);

            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            string message = textBox_message.Text + ".sendall";
            message = name + ": " + message;
            if (textBox_message.Text.Length != 0)
            {
                Byte[] buffer = new Byte[64];
                buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }
            else
            {
                logs.AppendText(" You have to write something to send ! \n");
            }

        }

        private void TextBox_message_TextChanged(object sender, EventArgs e)
        {

        }

        //end connection. we are done. we are going away.
        private void endConnection()
        {

            Byte[] buffer4 = new Byte[64];
            //the message will be name + disconnected. and server will check the message based on this way
            string disconnectionMessage = name + " disconnected ";

            buffer4 = Encoding.Default.GetBytes(disconnectionMessage);
            //in order to disconnect client must be connect first.

            try
            {
                clientSocket.Send(buffer4);
                clientSocket.Close();
                connected = false;
                logs.AppendText("You Are disconnected\n");
                button_connect.Enabled = true;
                button_disconnect.Enabled = false;
                textBox_ip.Enabled = true;
                textBox_port.Enabled = true;
                textBox_name.Enabled = true;
            }

            catch
            {
                clientSocket.Close();
                connected = false;
                logs.AppendText("You Are disconnected\n");
                button_connect.Enabled = true;
                button_disconnect.Enabled = false;
                textBox_ip.Enabled = true;
                textBox_port.Enabled = true;
                textBox_name.Enabled = true;

            }
        }

        //this is the way who we can add as friend . this is for add new friends part
        public void addFriendList()
        {

            //CHANGE THIS PARTTTTTTT ACCORDING TO YOUR PATH
            string[] lines = System.IO.File.ReadAllLines(@"../../friendlistDB.txt");

            var temp = new friend();

            // Add all the names from txt to allClientNames.
            alreadyFriendsList.Items.Clear();


            for (int i = 1; i < lines.Count(); i++)
            {
                temp.name = lines[i].Substring(0, lines[i].IndexOf('('));

                temp.alreadyFriend = false;
                friendList.Add(temp);

                if(temp.name == name)
                {
                    string friends = lines[i].Substring(lines[i].IndexOf('(')+1, lines[i].IndexOf(')')- lines[i].IndexOf('(')-1);
                    string friendName = "";

                    foreach (char ch in friends)
                    {
                        if (ch == ',') {
                            if(!alreadyFriendsList.Items.Contains(friendName))
                                alreadyFriendsList.Items.Add(friendName);
                            for (int k = 0; k< friendList.Count(); k++)
                            {
                                if(friendList[k].name == friendName)
                                {
                                    var tempF = new friend();
                                    tempF.name = friendName;
                                    tempF.alreadyFriend = true;


                                    friendList[k] = tempF;
                                    button_remove_friend.Enabled = true;


                                    button_send_private.Enabled = true;

                                }
                            }
                            friendName = "";
                        }
                        else
                        {
                            friendName += ch;
                        }
                    }

                }
            }
            //foreach (string line in lines)
            //{
            //    temp.name = line;
            //    temp.alreadyFriend = false;
            //    friendList.Add(temp);

            //}


            //show add new friendlist
            showNewFriendList();

            //enable the newfriendlist checkbox
            newFriendList.Enabled = true;

            //enable the send invation button
            button_sendInvitation.Enabled = true;



        }

        //this is the function to show new friends who are eligible to invite
        private void showNewFriendList()
        {
            newFriendList.Items.Clear();

            for (int i = 0; i < friendList.Count; i++)
            {
                //if they are not already friend we add their name to add friend list and we dont add  name of login user
                if (friendList[i].alreadyFriend == false && friendList[i].name != name)
                {
                    newFriendList.Items.Add(friendList[i].name);
                }


            }
        }

        //this functions is in purporse of showing waiting invations
        public void showWaitingInvations()
        {

            waitingInvations.Items.Clear();

            for (int i = 0; i < waitingInvationsList.Count; i++)
            {
                if (!waitingInvations.Text.Contains(waitingInvationsList[i]))
                {
                    waitingInvations.Items.Add(waitingInvationsList[i]);

                }
            }


        }

        //accept invitation button clicked
        private void button_acceptInvation_Click(object sender, EventArgs e)
        {

            //for every checked items accept
            foreach (string indexChecked in waitingInvations.CheckedItems)
            {
                string checkedFriend = indexChecked.ToString();


                string addMessage = name + ": accepted the invitation from =>" + checkedFriend + "\n";

                Byte[] buffer4 = Encoding.Default.GetBytes(addMessage);

                clientSocket.Send(buffer4);

                //***************
                waitingInvationsList.Remove(checkedFriend);

                var temp = new friend();

                temp.name = checkedFriend;
                temp.alreadyFriend = true;

                for (int i = 0; i < friendList.Count(); i++)
                {
                    if (friendList[i].name == checkedFriend)
                    {
                        friendList[i] = temp;

                        break;
                    }

                }

            }

            //update waiting invations
            showWaitingInvations();
            //show our friends
            showFriendsList();

        }

        //reject button clicked
        private void Button_rejectInvation_Click(object sender, EventArgs e)
        {
            //for every checked items accept
            foreach (string indexChecked in waitingInvations.CheckedItems)
            {
                string checkedFriend = indexChecked.ToString();


                string addMessage = name + ": rejected the invitation from =>" + checkedFriend + "\n";

                Byte[] buffer4 = Encoding.Default.GetBytes(addMessage);

                clientSocket.Send(buffer4);

                //we are removing from waiting invations since we answer their invations
                waitingInvationsList.Remove(checkedFriend);

                var temp = new friend();
                temp.name = checkedFriend;
                temp.alreadyFriend = false;

                friendList.Add(temp);

            }

            //updating
            showWaitingInvations();
            showNewFriendList();

        }

        //send invation button clicked
        private void button_sendInvitation_Click(object sender, EventArgs e)
        {

            //for every checked items send a request to add .
            foreach (string indexChecked in newFriendList.CheckedItems)
            {

                string checkedFriend = indexChecked.ToString();

                //finding the place of checkedfriend in friendlist. since friendlist is a list of struct friend we cant find directly checkedfriend's index
                int index = findPlaceOfItemOnFriendList(checkedFriend);

                if (waitingInvationsList.Contains(checkedFriend))
                {
                    logs.AppendText("You have to first accept or reject the waiting request ! . \n");
                }

                //if there is no pending request to him and we are not already friend we can send invitation and already we dont have a request from hi
                if (!pendingRequests.Contains(checkedFriend) && friendList[index].alreadyFriend == false && !waitingInvationsList.Contains(checkedFriend))
                {
                    string addMessage = name + ": add request sent to =>" + checkedFriend;

                    Byte[] buffer4 = Encoding.Default.GetBytes(addMessage);

                    clientSocket.Send(buffer4);
                    pendingRequests.Add(checkedFriend);


                }

                else
                {
                    logs.AppendText("You already sent invations or you are already friend. Try somebody else.. \n");
                }



            }

            //update pending request field
            pendingRequestsFunction();




        }

        //finding the place of desired item in friendlist
        private int findPlaceOfItemOnFriendList(string item)
        {
            int foundAt = 0;

            for (int i = 0; i < friendList.Count(); i++)
            {
                if (friendList[i].name == item)
                {
                    foundAt = i;
                    break;
                }
            }

            return foundAt;
        }

        //pending request field
        private void pendingRequestsFunction()
        {
            pendingRequestsTextBox.Clear();

            for (int i = 0; i < pendingRequests.Count(); i++)
            {
                pendingRequestsTextBox.AppendText(pendingRequests[i] + "\n");
            }


        }


        private void NewFriendList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (newFriendList.CheckedItems.Count > 2)
            {
                logs.AppendText("You can add at most 2 people in one invation \n");

                button_sendInvitation.Enabled = false;
            }

            if (newFriendList.CheckedItems.Count <= 2)
            {
                button_sendInvitation.Enabled = true;

            }



        }

        private void Button_remove_friend_Click(object sender, EventArgs e)
        {

            //for every checked items send a request to add .
            foreach (string indexChecked in alreadyFriendsList.CheckedItems)
            {

                string checkedFriend = indexChecked.ToString();

                // remove message to server
                string removeMessage = name + ": removed to =>" + checkedFriend;
                Byte[] buffer4 = Encoding.Default.GetBytes(removeMessage);
                clientSocket.Send(buffer4);

                var temp = new friend();

                temp.name = checkedFriend;
                temp.alreadyFriend = false;

                for (int i = 0; i < friendList.Count(); i++)
                {
                    if (friendList[i].name == checkedFriend)
                    {
                        friendList[i] = temp;

                        break;
                    }


                }


            }

            showFriendsList();
            showNewFriendList();
            addFriendList();
        }

        private void Button_send_private_Click(object sender, EventArgs e)
        {
            if (alreadyFriendsList.CheckedItems.Count == 0)
            {
                logs.AppendText("You have to select one of your friend to send a direct message \n");
            }
            else
            {
                foreach (string indexChecked in alreadyFriendsList.CheckedItems)
                {
                    string checkedFriend = indexChecked.ToString();

                    string message = textBox_message.Text;

                    if (textBox_message.Text.Length != 0)
                    {
                        message = name + ": private message " + message + ". to =>" + checkedFriend;

                        Byte[] buffer = Encoding.Default.GetBytes(message);
                        clientSocket.Send(buffer);
                    }
                    else
                    {
                        logs.AppendText("You have to write something to send ! \n");
                    }
                }
            }


        }


    }
}
