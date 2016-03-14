using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.IO;

namespace SE3314Assignment2Client
{
    class RTPmodel
    {
        RTPpacket _rtpPacket;
        Socket serverSocket;
        string serverAddress;
        IPEndPoint theEndPoint;
        Image currentFrame;
        UdpClient receivingUdpClient;

            
        public RTPmodel(string address)
        {
            serverAddress = address;
            _rtpPacket = new RTPpacket();
        }

        //Create the socket for receiving the frames to the server
        public void createTheSocket(int portNumber)
        {
            //Port number is the same port number used in the setup command so the server will know this is the socket that wants to recieve the frames
            receivingUdpClient = new UdpClient(portNumber);
            theEndPoint = new IPEndPoint(IPAddress.Any, 0);
        }

        public string getLastHeader()
        {
            return _rtpPacket.getLastHeader();
        }
        public string getLastPacket()
        {
            return _rtpPacket.getLastPacket();
        }

        //Send the given frame to the client
        public Image receiveFrame()
        {
            //Receive the next frame from the server
            byte[] receivedPacket = receivingUdpClient.Receive(ref theEndPoint);

            //Pull off the RTP header
            receivedPacket = _rtpPacket.extractPayload(receivedPacket);

            //Convert to an image to be displayed on the view
            MemoryStream myMemoryStream = new MemoryStream(receivedPacket);
            currentFrame = Image.FromStream(myMemoryStream);

            return currentFrame;
        }
    }
}
