namespace Simpler.Net.FileSystem.Abstractions.Implementations
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

		/// <inheritdoc cref="DotNetFileSystem"/>
		public DotNetFileSystem()
		{
			this.Directory = new DotNetDirectory();
			this.File = new DotNetFile();
		}
	}
}