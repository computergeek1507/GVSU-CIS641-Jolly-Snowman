using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using NLog;

namespace Emgu_Test
{
	public partial class MainForm : Form
	{
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
		public static ListBoxLog _listBoxLog;

		readonly string _appDataFolder = string.Format("{0}{1}{2}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.DirectorySeparatorChar, "Emgu_Test");

		ToolTip _frameToolTip;
		VideoSettings _videoSettings;
		readonly VideoProcessing _videoProcessing;
		readonly LightManager _lightManager;
		readonly E131OutputManager _e131OutputManager;

		public MainForm()
		{
			InitializeComponent();

			_listBoxLog = new ListBoxLog(logListBox);
			_frameToolTip = new ToolTip();
			_frameToolTip.AutoPopDelay = 5000;
			_frameToolTip.InitialDelay = 1000;
			_frameToolTip.ReshowDelay = 500;
			_frameToolTip.ShowAlways = true;

			if (!(Directory.Exists(_appDataFolder)))
			{
				Directory.CreateDirectory(_appDataFolder);
			}

			_videoSettings = new VideoSettings();
			LoadSettings();
			_lightManager = new LightManager();
			_videoProcessing = new VideoProcessing(_lightManager, _videoSettings);

			_e131OutputManager = new E131OutputManager(_videoSettings, _videoProcessing);

			dataGridViewLights.DataSource = _lightManager.GetBinding();

			videoPropertyGrid.SelectedObject = _videoSettings;

			_videoProcessing.MessageSent += Logger_EventLogged;
			_videoProcessing.ImageSent += Video_ShowFrame;
			_videoProcessing.CurrentFrame += Video_SetFrameValue;
			_lightManager.MessageSent += Logger_EventLogged;
			_e131OutputManager.MessageSent += Logger_EventLogged;
			_e131OutputManager.CurrentNodeSent += E131_SetNodeValue;

			SetMode();
		}

		private void Logger_EventLogged(object sender, string e)
		{
			_listBoxLog.Log( e);
		}

		private void Logger_EventLogged(object sender, LoggerEventArgs e)
		{
			_listBoxLog.Log(e.LogLevel, e.Message);
		}

		private void Video_ShowFrame(object sender, Bitmap e)
		{
			videoPictureBox.Image = e;
			Application.DoEvents();
		}

		private void Video_SetFrameValue(object sender, FrameEventArgs e)
		{
			this.frameTrackBar.Scroll -= new System.EventHandler(this.frameTrackBar_Scroll);
			frameTrackBar.Value = Convert.ToInt32(e.CurrentFrame);
			frameTrackBar.Maximum = Convert.ToInt32(e.FrameCount);
			frameTrackBar.Enabled = true;
			Application.DoEvents();
			this.frameTrackBar.Scroll += new System.EventHandler(this.frameTrackBar_Scroll);
		}

		private void E131_SetNodeValue(object sender, int e)
		{
			this.frameTrackBar.Scroll -= new System.EventHandler(this.frameTrackBar_Scroll);
			frameTrackBar.Value = e;
			//frameTrackBar.Maximum = Convert.ToInt32(e.FrameCount);
			frameTrackBar.Enabled = true;
			_frameToolTip.SetToolTip(frameTrackBar, e.ToString());
			Application.DoEvents();
			this.frameTrackBar.Scroll += new System.EventHandler(this.frameTrackBar_Scroll);
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			VideoSelect cameraSelect = new VideoSelect(_videoSettings);
			if (cameraSelect.ShowDialog() == DialogResult.OK)
			{
				videoPropertyGrid.Refresh();
				SetMode();
				SaveSettings();
				if (_videoSettings.ProcessMode == Mode.FileMode )
				{
					_videoProcessing.LoadVideo(_videoSettings.FileName);
					Application.DoEvents();
				}
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void videoPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			SetMode();
			SaveSettings();
		}

		private void processVideoButton_Click(object sender, EventArgs e)
		{
			if (_videoSettings.ProcessMode == Mode.LocalCameraMode ||
				_videoSettings.ProcessMode == Mode.RemoteCameraMode)
			{
				_e131OutputManager.StartOutput();
			}
			else
			{
				_videoProcessing.ProcessVideo();
			}
		}

		private void processFrameButton_Click(object sender, EventArgs e)
		{
			if (_videoSettings.ProcessMode == Mode.LocalCameraMode ||
				_videoSettings.ProcessMode == Mode.RemoteCameraMode)
			{
				_videoProcessing.ProcessSingleFrame(-1);
			}
			else
			{
				_videoProcessing.ProcessSingleFrame(frameTrackBar.Value);
			}
		}

		private void frameTrackBar_Scroll(object sender, EventArgs e)
		{
			if (_videoSettings.ProcessMode == Mode.LocalCameraMode ||
				_videoSettings.ProcessMode == Mode.RemoteCameraMode)
			{
				_e131OutputManager.OutputLight(frameTrackBar.Value);
				_frameToolTip.SetToolTip(frameTrackBar, frameTrackBar.Value.ToString());
			}
			else
			{
				_videoProcessing.ScrubFrame(frameTrackBar.Value);
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveSettings();
		}

		void LoadSettings()
		{
			var settingFile = _appDataFolder + Path.DirectorySeparatorChar + "settings.xml";

			try
			{
				if (File.Exists(settingFile))//see if file exists
				{
					XmlSerializer serializer = new XmlSerializer(typeof(VideoSettings));
					FileStream reader = new FileStream(settingFile, FileMode.Open);
					_videoSettings = (VideoSettings)serializer.Deserialize(reader);
					reader.Close();
				}
			}
			catch (Exception ex)
			{
				_listBoxLog.Log(Level.Warning, ex.Message);
			}
		}

		void SaveSettings()
		{
			var settingFile = _appDataFolder + Path.DirectorySeparatorChar + "settings.xml";
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(VideoSettings));
				TextWriter writer = new StreamWriter(settingFile);
				serializer.Serialize(writer, _videoSettings);
				writer.Close();
			}
			catch (Exception ex)
			{
				_listBoxLog.Log(Level.Warning, ex.Message);
			}
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			if (File.Exists(_videoSettings.FileName))//see if file exists
			{
				_videoProcessing.LoadVideo(_videoSettings.FileName);
			}
		}

		private void buttonStop_Click(object sender, EventArgs e)
		{
			_videoProcessing.SetStop();
			_e131OutputManager.StopOutput();
		}

		private void exportAsXModelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (xModelSaveFileDialog.ShowDialog() == DialogResult.OK)
			{
				_lightManager.ExportModel(xModelSaveFileDialog.FileName, _videoSettings.GridScale);
			}
		}

		private void SetMode()
		{
			if (_videoSettings.ProcessMode == Mode.LocalCameraMode || 
				_videoSettings.ProcessMode == Mode.RemoteCameraMode)
			{
				frameTrackBar.Maximum = Convert.ToInt32(_videoSettings.LightCount);
				frameTrackBar.Enabled = true;
				//frameTrackBar.Maximum = Convert.ToInt32(e.FrameCount);
			}
			else {
				frameTrackBar.Enabled = false;
			}
		}

    }
}
