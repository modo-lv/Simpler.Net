using System;
using System.IO;

namespace Simpler.Net.Io.Abstractions
{
	/// <inheritdoc cref="Path"/>
	public interface IPath
	{
		/// <inheritdoc cref="Path.GetTempFileName"/>
		String GetTempFileName();
	}
}
