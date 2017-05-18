namespace Simpler.Net.Io.Abstractions.Implementations
{
	/// <summary>
	/// Implementation of <see cref="IFileSystem"/> interface, using .NET's System.IO static classes.
	/// </summary>
	public class DotNetFileSystem : IFileSystem
	{
		/// <inheritdoc />
		public IDirectory Directory { get; set; }

		/// <inheritdoc />
		public IFile File { get; set; }

		/// <inheritdoc />
		public IPath Path { get; set; }

		/// <inheritdoc cref="DotNetFileSystem"/>
		public DotNetFileSystem()
		{
			this.Directory = new DotNetDirectory();
			this.File = new DotNetFile();
			this.Path = new DotNetPath();
		}
	}
}