using System;

namespace Simpler.Net.Io.Abstractions.Implementations
{
	/// <inheritdoc />
	public class NullPath : IPath
	{
		/// <inheritdoc />
		public String GetTempFileName() => null;

		/// <inheritdoc />
		public String GetTempPath() => null;
	}
}