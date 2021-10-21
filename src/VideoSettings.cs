using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Emgu_Test
{
	///<summary>
	// Processing Settings class
	///</summary>
	///
	[DefaultPropertyAttribute("VideoSettings")]
	[Serializable]
	[XmlRoot("VideoSettings")]
	public class VideoSettings
	{

		private string _fileName;

		private int _min_blob_size = 200;
		private int _max_blob_size = 2000;
		private int _grey_threshold = 100;
		private int _blur_size = 5;
		private int _erode_size = 5;
		private int _dilate_size = 5;
		private byte _color = 255;
		private float _min_circularity = 0.50F;
		private float _min_convexity = 0.50F;
		private float _min_inertia_ratio = 0.40F;
		private int _light_count = 50;
		private int _min_light_size = 30;
		private int _grid_scale = 10;

		[CategoryAttribute("File Settings"), DescriptionAttribute("File Path of Video")]
		public string FileName
		{
			get
			{
				return _fileName;
			}
			set
			{
				_fileName = value;
			}
		}

		[CategoryAttribute("Video Settings"), DescriptionAttribute("Minimum Blob Size")]
		public int MinBlobSize
		{
			get
			{
				return _min_blob_size;
			}
			set
			{
				_min_blob_size = value;
			}
		}

		[ CategoryAttribute("Video Settings"), DescriptionAttribute("Maximum Blob Size")]
		public int MaxBlobSize
		{
			get
			{
				return _max_blob_size;
			}
			set
			{
				_max_blob_size = value;
			}
		}


		[ CategoryAttribute("Video Settings"), DescriptionAttribute("Grey Value Threshold")]
		public int GreyThreshold
		{
			get
			{
				return _grey_threshold;
			}
			set
			{
				_grey_threshold = value;
			}
		}

		[CategoryAttribute("Video Settings"), DescriptionAttribute("Blob Erode Size")]
		public int ErodeSize
		{
			get
			{
				return _erode_size;
			}
			set
			{
				_erode_size = value;
			}
		}

		[CategoryAttribute("Video Settings"), DescriptionAttribute("Blob Dilate Size")]
		public int DilateSize
		{
			get
			{
				return _dilate_size;
			}
			set
			{
				_dilate_size = value;
			}
		}

		[CategoryAttribute("Video Settings"), DescriptionAttribute("Blur Size")]
		public int BlurSize
		{
			get
			{
				return _blur_size;
			}
			set
			{
				_blur_size = value;
			}
		}

		[CategoryAttribute("Video Settings"), DescriptionAttribute("Color")]
		public byte Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
			}
		}

		[CategoryAttribute("Video Settings"), DescriptionAttribute("Min Circularity")]
		public float MinCircularity
		{
			get
			{
				return _min_circularity;
			}
			set
			{
				_min_circularity = value;
			}
		}

		[CategoryAttribute("Video Settings"), DescriptionAttribute("Min Convexity")]
		public float MinConvexity
		{
			get
			{
				return _min_convexity;
			}
			set
			{
				_min_convexity = value;
			}
		}

		[CategoryAttribute("Video Settings"), DescriptionAttribute("Min Inertia Ratio")]
		public float MinInertiaRatio
		{
			get
			{
				return _min_inertia_ratio;
			}
			set
			{
				_min_inertia_ratio = value;
			}
		}

		[CategoryAttribute("Light Settings"), DescriptionAttribute("Number of Christmas Lights")]
		public int LightCount
		{
			get
			{
				return _light_count;
			}
			set
			{
				_light_count = value;
			}
		}

		[CategoryAttribute("Light Settings"), DescriptionAttribute("Minimum Light Size")]
		public int MinLightSize
		{
			get
			{
				return _min_light_size;
			}
			set
			{
				_min_light_size = value;
			}
		}

		[CategoryAttribute("Export Settings"), DescriptionAttribute("Grid Scale")]
		public int GridScale
		{
			get
			{
				return _grid_scale;
			}
			set
			{
				_grid_scale = value;
			}
		}
	}
}
