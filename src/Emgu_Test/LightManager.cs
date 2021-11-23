using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Emgu_Test
{
	public class LightManager
	{
		readonly List<Light> _lights = new List<Light>();
		private readonly BindingSource _source = new BindingSource(); //binding is required to update GUI grid 

		public event EventHandler<string> MessageSent;

		int _index = 1;

		public LightManager()
		{
			_source.DataSource = _lights;
		}

		/// <summary>
		/// Event to send messages to the logger box
		/// </summary>
		/// <param name="message">Log Message</param>
		void OnMessageSent(string message) => MessageSent.Invoke(this, message);

		/// <summary>
		/// Added a Light
		/// </summary>
		/// <param name="loc">XY location</param>
		/// <param name="size">light radius</param>
		/// <returns></returns>
		public bool AddLight(PointF loc, float size)
		{
			Point locI = Point.Round(loc);
		   //look if light is already in list
		   var oldL = _lights.Find(item => Math.Abs(item.Position.X - locI.X) < 10.0 && Math.Abs(item.Position.Y - locI.Y) < 10.0);

			if (oldL != null) {
				return false;
			}

			_lights.Add(new Light {

				Position = locI,
				Diameter = (int)Math.Round(size),
				Number = _index
			});
			++_index; //increment the light count
			_source.ResetBindings(false);
			return true;
		}

		/// <summary>
		/// Clear Stored Light Data
		/// </summary>
		public void Clear()
		{
			_lights.Clear();
			_index = 1;
			_source.ResetBindings(false);
		}

		/// <summary>
		/// Find the Light obj matching the given X,Y coordinate pair.
		/// </summary>
		/// <returns>A reference to the Light</returns>
		public Light FindLight(int x, int y)
		{
			foreach (var node in _lights)
			{
				if (x == node.ScalePos.X && y == node.ScalePos.Y)
				{
					return node;
				}
			}

			return null;
		}

		public Tuple<int, int> GetBoundingSize(int scale)
		{
			int width = 0;
			int height = 0;
			foreach (var light in _lights)
			{
				width = Math.Max(width, light.Position.X);
				height = Math.Max(height, light.Position.Y);
				light.ScalePos = new Point(light.Position.X / scale, light.Position.Y / scale);
			}
			return Tuple.Create(width / scale, height / scale);
		}

		/// <summary>
		/// Get the bounding sizes for the xmodel based on the diameters of the blobs found.
		/// </summary>
		/// <returns>The width and height of the matrix size of the xmodel.</returns>
		public Tuple<int, int> GetBoundingSize_Diameter()
        {
			_lights.Sort(); //Sort based on the icomparable
			int smallestDiam = _lights[_lights.Count() - 1].Diameter;

			int scaler = 4; 
			int scale = smallestDiam / scaler; 
			
			return GetBoundingSize(scale);
		}

		/// <summary>
		/// Export the Light data as xModel file for the xLights application
		/// </summary>
		/// <param name="filename">Output file path</param>
		/// <param name="scale">scale the picture resolution to the xModel grid size</param>
		public void ExportModel(string filename, int scale)
		{
			FileInfo file = new FileInfo(filename);
			var cm = "";
			//var size = GetBoundingSize(scale);
			int x_max = 0;
			int x_min = 100000;
			int y_max = 0;
			int y_min = 100000;
			foreach (var light in _lights)
			{
				x_max = Math.Max(x_max, light.Position.X);
				x_min = Math.Min(x_min, light.Position.X);
				y_max = Math.Max(y_max, light.Position.Y);
				y_min = Math.Min(y_min, light.Position.Y);
			}

			int x_dist = ((x_max - x_min + 1) / scale) + 1;
			int y_dist = ((y_max - y_min + 1) / scale) + 1;

			foreach (var light in _lights)
			{
				light.ScalePos = new Point((light.Position.X - x_min) / scale, (light.Position.Y - y_min) / scale);
			}

			for (var y = 0; y <= y_dist; y++)
			{
				for (var x = 0; x <= x_dist; x++)
				{
					var cell = "";
					Light lght = FindLight(x, y);
					if (lght != null)
					{
						cell = lght.Number.ToString();
					}
					cm += cell + ",";
				}
				cm += ";";
			}

			cm = cm.TrimEnd(';');

			using (var f = new StreamWriter(filename))
			{
				f.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<custommodel \n");
				f.Write("name=\"{0}\" ", Path.GetFileNameWithoutExtension(file.Name));
				f.Write("parm1=\"{0}\" ", x_dist);
				f.Write("parm2=\"{0}\" ", y_dist);
				f.Write("StringType=\"RGB Nodes\" ");
				f.Write("Transparency=\"0\" ");
				f.Write("PixelSize=\"2\" ");
				f.Write("ModelBrightness=\"\" ");
				f.Write("Antialias=\"1\" ");
				f.Write("StrandNames=\"\" ");
				f.Write("NodeNames=\"\" ");

				f.Write("CustomModel=\"");
				f.Write(cm);
				f.Write("\" ");
				f.Write("SourceVersion=\"2021.27\" ");
				f.Write(" >\n");

				f.Write("</custommodel>");
				f.Close();
			}
			OnMessageSent("Saved: " + filename);
			_source.ResetBindings(false);
		}

		/// <summary>
		/// List of all the lights found
		/// </summary>
		/// <returns></returns>
		public List<Light> GetLights() { return _lights; }

		public BindingSource GetBinding()
		{
			return _source;
		}
	}
}
