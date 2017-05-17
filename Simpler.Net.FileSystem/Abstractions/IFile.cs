using System;
using System.IO;

namespace Simpler.Net.FileSystem.Abstractions
{
	/// <inheritdoc cref="File"/>
	public interface IFile
	{
		/// <inheritdoc cref="File.Exists"/>
		Boolean Exists(String path);

		/// <inheritdoc cref="File.ReadAllText(string)" />
		String ReadAllText(String path);

		/// <inheritdoc cref="File.WriteAllText(string,string)" />
		void WriteAllText(String path, String contents);

		/// <inheritdoc cref="File.Copy(string,string)"/>
		void Copy(String sourceFileName, String destFileName);

		/// <inheritdoc cref="File.Copy(string,string,bool)"/>
		void Copy(String sourceFileName, String destFileName, Boolean overwrite);

		/// <inheritdoc cref="File.Move"/>
		void Move(String sourceFileName, String destFileName);

		/// <inheritdoc cref="File.Delete"/>
		void Delete(String path);
	}
}
