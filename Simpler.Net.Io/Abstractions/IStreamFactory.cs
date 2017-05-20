using System;
using System.IO;
using Microsoft.Win32.SafeHandles;

namespace Simpler.Net.Io.Abstractions
{
	/// <summary>
	/// Factory providing streams.
	/// </summary>
	public interface IStreamFactory
	{
		///<inheritdoc cref="FileStream"/>
		Stream GetFileStream(SafeFileHandle handle, FileAccess access);

		///<inheritdoc cref="FileStream"/>
		Stream GetFileStream(SafeFileHandle handle, FileAccess access, Int32 bufferSize);

		///<inheritdoc cref="FileStream"/>
		Stream GetFileStream(SafeFileHandle handle, FileAccess access, Int32 bufferSize, Boolean isAsync);

		///<inheritdoc cref="FileStream"/>
		Stream GetFileStream(String path, FileMode mode);

		///<inheritdoc cref="FileStream"/>
		Stream GetFileStream(String path, FileMode mode, FileAccess access);

		///<inheritdoc cref="FileStream"/>
		Stream GetFileStream(String path, FileMode mode, FileAccess access, FileShare share);

		///<inheritdoc cref="FileStream"/>
		Stream GetFileStream(String path, FileMode mode, FileAccess access, FileShare share, Int32 bufferSize);

		///<inheritdoc cref="FileStream"/>
		Stream GetFileStream(
			String path,
			FileMode mode,
			FileAccess access,
			FileShare share,
			Int32 bufferSize,
			Boolean useAsync);

		///<inheritdoc cref="FileStream"/>
		Stream GetFileStream(
			String path,
			FileMode mode,
			FileAccess access,
			FileShare share,
			Int32 bufferSize,
			FileOptions options);

	}
}