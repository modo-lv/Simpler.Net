using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Simpler.Net.FileSystem.Abstractions;
using Simpler.Net.Text;

namespace Simpler.Net.FileSystem
{
	/// <summary>
	/// Functions and methods that work with file and folder paths.
	/// </summary>
	public class SimplerPath
	{

		/// <summary>
		/// Combine parts of a path into a single path.
		/// </summary>
		/// <remarks>
		/// All separators are replaced by <paramref name="separator"/> and duplicates removed.
		/// Unlike <see cref="Path.Combine(String,String)"/> and its overloads, this method makes
		/// no validity checks and treats Windows drive letters like any other path (i.e.,
		/// <c>@"C:"</c> and <c>@"d"</c> will combine to <c>@"C:\d"</c>, not <c>@"C:d"</c>).
		/// </remarks>
		/// <param name="pathParts">Paths to combine.</param>
		/// <param name="separator">Separator to use. If <c>null</c>, OS default will be used.</param>
		/// <returns>Combined path.</returns>
		public static String Combine(IEnumerable<String> pathParts, String separator = null)
		{
			// ReSharper disable once SuggestVarOrType_Elsewhere
			var array = pathParts as String[] ?? pathParts.IfNotNull(pp => pp.ToArray());
			if (array == null || !array.Any())
				return String.Empty;

			separator = separator ?? Path.DirectorySeparatorChar.ToString();

			var result = String.Join(separator, array);

			result = SimplerPath.Clean(result, separator);

			return result;
		}


		/// <summary>
		/// An overload for <see cref="Combine(IEnumerable{String},String)"/> that allows
		/// for passing path parts as arguments instead of an <see cref="IEnumerable{T}"/>.
		/// </summary>
		/// <param name="pathParts"></param>
		/// <returns></returns>
		public static String Combine(params String[] pathParts)
			=> Combine((IEnumerable<String>) pathParts);


		/// <summary>
		/// Syntactic sugar for splitting a path into its constituent parts.
		/// </summary>
		/// <param name="path">Path to split.</param>
		/// <param name="separators">Separators to use. If <c>null</c>, UNIX and Windows defaults
		///   (slash and backslash) will be used.</param>
		/// <returns>A list of parts making up the path.</returns>
		public static String[] Split(String path, IEnumerable<String> separators = null)
		{
			if (separators == null) {
				separators = new[] {
					Path.DirectorySeparatorChar.ToString(),
					Path.AltDirectorySeparatorChar.ToString()
				};
			}

			return path.Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries);
		}


		/// <summary>
		/// Syntactic sugar for trimming path separators from the beginning and/or end of a path.
		/// </summary>
		/// <param name="path">Path to trim separators off of.</param>
		/// <param name="trimMode"><see cref="SimplerTrimMode"/>.</param>
		/// <param name="separators">Separators to trim. If <c>null</c>, default Windows and UNIX separators will be trimmed.</param>
		/// <returns></returns>
		public static String Trim(String path, SimplerTrimMode trimMode = SimplerTrimMode.End, IEnumerable<Char> separators = null)
		{
			if (separators == null) {
				separators = new[] {Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar};
			}
			return path.SimplerTrim(trimMode, separators);
		}

		/// <summary>
		/// Remove duplicate separator characters from a path.
		/// </summary>
		/// <param name="path"></param>
		/// <param name="separator"></param>
		/// <returns></returns>
		public static String Clean(String path, String separator = null)
		{
			if (separator == null) {
				separator = $"{Path.DirectorySeparatorChar}";
			}

			var result = Regex.Replace(path, @"(?:/|\\)+", separator, RegexOptions.Compiled);

			return result;
		}

		/// <summary>
		/// Separate the last part of a path (file or folder name) from
		/// a given path and return it along with the remaining path.
		/// </summary>
		/// <param name="path"></param>
		/// <returns>Value1 is path, </returns>
		public static PathAndName SplitPathAndName(String path)
		{
			var parts = Split(path).ToList();
			if (!parts.Any())
				throw new Exception("Cannot split an empty path!");
			var name = parts.Last();
			parts.RemoveAt(parts.Count - 1);
			return new PathAndName
			{
				Path = Combine(parts),
				Name = name
			};
		}
	}
}