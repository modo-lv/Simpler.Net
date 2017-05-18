using System;
using System.IO;

namespace Simpler.Net.Io.Abstractions.Implementations
{
	/// <summary>
	/// Base class for creating test and other custom <see cref="Stream"/>s.
	/// </summary>
	public class NullStream : Stream
	{
		/// <inheritdoc />
		public override void Flush() { }

		/// <inheritdoc />
		public override Int32 Read(Byte[] buffer, Int32 offset, Int32 count) => 0;

		/// <inheritdoc />
		public override Int64 Seek(Int64 offset, SeekOrigin origin) => 0;

		/// <inheritdoc />
		public override void SetLength(Int64 value) { }

		/// <inheritdoc />
		public override void Write(Byte[] buffer, Int32 offset, Int32 count) { }

		/// <inheritdoc />
		public override Boolean CanRead => true;

		/// <inheritdoc />
		public override Boolean CanSeek => true;

		/// <inheritdoc />
		public override Boolean CanWrite => true;

		/// <inheritdoc />
		public override Int64 Length => 0;

		/// <inheritdoc />
		public override Int64 Position
		{
			get => 0;
			set { }
		}
	}
}