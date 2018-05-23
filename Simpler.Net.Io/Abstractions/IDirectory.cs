using System;
using System.IO;

namespace Simpler.Net.Io.Abstractions
{
	/// <summary>Methods for creating, moving, and enumerating through directories and subdirectories.</summary>
	public interface IDirectory
	{
		/// <inheritdoc cref="Directory.CreateDirectory" />
		DirectoryInfo CreateDirectory(String path);

		/// <inheritdoc cref="Directory.GetCurrentDirectory"/>
		String GetCurrentDirectory();

		/// <inheritdoc cref="Directory.Exists" />
		Boolean Exists(String path);
	}
}