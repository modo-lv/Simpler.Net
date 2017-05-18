namespace Simpler.Net.Io.Abstractions.Implementations
{
	/// <summary>
	/// Overrideable zero-function base class, meant for creating test and other custom 
	/// implementations of <see cref="IFileSystem"/>.
	/// </summary>
	public class NullFileSystem : IFileSystem
	{
		/// <inheritdoc />
		public virtual IDirectory Directory { get; set; }

		/// <inheritdoc />
		public IFile File { get; set; }

		/// <inheritdoc />
		public IPath Path { get; set; }

		/// <inheritdoc cref="NullFileSystem"/>
		public NullFileSystem()
		{
			this.Directory = new NullDirectory();
			this.File = new NullFile();
			this.Path = new NullPath();
		}
	}
}