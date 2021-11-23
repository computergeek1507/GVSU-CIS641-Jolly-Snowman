using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kadmium_sACN;
using Kadmium_sACN.SacnSender;

namespace Emgu_Test
{
    public class E131OutputManager
    {
        public event EventHandler<int> CurrentNodeSent;
        public event EventHandler<string> MessageSent;

        VideoSettings _settings;
        VideoProcessing _processer;

        bool _stop = false;

        public E131OutputManager(VideoSettings settings, VideoProcessing processer)
        {
            _settings = settings;
            _processer = processer;
        }

        /// <summary>
        /// Event to send messages to the logger box
        /// </summary>
        /// <param name="message">Log Message</param>
        void OnMessageSent(string message) => MessageSent.Invoke(this, message);

        /// <summary>
        /// Event to update the node slider to provide feedback to the user
        /// </summary>
        /// <param name="node">Curent Light being processed</param>
        void OnCurrentNodeSent(int node) => CurrentNodeSent.Invoke(this, node);

        /// <summary>
        /// Loop thought the number of lights, send a packet to turn on a light then trigger a frame capture
        /// </summary>
        public void StartOutput() 
        {
            _stop = false;
            if (!PingIP())
            {
                return;
            }
            _processer.SetupCamera();
            for (int node = 0; node < _settings.LightCount; ++node)
            {
                if (_stop)
                {
                    break;
                }
                bool worked = SendPacket(node);
                OnCurrentNodeSent(node);
                Application.DoEvents();
                Thread.Sleep(1000);
                _processer.ProcessCameraFrame();
            }
        }

        /// <summary>
        /// Stop the Light Output Capture
        /// </summary>
        public void StopOutput()
        {
            _stop = true;
        }

        /// <summary>
        /// Send E131 Packet to the Light Controller
        /// </summary>
        /// <param name="nodeIndex">Light Index</param>
        /// <returns>Worked</returns>
        private bool SendPacket(int nodeIndex)
        {
            try
            {
                IPAddress address = IPAddress.Parse(_settings.IPAddress);
                byte[] cid = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
                //UInt16 universe = 1;
                string sourceName = "My lovely source";
                SacnPacketFactory factory = new SacnPacketFactory(cid, sourceName);

                /// an E.131 Universes is a metadata ID to identifiy the packet the light controller should use/respond to
                /// An E.131 Universes have a Max channel buffer size of 512
                /// 512 divided by 3 (channels per RGB light) is 170.667, round to 170 or 510 channels.
                /// increment to the next universe when we go over the max buffer size.
                ushort unv = _settings.Universe;
                unv += (ushort)(nodeIndex / 170);
                nodeIndex = (nodeIndex % 170);
                byte[] values = GetNodeData(nodeIndex);

                var packet = factory.CreateDataPacket(unv, values);
                using var sacnSender = new UnicastSacnSender(address);

                sacnSender.Send(packet);
                return true;
            }
            catch (Exception ex) 
            {
                OnMessageSent(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Create and Populate an E131 buffer with the data to turn a Light on
        /// </summary>
        /// <param name="index">Light Index</param>
        /// <returns>E131 Channel buffer</returns>
        private byte[] GetNodeData(int index) 
        {
            byte[] values = new byte[512];
            Array.Fill(values, (byte)0x00);//fill the channel buffer with blank(off) light data

            for (int i = 0; i < 3; ++i)//only populate the currents LEDs three RGB channels with "on" data
            {
                values[(index * 3) + i] = _settings.Brightness;
            }

            return values;
        }

        /// <summary>
        /// Ping the Light Controller to see if it is active on the network
        /// </summary>
        /// <returns>reachable</returns>
        private bool PingIP()
        {
            try
            {
                //https://docs.microsoft.com/en-us/dotnet/api/system.net.networkinformation.ping?view=net-5.0
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();

                // Use the default Ttl value which is 128,
                // but change the fragmentation behavior.
                options.DontFragment = true;

                // Create a buffer of 32 bytes of data to be transmitted.
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;
                IPAddress address = IPAddress.Parse(_settings.IPAddress);
                PingReply reply = pingSender.Send(address, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    OnMessageSent("Could not Ping IP:" + _settings.IPAddress);
                    return false;
                }
            }
            catch (Exception ex)
            {
                OnMessageSent(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Send a packet to turn on one light then trigger a frame capture
        /// </summary>
        internal void OutputLight(int light)
        {
            //_stop = false;
            if (!PingIP())
            {
                return;
            }
            _processer.SetupCamera();

            bool worked = SendPacket(light);
            //OnCurrentNodeSent(node);
            Application.DoEvents();
            Thread.Sleep(1000);
            _processer.ProcessCameraFrame(true);
            
        }
    }
}
