using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	[DefaultPropertyAttribute("E131Settings")]
	[Serializable]
	[XmlRoot("E131Settings")]
	public class E131Settings
    {
		private string m_ip_address = "192.168.1.102";
		private int m_light_count = 50;
		private ushort m_universe = 1;
		private int m_start_channel = 1;
		private byte m_brightness = 127;

		[CategoryAttribute("E131 Settings"), DescriptionAttribute("E131 IP Address")]
		public string IPAddress
		{
			get
			{
				return m_ip_address;
			}
			set
			{
				m_ip_address = value;
			}
		}

		[CategoryAttribute("E131 Settings"), DescriptionAttribute("Number of RGB Lights")]
		public int LightCount
		{
			get
			{
				return m_light_count;
			}
			set
			{
				m_light_count = value;
			}
		}

		[CategoryAttribute("E131 Settings"), DescriptionAttribute("Start Universe")]
		public ushort Universe
		{
			get
			{
				return m_universe;
			}
			set
			{
				m_universe = value;
			}
		}

		[CategoryAttribute("E131 Settings"), DescriptionAttribute("Start Cannel")]
		public int StartUniverse
		{
			get
			{
				return m_start_channel;
			}
			set
			{
				m_start_channel = value;
			}
		}

		[CategoryAttribute("E131 Settings"), DescriptionAttribute("Brightness")]
		public byte Brightness
		{
			get
			{
				return m_brightness;
			}
			set
			{
				m_brightness = value;
			}
		}
	}
}
