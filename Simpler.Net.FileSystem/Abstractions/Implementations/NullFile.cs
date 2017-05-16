using System;

namespace Simpler.Net.FileSystem.Abstractions.Implementations
{
	/// <summary>
	/// Base class for creating test or other custom, partially functioning implementations of <see cref="IFile"/>.
	/// </summary>
	public class NullFile : IFile
	{
		/// <inheritdoc />
		public virtual Boolean Exists(String path) => true;

		/// <inheritdoc />
		public String ReadAllText(String path) => null;

		/// <inheritdoc />
		public void WriteAllText(String path, String contents) { }
	}
}
