using System;

namespace Emgu_Test
{
	class LoggerEventArgs : EventArgs
	{
		public string Message { get; set; }
		public Level LogLevel { get; set; }
	}
}
