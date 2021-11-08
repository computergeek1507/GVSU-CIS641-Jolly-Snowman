using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emgu_Test
{
	public class FrameEventArgs : EventArgs
	{
		public double FrameCount { get; set; }
		public double CurrentFrame { get; set; }
	}
	public class VideoProcessing
	{
		public delegate void FrameEventHandler(object sender, FrameEventArgs e);
		public FrameEventHandler CurrentFrame;
		public event EventHandler<Bitmap> ImageSent;
		public event EventHandler<string> MessageSent;

		//int NODEON = 500;
		//int NODEOFF = 200;

		VideoSettings _settings;
		VideoCapture _videoCapture;
		LightManager _lightManager;

		double _currentFrameNo = 0;
		double _totalFrames = 0;
		double _fps = 0;
		bool _stop = false;

		public VideoProcessing(LightManager lightManager, VideoSettings settings) {
			_lightManager = lightManager;
			_settings = settings;

		}
		void OnMessageSent(string message) => MessageSent?.Invoke(this, message);

		void OnImageSent(Bitmap e) => ImageSent?.Invoke(this, e);

		void OnCurrentFrameSent(FrameEventArgs e) => CurrentFrame?.Invoke(this, e);

		public void SendFrameValue( double frame, double total)
		{
			OnCurrentFrameSent(new FrameEventArgs
			{
				CurrentFrame = frame,
				FrameCount = total
			});
		}

		public void SetStop(bool stop = true)
		{
			_stop = stop;
		}

		public void LoadVideo(string fileName)
		{
			//_settings = settings;
			_settings.FileName = fileName;
			_videoCapture = new VideoCapture(_settings.FileName);

			_fps = _videoCapture.Get(Emgu.CV.CvEnum.CapProp.Fps);
			_totalFrames = _videoCapture.Get(Emgu.CV.CvEnum.CapProp.FrameCount);

			SendFrameValue(0 , _totalFrames);
			OnMessageSent("Video Loaded: " + _settings.FileName);
		}

		public void ProcessSingleFrame(int frameIndex)
		{
			_videoCapture.Set(Emgu.CV.CvEnum.CapProp.PosFrames, frameIndex);

			var frame = _videoCapture.QueryFrame();
			ProcessFrame(frame, true);
		}

		public void ScrubFrame(int frameIndex)
		{
			_videoCapture.Set(Emgu.CV.CvEnum.CapProp.PosFrames, frameIndex);

			var frame = _videoCapture.QueryFrame();
			if (null == frame)
			{
				return;
			}
			OnImageSent(frame.ToBitmap());
		}

		public void ProcessVideo()
		{
			_stop = false;
			ResetVideoFileData();
			while (_currentFrameNo < _totalFrames && !_stop)
			{
				var frame = _videoCapture.QueryFrame();
				if (frame == null)
				{
					break;
				}
				ProcessFrame(frame);
				SendFrameValue(_currentFrameNo, _totalFrames);
				_currentFrameNo += 1;
				//Task.Delay(Convert.ToInt32(1000.0 / _fps));
			}
		}

		public void ResetVideoFileData()
		{
			_lightManager.Clear();
			_currentFrameNo = 0;
			_videoCapture.Set(Emgu.CV.CvEnum.CapProp.PosFrames, _currentFrameNo);
		}

		public void SetupCamera(int cameraIdx)
		{
			_lightManager.Clear();
			_videoCapture = new VideoCapture(cameraIdx);
		}

		public bool ProcessCameraFrame()
		{
			var frame = _videoCapture.QueryFrame();
			if (frame == null)
			{
				return false;
			}
			return ProcessFrame(frame);
		}

		public bool ProcessFrame(Mat frame_in, bool view_only = false)
		{
			//https://learnopencv.com/blob-detection-using-opencv-python-c/

			bool foundNode = false;
			//blur before grey
			if (_settings.BlurSize != 0)
			{
				//must be odd so round evens to odds
				int odd_blur = ((_settings.BlurSize / 2) * 2) + 1;
				CvInvoke.GaussianBlur(frame_in, frame_in, new Size(odd_blur, odd_blur), 0);
			}

			//convert to greyscale
			Mat grey = new Mat();
			CvInvoke.CvtColor(frame_in, grey, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

			//CvInvoke.Threshold(grey, grey, _settings.GreyThreshold, 255, ThresholdType.Binary);

			if (_settings.ErodeSize != 0)
			{
				CvInvoke.Erode(grey, grey, null, new Point(-1, -1), _settings.ErodeSize, BorderType.Default, new MCvScalar(1));
				//CvInvoke.Erode(grey, grey, new ScalarArray(_settings.ErodeSize), new Point(-1, -1), 1, BorderType.Constant, new MCvScalar(255, 255, 255));
			}

			if (_settings.DilateSize != 0)
			{
				CvInvoke.Dilate(grey, grey, null, new Point(-1, -1), _settings.DilateSize, BorderType.Constant, new MCvScalar(1));
			}

			SimpleBlobDetectorParams EMparams = new SimpleBlobDetectorParams();
			SimpleBlobDetector detector;

			EMparams.MinThreshold = _settings.GreyThreshold;
			EMparams.MaxThreshold = 255;

			EMparams.FilterByArea = true;
			EMparams.MinArea = _settings.MinBlobSize;
			EMparams.MaxArea = _settings.MaxBlobSize;

			EMparams.FilterByCircularity = true;
			EMparams.MinCircularity = _settings.MinCircularity;
			EMparams.MaxCircularity = 1.00F;

			//Filter by Convexity
			EMparams.FilterByConvexity = true;
			EMparams.MinConvexity = _settings.MinConvexity;
			EMparams.MaxConvexity = 1.00F;

			// Filter by Inertia
			EMparams.FilterByInertia = true;
			EMparams.MinInertiaRatio = _settings.MinInertiaRatio;
			EMparams.MaxInertiaRatio = 1.00F;

			EMparams.FilterByColor = true;
			EMparams.blobColor = _settings.Color;

			VectorOfKeyPoint keyPoints = new VectorOfKeyPoint();

			Mat im = new Mat();

			detector = new SimpleBlobDetector(EMparams);

			detector.DetectRaw(grey, keyPoints);

			Mat im_with_keypoints = new Mat();
			Bgr color = new Bgr(0, 0, 255);
			Features2DToolbox.DrawKeypoints(frame_in, keyPoints, im_with_keypoints, color, Features2DToolbox.KeypointDrawType.DrawRichKeypoints);

			if (!view_only)
			{
				//skip start frames for now
				if (keyPoints.Size == 1)
				{
					for (int i = 0; i < keyPoints.Size; ++i)
					{
						if (keyPoints[i].Size < _settings.MinLightSize)
						{
							continue;
						}
						if (_lightManager.AddLight(keyPoints[0].Point, keyPoints[0].Size))
						{
							foundNode = true;
							break;
						}
					}
				}

				DrawFoundNodes(im_with_keypoints);
			}
			// Show blobs
			OnImageSent(im_with_keypoints.ToBitmap());

			//CvInvoke.Imshow("Blob Detector " + keyPoints.Size, grey);
			return foundNode;
		}

		private void DrawFoundNodes(Mat mat)
		{
			MCvScalar color = new MCvScalar(255, 0, 0);
			foreach (var light in _lightManager.GetLights())
			{
				CvInvoke.Circle(mat, light.Position, light.Diameter / 2, color, -1);
				CvInvoke.PutText(mat, light.Number.ToString(), light.Position, FontFace.HersheySimplex, 1.0, new Bgr(Color.Red).MCvScalar,3);
			}
		}
	}
}
