using System;
using System.Collections.Generic;
using System.Text;

namespace Simpler.Net.FileSystem.Abstractions.Implementations
{
	/// <inheritdoc />
	public class NullPath : IPath
	{
		/// <inheritdoc />
		public String GetTempFileName() => null;
	}
}