using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SE3314Assignment2Client
{
    class RTSPmodel
    {
        static byte[] buffer = new byte[1024];
        static IPEndPoint myEndPoint;
        static Socket serverSocket;
        int sequenceNumber;
        int sessionNumber;
        TcpClient client;
        string clientIPAdress;
        int clientPort;
        string lastServerResponse;

        public RTSPmodel()
        {
            sequenceNumber = 1;
            clientIPAdress = "";
            clientPort = 0;
        }

        public bool createSocket(string ipaddress, int port)
        {
            clientIPAdress = ipaddress;
            clientPort = port;
            //Create the socket for sending out rtsp messages
            try
            {
                myEndPoint = new IPEndPoint(IPAddress.Parse(ipaddress), port);
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //serverSocket.Bind(myEndPoint);
                serverSocket.Connect(myEndPoint);
               // serverSocket.Listen(int.MaxValue);
                return true;
            }
            catch (SocketException e)
            {
                return false;
            }
        }

        //Get the server reponse to display on the view
        public string getLastServerResponse()
        {
            return lastServerResponse;
        }

        //The returned string is the server response
        public string sendMessage(string rtspType, string videoName, int portNumber)
        {
            string request = "";
            byte[] receivedMessage = new byte[1024];

            if (rtspType != "none")
            {
                //Build the message to send to the server based on the user's input
                if (rtspType == "setup")
                {
                    request = "SETUP rtsp://" + clientIPAdress + ":" + clientPort + "/" + videoName + " RTSP/1.0\r\nCSeq: " + sequenceNumber + "\r\nTransport: RTP/UDP; client_port= " + portNumber + "\r\n";

                }
                else if (rtspType == "play")
                {
                    request = "PLAY rtsp://" + clientIPAdress + ":" + clientPort + "/" + videoName + " RTSP/1.0\rCSeq: " + sequenceNumber + "\rSession: " + sessionNumber + "\r";
                }
                else if (rtspType == "pause")
                {
                    request = "PAUSE rtsp://" + clientIPAdress + ":" + clientPort + "/" + videoName + " RTSP/1.0\rCSeq: " + sequenceNumber + "\rSession: " + sessionNumber + "\r";
                }
                else if (rtspType == "teardown")
                {
                    request = "TEARDOWN rtsp://" + clientIPAdress + ":" + clientPort + "/" + videoName + " RTSP/1.0\rCSeq: " + sequenceNumber + "\rSession: " + sessionNumber + "\r";
                }

                //Send the request to the server
                byte[] byteArrayToSend = System.Text.ASCIIEncoding.ASCII.GetBytes(request);
                try
                {
                    serverSocket.Send(byteArrayToSend);
                }
                catch (SocketException err)
                {
                    return "error";
                }

                //Get the sequence number ready for the next request
                sequenceNumber++;

                //Wait for the server's response
                try
                {
                    serverSocket.Receive(receivedMessage);
                }
                catch (SocketException e)
                {
                    return "error";
                }

                //Parse the server response
                string convertedMessage = System.Text.Encoding.Default.GetString(receivedMessage);
                char splitChar = '\n';
                lastServerResponse = convertedMessage;
                string[] splitByR = convertedMessage.Split(splitChar);

                //Get the session number
                string tempSession = "";
                for (int i = 9; i < splitByR[2].Length; i++)
                {
                    tempSession += splitByR[2].ElementAt(i);
                }

                sessionNumber = Int32.Parse(tempSession);

                //Send the controller the server response to display on the form
                return convertedMessage;
            }
            else
            {
                return "none";
            }
        }
    }
}
