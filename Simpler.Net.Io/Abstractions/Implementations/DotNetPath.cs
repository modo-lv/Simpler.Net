using System;
using System.IO;

namespace Simpler.Net.Io.Abstractions.Implementations
{
	/// <inheritdoc />
	public class DotNetPath : IPath
	{
		/// <inheritdoc />
		public String GetTempFileName() => Path.GetTempFileName();
		
		/// <inheritdoc />
		public String GetTempPath() => Path.GetTempPath();

		/// <inheritdoc />
		public String GetDirectoryName(String path) => Path.GetDirectoryName(path);
	}
}