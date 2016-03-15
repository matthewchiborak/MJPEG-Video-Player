using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Drawing;

namespace SE3314Assignment2Client
{
    class Controller
    {
        Thread _RTSPThread;
        Thread buttonThread;
        Form1 _view; //the view to collect inputted information and display new information
        int currentPort; //The currently selected port number to listen on
        string ipaddress; //The currently selected IP address of the server
        string videoName; //The currently selected video name
        int frameReceiverPortNumber;
        string currentMessage;
        int videoBoxWidth;
        int videoBoxHeight;

        //The pictures for the transparent buttons
        Image playIcon;
        Image pauseIcon;
        Image teardownIcon;
        Image setupIcon;

        Image lastFrame;

        //Model for listening and sending for RTSP commands
        RTSPmodel _RTSPModel;

        //Delegates for adding info to the form
        Form1.formStringDelegate addToStatusDelegate;
        Form1.formStringDelegate addToRequestDelegate;

        public Controller(Form1 mainView, int videoWidth, int videoHeight, Form1.formStringDelegate addToStatusDelegate, Form1.formStringDelegate addToRequestDelegate)
        {
            _RTSPThread = null;
            _view = mainView;
            addToStatusDelegate.GetType();
            addToRequestDelegate.GetType();
            this.addToStatusDelegate = addToStatusDelegate;
            this.addToRequestDelegate = addToRequestDelegate;
            frameReceiverPortNumber = 25000;
            _RTSPModel = new RTSPmodel();
            currentMessage = "none";
            playIcon = Image.FromFile(".//Play.png");
            pauseIcon = Image.FromFile(".//Pause.png");
            teardownIcon = Image.FromFile(".//Teardown.png");
            setupIcon = Image.FromFile(".//Setup.png");
            lastFrame = Image.FromFile(".//Setup.png");
            videoBoxWidth = videoWidth;
            videoBoxHeight = videoHeight;
        }

        //View updates the current information
        public void setCurrentPort(int port)
        {
            currentPort = port;
        }
        public void setIPAddress(string address)
        {
            ipaddress = address;
        }
        public void setVideo(string name)
        {
            videoName = name;
        }

        public void waitForFrames(object myRTPmodel)
        {
            bool socketCreated = false;

            //Loop until client is closed.
            //Receive the rtp packets and display the received frames
            while (true)
            {
                //Create the socket if needed
                if (!socketCreated)
                {
                    ((RTPmodel)myRTPmodel).createTheSocket(frameReceiverPortNumber);
                    socketCreated = true;
                    _view.addToStatus("Socket created\n");
                }

                //Receive a frame and put it on the view
                Image basicFrame = ((RTPmodel)myRTPmodel).receiveFrame();
                
                lastFrame = basicFrame;

                //Pass to the view if user wants them to be displayed
                _view.addRTPToStatus(((RTPmodel)myRTPmodel).getLastHeader());
                _view.addPacketToStatus(((RTPmodel)myRTPmodel).getLastPacket());

                //Return just the frame is the cursor is not over the video
                if (!_view.getIsMouseOverVideo())
                {
                    _view.postFrame(basicFrame);
                }
                else
                {
                    //Add the buttons to the frame
                    Image resizedFrame = new Bitmap(lastFrame, new Size(videoBoxWidth, videoBoxHeight));
                    Graphics myGraphic = Graphics.FromImage(resizedFrame);
                    int lastFrameInc = videoBoxWidth / 4;

                    try {
                        myGraphic.DrawImage(resizedFrame, 0, 0); //new rect
                        myGraphic.DrawImage(setupIcon, 0, 0);
                        myGraphic.DrawImage(playIcon, lastFrameInc, 0);
                        myGraphic.DrawImage(pauseIcon, lastFrameInc * 2, 0);
                        myGraphic.DrawImage(teardownIcon, lastFrameInc * 3, 0);
                    }
                    catch(Exception e)
                    {

                    }


                    _view.postFrame(resizedFrame);
                }
                
            }
        }

        

        public void addButton(int width, int height)
        {
            //Add the transparent buttons for when the video isnt playing
            
            Image resizedFrame = new Bitmap(lastFrame, new Size(width, height));
            Graphics myGraphic = Graphics.FromImage(resizedFrame);
            int lastFrameInc = width / 4;
            

            myGraphic.DrawImage(resizedFrame, 0, 0); //new rect
            myGraphic.DrawImage(setupIcon, 0, 0);
            myGraphic.DrawImage(playIcon, lastFrameInc, 0);
            myGraphic.DrawImage(pauseIcon, lastFrameInc * 2, 0);
            myGraphic.DrawImage(teardownIcon, lastFrameInc * 3, 0);


            _view.postFrame(resizedFrame);
        }

       

        public void getLastFrame()
        {
            _view.postFrame(lastFrame);
        }

        //These for function cause sending rtsp commands to the server
        public void setup()
        {
            _view.addToStatus("RTSP Request: SETUP");
            _RTSPModel.sendMessage("setup", videoName, frameReceiverPortNumber);
            
            _view.addToRequest(((RTSPmodel)_RTSPModel).getLastServerResponse());
           
        }
        public void play()
        {
            _view.addToStatus("RTSP Request: PLAY");
            _RTSPModel.sendMessage("play", videoName, frameReceiverPortNumber);
            _view.addToRequest(((RTSPmodel)_RTSPModel).getLastServerResponse());
         
        }
        public void pause()
        {
            _view.addToStatus("RTSP Request: PAUSE");
            _RTSPModel.sendMessage("pause", videoName, frameReceiverPortNumber);
            _view.addToRequest(((RTSPmodel)_RTSPModel).getLastServerResponse());
            
        }
        public void teardown()
        {
            _view.addToStatus("RTSP Request: TEARDOWN");
            _RTSPModel.sendMessage("teardown", videoName, frameReceiverPortNumber);
            _view.addToRequest(((RTSPmodel)_RTSPModel).getLastServerResponse());
            
        }

        //Function for thread to wait on rtsp commands
        public void waitForCommands()
        {
            //Model for receiving the frames of the video
            RTPmodel _rtpModel = new RTPmodel(ipaddress);
            //Create new thread for listening for frames to be sent to the client
            Thread frameWaitingThread = new Thread(new ParameterizedThreadStart(waitForFrames));
            frameWaitingThread.IsBackground = true;
            frameWaitingThread.Start(_rtpModel);
            

            //Create the TCP socket
            _RTSPModel.createSocket(ipaddress, currentPort);

            //Wait for rtsp commands
            while (true)
            {
                currentMessage = "none";
            }
        }

        //View tells the controller to connect to the server
        public void connectToServer()
        {
            _RTSPThread = new Thread(waitForCommands);
            _RTSPThread.IsBackground = true;
            _RTSPThread.Start();
        }
    }
}
