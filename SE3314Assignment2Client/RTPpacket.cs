using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SE3314Assignment2Client
{
    class RTPpacket
    {
        byte[] byteArrayToSend;
        string lastHeader;
        string lastPacket;

        //Get the last header of the udp packet sent to the client so it can be displayed on the form if wanted
        public string getLastHeader()
        {
            return lastHeader;
        }
        public string getLastPacket()
        {
            return lastPacket;
        }

        //Removes the rtp header from the passed byte array
        public byte[] extractPayload(byte[] receivedPacket)
        {
            int newArraySize = receivedPacket.Length - 12;
            byte[] frameArray = new byte[newArraySize];
            byte[] headerArray = new byte[12];

            for(int i=0; i<newArraySize; i++)
            {
                frameArray[i] = receivedPacket[i + 12];
            }
            for(int i=0; i<12; i++)
            {
                headerArray[i] = receivedPacket[i];
            }
            lastHeader = string.Concat(headerArray.Select(b => Convert.ToString(b, 2)));

            //Get the seq number, time stamp and type
            //Convert the bits to a readable integer
            //Seq Num
            byte[] seqNumArray = new byte[2];
            seqNumArray[0] = headerArray[3];
            seqNumArray[1] = headerArray[2];
            short seqNum = BitConverter.ToInt16(seqNumArray, 0);

            //Time stamp
            byte[] timeArray = new byte[4];
            timeArray[0] = headerArray[7];
            timeArray[1] = headerArray[6];
            timeArray[2] = headerArray[5];
            timeArray[3] = headerArray[4];
            int timeStamp = BitConverter.ToInt32(timeArray, 0);

            //Type
            byte[] typeArray = new byte[2];
            typeArray[0] = headerArray[1];
            typeArray[1] = 0;
            short typeNum = BitConverter.ToInt16(typeArray, 0);

            lastPacket = "Got RTP packet with SeqNum # " + seqNum + " TimeStamp: " + timeStamp + " ms, of type " + typeNum + "\n";

            return frameArray;
        }

        //Take the given payload and add the rtp header to it
        public byte[] packageFrame(byte[] frameArray, int currentTime, short seqNum)
        {
            byte[] byteThreeFour = BitConverter.GetBytes(seqNum); //Sequence Number
            byte[] byteFiveEight = BitConverter.GetBytes(currentTime);//Timestamp


            int length = 12 + (frameArray.Length);
            byteArrayToSend = new byte[length];
            byte[] lastHeaderaArray = new byte[12];

            lastHeaderaArray[0] = 128;//V P X CC
            lastHeaderaArray[1] = 26;//M and PT
            lastHeaderaArray[2] = byteThreeFour[1];
            lastHeaderaArray[3] = byteThreeFour[0];
            lastHeaderaArray[4] = byteFiveEight[3];
            lastHeaderaArray[5] = byteFiveEight[2];
            lastHeaderaArray[6] = byteFiveEight[1];
            lastHeaderaArray[7] = byteFiveEight[0];
            lastHeaderaArray[8] = 0;//SSRC
            lastHeaderaArray[9] = 0;
            lastHeaderaArray[10] = 0;
            lastHeaderaArray[11] = 0;

            //Records the last rtp header in a binary format
            lastHeader = string.Concat(lastHeaderaArray.Select(b => Convert.ToString(b, 2)));

            //Build the header for the new packet
            byteArrayToSend[0] = 128;//V P X CC
            byteArrayToSend[1] = 26;//M and PT
            byteArrayToSend[2] = byteThreeFour[1];
            byteArrayToSend[3] = byteThreeFour[0];
            byteArrayToSend[4] = byteFiveEight[3];
            byteArrayToSend[5] = byteFiveEight[2];
            byteArrayToSend[6] = byteFiveEight[1];
            byteArrayToSend[7] = byteFiveEight[0];
            byteArrayToSend[8] = 0;//SSRC
            byteArrayToSend[9] = 0;
            byteArrayToSend[10] = 0;
            byteArrayToSend[11] = 0;

            //Add the frame to the packet
            for (int i = 12; i < length; i++)
            {
                byteArrayToSend[i] = frameArray[i - 12];
            }


            return byteArrayToSend;
        }
    }
}
