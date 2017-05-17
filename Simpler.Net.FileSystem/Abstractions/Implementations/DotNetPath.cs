using System;
using System.IO;

namespace Simpler.Net.FileSystem.Abstractions.Implementations
{
	/// <inheritdoc />
	public class DotNetPath : IPath
	{
		/// <inheritdoc />
		public String GetTempFileName() => Path.GetTempFileName();
	}
}