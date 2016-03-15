using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SE3314Assignment2Client
{
    public partial class Form1 : Form
    {
        static Controller _controller;

        //Delegate for adding strings to the form
        public delegate void formStringDelegate(string infoToDisplay);
        //Instantiate the delegates
        formStringDelegate addToStatusDelegate;
        formStringDelegate addToRequestDelegate;

        bool isMouseOverVideo;
        int videoWidth;
        int videoHeight;
        int videoInc;
        bool isPlaying;

        //Delegate for displaying the next frame of the video
        public delegate void formImageDelegate(Image frameToShow);
        //Instantiate the delegate
        formStringDelegate addFrameDelegate;
        

        public Form1()
        {
            InitializeComponent();
            //Instantiate the delegates
            addToStatusDelegate = new formStringDelegate(addToStatus);
            addToRequestDelegate = new formStringDelegate(addToRequest);
            _controller = new Controller(this, videoBox.Width, videoBox.Height, addToStatusDelegate, addToRequestDelegate);
            _controller.setIPAddress(ipaddressBox.Text);
            playButton.Enabled = false;
            pauseButton.Enabled = false;
            setupButton.Enabled = false;
            teardownButton.Enabled = false;
            isMouseOverVideo = false;
            videoWidth = videoBox.Width;
            videoHeight = videoBox.Height;
            videoInc = videoBox.Width / 4; //For detecting button on screen
            videoSelect.SelectedIndex = 0;
            isPlaying = false;
        }

        public void addToStatus(string newInfo)
        {
            //Make sure that no other threads other than this one access the form
            if (this.statusBox.InvokeRequired)
            {
                try
                {
                    //If not the correct thread, create a new delegate to handle the call
                    formStringDelegate newStringDel = new formStringDelegate(addToStatus);
                    this.Invoke(newStringDel, newInfo);
                }
                catch (Exception e)
                {

                }
            }
            else
            {
                statusBox.Items.Add(newInfo + "\n");//Add the information to the statusbox
            }
        }

        //Add a line to the request box
        public void addToRequest(string newInfo)
        {
            if (this.requestBox.InvokeRequired)
            {
                try
                {
                    formStringDelegate newStringDel = new formStringDelegate(addToRequest);
                    this.Invoke(newStringDel, newInfo);
                }
                catch (Exception e)
                {

                }
            }
            else
            {
                requestBox.Items.Add(newInfo + "\n");
            }

        }

        public void addRTPToStatus(string newInfo)
        {
            //Only add it if the checkbox is selected
            if (printHeaderCheckbox.Checked)
            {
                //Make sure that no other threads other than this one access the form
                if (this.statusBox.InvokeRequired)
                {
                    try
                    {
                        formStringDelegate newStringDel = new formStringDelegate(addToStatus);
                        this.Invoke(newStringDel, newInfo);
                    }
                    catch (Exception e)
                    {

                    }
                }
                else
                {
                    statusBox.Items.Add(newInfo + "\n");
                }
            }
        }

        public void addPacketToStatus(string newInfo)
        {
            //Only add it if the checkbox is selected
            if (packetReportCheckbox.Checked)
            {
                //Make sure that no other threads other than this one access the form
                if (this.statusBox.InvokeRequired)
                {
                    try
                    {
                        formStringDelegate newStringDel = new formStringDelegate(addToStatus);
                        this.Invoke(newStringDel, newInfo);
                    }
                    catch (Exception e)
                    {

                    }
                }
                else
                {
                    statusBox.Items.Add(newInfo + "\n");
                }
            }
        }

        public void postFrame(Image nextFrame)
        {
            
            //Make sure that no other threads other than this one access the form
            if (this.statusBox.InvokeRequired)
            {
                try
                {
                    formImageDelegate newImageDel = new formImageDelegate(postFrame);
                    this.Invoke(newImageDel, nextFrame);
                }
                catch (Exception e)
                {

                }
            }
            else
            {
                //Resize the frame then put it on screen
                try {
                    videoBox.Image = new Bitmap(nextFrame, new Size(videoWidth, videoHeight));
                }
                catch(Exception e)
                {
                    
                }
                
            }
            
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            //Create a connection to the server
            _controller.connectToServer();
            connectButton.Enabled = false;
            setupButton.Enabled = true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void setupButton_Click(object sender, EventArgs e)
        {
            _controller.setup();
            setupButton.Enabled = false;
            playButton.Enabled = true;
            teardownButton.Enabled = true;
            isPlaying = false;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            _controller.play();
            playButton.Enabled = false;
            pauseButton.Enabled = true;
            isPlaying = true;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            _controller.pause();
            pauseButton.Enabled = false;
            playButton.Enabled = true;
            isPlaying = false;
        }

        private void teardownButton_Click(object sender, EventArgs e)
        {
            _controller.teardown();
            teardownButton.Enabled = false;
            pauseButton.Enabled = false;
            playButton.Enabled = false;
            setupButton.Enabled = true;
            isPlaying = false;
        }

        private void portNumberBox_ValueChanged(object sender, EventArgs e)
        {
            _controller.setCurrentPort((int)portNumberBox.Value);
        }

        private void ipaddressBox_TextChanged(object sender, EventArgs e)
        {
            _controller.setIPAddress(ipaddressBox.Text);
        }

        private void videoSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controller.setVideo(videoSelect.Text);
        }

        private void videoBox_MouseHover(object sender, EventArgs e)
        {
            
        }

        public bool getIsMouseOverVideo()
        {
            return isMouseOverVideo;
        }

       

        private void videoBox_MouseLeave(object sender, EventArgs e)
        {
            //No server to make requests to yet. 
            if (connectButton.Enabled)
            {
                return;
            }

            //Make button invisible
            isMouseOverVideo = false;
            if (!isPlaying)
                _controller.getLastFrame();
        }

        private void videoBox_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void videoBox_MouseEnter(object sender, EventArgs e)
        {
            //Make the button visible when the video isn't playing
            if (!connectButton.Enabled)
            {
                isMouseOverVideo = true;
                if(!isPlaying)
                _controller.addButton(videoWidth, videoHeight);
            }
            
        }

        private void videoBox_MouseUp(object sender, MouseEventArgs e)
        {
            //No server to make requests to yet. 
            if (connectButton.Enabled)
            {
                return;
            }

            
            //Check if its over a button and do the appropriate action
            if (e.Location.X > 0 && e.Location.X < videoInc && e.Location.Y > 0 && e.Location.Y < videoInc)
            {
                //Setup
                if (setupButton.Enabled)
                {
                    _controller.setup();
                    setupButton.Enabled = false;
                    playButton.Enabled = true;
                    teardownButton.Enabled = true;
                }
            }
            else if (e.Location.X > videoInc && e.Location.X < videoInc * 2 && e.Location.Y > 0 && e.Location.Y < videoInc)
            {
                //Play
                if (playButton.Enabled)
                {
                    _controller.play();
                    playButton.Enabled = false;
                    pauseButton.Enabled = true;
                }
            }
            else if (e.Location.X > videoInc * 2 && e.Location.X < videoInc * 3 && e.Location.Y > 0 && e.Location.Y < videoInc)
            {
                //Pause
                if (pauseButton.Enabled)
                {
                    _controller.pause();
                    pauseButton.Enabled = false;
                    playButton.Enabled = true;
                }
            }
            else if (e.Location.X > videoInc * 3 && e.Location.X < videoInc * 4 && e.Location.Y > 0 && e.Location.Y < videoInc)
            {
                //Teardown
                if (teardownButton.Enabled)
                {
                    _controller.teardown();
                    teardownButton.Enabled = false;
                    pauseButton.Enabled = false;
                    playButton.Enabled = false;
                    setupButton.Enabled = true;
                }
            }
        }
    }
}
