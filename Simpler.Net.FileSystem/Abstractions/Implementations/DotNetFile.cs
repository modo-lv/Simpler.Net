using System;
using System.IO;

namespace Simpler.Net.FileSystem.Abstractions.Implementations
{
	/// <summary>
	/// Default implementation for <see cref="IFile"/>, using .NET's <see cref="File"/> methods.
	/// </summary>
	public class DotNetFile : IFile
	{
		/// <inheritdoc />
		public Boolean Exists(String path) => File.Exists(path);

		/// <inheritdoc />
		public String ReadAllText(String path) => File.ReadAllText(path);

		/// <inheritdoc />
		public void WriteAllText(String path, String contents) => File.WriteAllText(path, contents);
	}
}