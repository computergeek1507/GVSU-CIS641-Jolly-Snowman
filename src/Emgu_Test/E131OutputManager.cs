using System;
using System.Collections.Generic;
using System.Linq;
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

        void OnMessageSent(string message) => MessageSent.Invoke(this, message);

        void OnCurrentNodeSent(int node) => CurrentNodeSent.Invoke(this, node);

        public void StartOutput() 
        {
            _stop = false;
            if (!PingIP())
            {
                return;
            }
            _processer.SetupCamera(0);
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

        public void StopOutput()
        {
            _stop = true;
        }

        private bool SendPacket(int nodeIndex)
        {
            try
            {
                IPAddress address = IPAddress.Parse(_settings.IPAddress);
                byte[] cid = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
                //UInt16 universe = 1;
                string sourceName = "My lovely source";
                SacnPacketFactory factory = new SacnPacketFactory(cid, sourceName);

                ushort unv = _settings.Universe;
                unv += (ushort)(nodeIndex / 170);
                nodeIndex = (nodeIndex % 170);
                byte[] values = GetNodeData(nodeIndex);

                var packet = factory.CreateDataPacket(_settings.Universe, values);
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

        private byte[] GetNodeData(int index) 
        {
            byte[] values = new byte[512];
            Array.Fill(values, (byte)0x00);

            //int index1 = (index * 3);
            //int index2 = (index * 3) + 1;
            //int index3 = (index * 3) + 2;
            for (int i = 0; i < 3; ++i)
            {
                values[(index * 3) + i] = _settings.Brightness;
            }

            return values;
        }

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

        internal void OutputLight(int light)
        {
            //_stop = false;
            if (!PingIP())
            {
                return;
            }
            _processer.SetupCamera(0);

            bool worked = SendPacket(light);
            //OnCurrentNodeSent(node);
            Application.DoEvents();
            Thread.Sleep(1000);
            _processer.ProcessCameraFrame();
            
        }
    }
}
