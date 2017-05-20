using System;
using System.IO;
using Microsoft.Win32.SafeHandles;

namespace Simpler.Net.Io.Abstractions.Implementations
{
	/// <inheritdoc />
	public class DotNetStreamFactory : IStreamFactory
	{
		/// <inheritdoc />
		public virtual Stream GetFileStream(SafeFileHandle handle, FileAccess access) => new FileStream(
			handle,
			access);

		/// <inheritdoc />
		public virtual Stream GetFileStream(
			SafeFileHandle handle,
			FileAccess access,
			Int32 bufferSize) => new FileStream(handle, access, bufferSize);

		/// <inheritdoc />
		public virtual Stream GetFileStream(
			SafeFileHandle handle,
			FileAccess access,
			Int32 bufferSize,
			Boolean isAsync) => new FileStream(handle, access, bufferSize, isAsync);

		/// <inheritdoc />
		public virtual Stream GetFileStream(String path, FileMode mode) => new FileStream(path, mode);

		/// <inheritdoc />
		public virtual Stream GetFileStream(
			String path,
			FileMode mode,
			FileAccess access) => new FileStream(
			path,
			mode,
			access);

		/// <inheritdoc />
		public virtual Stream GetFileStream(
			String path,
			FileMode mode,
			FileAccess access,
			FileShare share) => new FileStream(path, mode, access, share);

		/// <inheritdoc />
		public virtual Stream GetFileStream(
			String path,
			FileMode mode,
			FileAccess access,
			FileShare share,
			Int32 bufferSize) => new FileStream(path, mode, access, share, bufferSize);

		/// <inheritdoc />
		public virtual Stream GetFileStream(
			String path,
			FileMode mode,
			FileAccess access,
			FileShare share,
			Int32 bufferSize,
			Boolean useAsync) => new FileStream(path, mode, access, share, bufferSize, useAsync);

		/// <inheritdoc />
		public virtual Stream GetFileStream(
			String path,
			FileMode mode,
			FileAccess access,
			FileShare share,
			Int32 bufferSize,
			FileOptions options) => new FileStream(path, mode, access, share, bufferSize, options);
	}
}