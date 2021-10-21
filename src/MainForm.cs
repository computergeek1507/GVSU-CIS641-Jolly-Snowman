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

		VideoSettings _videoSettings;
		readonly VideoProcessing _videoProcessing;
		readonly LightManager _lightManager;

		public MainForm()
		{
			InitializeComponent();

			_listBoxLog = new ListBoxLog(logListBox);

			if (!(Directory.Exists(_appDataFolder)))
			{
				Directory.CreateDirectory(_appDataFolder);
			}

			_videoSettings = new VideoSettings();
			LoadSettings();
			_lightManager = new LightManager();
			_videoProcessing = new VideoProcessing(_lightManager);

			dataGridViewLights.DataSource = _lightManager.GetBinding();

			videoPropertyGrid.SelectedObject = _videoSettings;

			_videoProcessing.MessageSent += Logger_EventLogged;
			_videoProcessing.ImageSent += Video_ShowFrame;
			_videoProcessing.CurrentFrame += Video_SetFrameValue;
			_lightManager.MessageSent += Logger_EventLogged;
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

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				_videoSettings.FileName = openFileDialog1.FileName;
				_videoProcessing.LoadVideo(_videoSettings);
				Application.DoEvents();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void videoPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			SaveSettings();
		}

		private void processVideoButton_Click(object sender, EventArgs e)
		{
			_videoProcessing.ProcessVideo();
		}

		private void processFrameButton_Click(object sender, EventArgs e)
		{
			_videoProcessing.ProcessSingleFrame(frameTrackBar.Value);
		}

		private void frameTrackBar_Scroll(object sender, EventArgs e)
		{
			_videoProcessing.ScrubFrame(frameTrackBar.Value);
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
				_videoProcessing.LoadVideo(_videoSettings);
			}
		}

		private void buttonStop_Click(object sender, EventArgs e)
		{
			_videoProcessing.SetStop();
		}

		private void exportAsXModelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (xModelSaveFileDialog.ShowDialog() == DialogResult.OK)
			{
				_lightManager.ExportModel(xModelSaveFileDialog.FileName, _videoSettings.GridScale);
			}
		}
	}
}
