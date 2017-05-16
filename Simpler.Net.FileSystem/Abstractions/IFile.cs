using System;
using System.IO;

namespace Simpler.Net.FileSystem.Abstractions
{
	/// <inheritdoc cref="File"/>
	public interface IFile
	{
		/// <inheritdoc cref="File.Exists"/>
		Boolean Exists(String path);

		/// <inheritdoc cref="File.ReadAllText(string)" />
		String ReadAllText(String path);

		/// <inheritdoc cref="File.WriteAllText(string,string)" />
		void WriteAllText(String path, String contents);
	}
}
