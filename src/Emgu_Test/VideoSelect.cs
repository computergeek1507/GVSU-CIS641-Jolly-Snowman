using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emgu_Test
{
    public partial class VideoSelect : Form
    {
        Mode _mode = Mode.FileMode;
        VideoSettings _settings;
        public VideoSelect(VideoSettings settings)
        {
            _settings = settings;
            InitializeComponent();

            var cameras = CameraManager.ListOfAttachedCameras();

            foreach (var cam in cameras)
            {
                comboBoxLocal.Items.Add(cam);
            }
            _mode = _settings.ProcessMode;
            textBoxVideoFile.Text = _settings.FileName;
            textBoxRemote.Text = _settings.RemoteCameraPath;
            if (comboBoxLocal.Items.Count > _settings.LocalCameraIndex) 
            {
                comboBoxLocal.SelectedIndex = _settings.LocalCameraIndex; 
            }

            if (string.IsNullOrEmpty(textBoxRemote.Text))
            {
                textBoxRemote.Text = @"rtsp://";
            }    

            SetMode(_mode);

            radioButtonLocal.CheckedChanged += new System.EventHandler(radioButtonLocal_CheckedChanged);
            radioButtonRemote.CheckedChanged += new System.EventHandler(radioButtonRemote_CheckedChanged);
            radioButtonFile.CheckedChanged += new System.EventHandler(radioButtonFile_CheckedChanged);

        }

        Mode GetMode() { return _mode; }

        private void SetMode(Mode mode)
        {
            _mode = mode;

            radioButtonLocal.CheckedChanged -= new System.EventHandler(radioButtonLocal_CheckedChanged);
            radioButtonRemote.CheckedChanged -= new System.EventHandler(radioButtonRemote_CheckedChanged);
            radioButtonFile.CheckedChanged -= new System.EventHandler(radioButtonFile_CheckedChanged);

            switch (mode) 
            {                
                case Mode.FileMode:
                    textBoxVideoFile.Enabled = true;
                    radioButtonFile.Checked = true;
                    buttonFile.Enabled = true;
                    comboBoxLocal.Enabled = false;
                    textBoxRemote.Enabled = false;
                    buttonTestRemote.Enabled = false;
                    radioButtonLocal.Checked = false;
                    radioButtonRemote.Checked = false;
                    break;
                case Mode.LocalCameraMode:
                    comboBoxLocal.Enabled = true;
                    radioButtonLocal.Checked = true;
                    textBoxRemote.Enabled = false;
                    textBoxVideoFile.Enabled = false;
                    buttonFile.Enabled = false;
                    buttonTestRemote.Enabled = false;
                    radioButtonRemote.Checked = false;
                    radioButtonFile.Checked = false;
                    break;
                case Mode.RemoteCameraMode:
                    textBoxRemote.Enabled = true;
                    buttonTestRemote.Enabled = true;
                    radioButtonRemote.Checked = true;
                    textBoxVideoFile.Enabled = false;
                    buttonFile.Enabled = false;
                    comboBoxLocal.Enabled = false;
                    radioButtonLocal.Checked = false;
                    radioButtonFile.Checked = false;
                    break;
            }
            radioButtonLocal.CheckedChanged += new System.EventHandler(radioButtonLocal_CheckedChanged);
            radioButtonRemote.CheckedChanged += new System.EventHandler(radioButtonRemote_CheckedChanged);
            radioButtonFile.CheckedChanged += new System.EventHandler(radioButtonFile_CheckedChanged);

        }

        private void radioButtonFile_CheckedChanged(object sender, EventArgs e)
        {
            SetMode(Mode.FileMode);
        }

        private void radioButtonRemote_CheckedChanged(object sender, EventArgs e)
        {
            SetMode(Mode.RemoteCameraMode);
        }
        private void radioButtonLocal_CheckedChanged(object sender, EventArgs e)
        {
            SetMode(Mode.LocalCameraMode);
        }

        private void comboBoxLocal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonTestRemote_Click(object sender, EventArgs e)
        {
            try
            {
                VideoCapture remoteCamera = new VideoCapture(textBoxRemote.Text);
                string test = remoteCamera.BackendName;
                MessageBox.Show("Worked\n" + test);
            }
            catch (Exception ex) {
                MessageBox.Show("Didnt Work\n" + ex.Message);
            }
        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            if (openFileDialogVideo.ShowDialog() == DialogResult.OK)
            {
                textBoxVideoFile.Text = openFileDialogVideo.FileName;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _settings.ProcessMode = _mode;
            switch (_mode)
            {
                case Mode.FileMode:
                    _settings.FileName = textBoxVideoFile.Text;
                    break;
                case Mode.LocalCameraMode:
                    _settings.LocalCameraIndex = comboBoxLocal.SelectedIndex;
                    break;
                case Mode.RemoteCameraMode:
                    _settings.RemoteCameraPath = textBoxRemote.Text;
                    break;
            }            
        }
    }
}
