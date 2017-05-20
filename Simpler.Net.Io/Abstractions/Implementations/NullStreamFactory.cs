using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace Simpler.Net.Io.Abstractions.Implementations
{
	/// <inheritdoc />
	public class NullStreamFactory : IStreamFactory
	{
		/// <inheritdoc />
		public Stream GetFileStream(SafeFileHandle handle, FileAccess access)
			=> Stream.Null;

		/// <inheritdoc />
		public Stream GetFileStream(SafeFileHandle handle, FileAccess access, Int32 bufferSize)
			=> Stream.Null;

		/// <inheritdoc />
		public Stream GetFileStream(
			SafeFileHandle handle,
			FileAccess access,
			Int32 bufferSize,
			Boolean isAsync)
			=> Stream.Null;

		/// <inheritdoc />
		public Stream GetFileStream(String path, FileMode mode)
			=> Stream.Null;

		/// <inheritdoc />
		public Stream GetFileStream(String path, FileMode mode, FileAccess access)
			=> Stream.Null;

		/// <inheritdoc />
		public Stream GetFileStream(String path, FileMode mode, FileAccess access, FileShare share)
			=> Stream.Null;

		/// <inheritdoc />
		public Stream GetFileStream(
			String path,
			FileMode mode,
			FileAccess access,
			FileShare share,
			Int32 bufferSize)
			=> Stream.Null;

		/// <inheritdoc />
		public Stream GetFileStream(
			String path,
			FileMode mode,
			FileAccess access,
			FileShare share,
			Int32 bufferSize,
			Boolean useAsync)
			=> Stream.Null;

		/// <inheritdoc />
		public Stream GetFileStream(
			String path,
			FileMode mode,
			FileAccess access,
			FileShare share,
			Int32 bufferSize,
			FileOptions options)
			=> Stream.Null;
	}
}