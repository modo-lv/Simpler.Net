namespace Simpler.Net.FileSystem.Abstractions
{
	/// <summary>
	/// Contains all abstracted file system objects.
	/// </summary>
	public interface IFileSystem
	{
		/// <inheritdoc cref="IDirectory"/>
		IDirectory Directory { get; set; }

		/// <inheritdoc cref="IFile" />
		IFile File { get; set; }
	}
}
