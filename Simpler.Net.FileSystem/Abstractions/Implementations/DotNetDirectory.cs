using System;
using System.IO;

namespace Simpler.Net.FileSystem.Abstractions.Implementations
{
	/// <inheritdoc />
	public class DotNetDirectory : IDirectory
	{
		/// <inheritdoc />
		public DirectoryInfo CreateDirectory(String path) => Directory.CreateDirectory(path);

		/// <inheritdoc />
		public String GetCurrentDirectory() => Directory.GetCurrentDirectory();
	}
}