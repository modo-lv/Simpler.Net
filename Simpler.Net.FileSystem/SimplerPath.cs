using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Simpler.Net.FileSystem
{
    /// <summary>
    /// Functions and methods that work with file & folder paths.
    /// </summary>
    public class SimplerPath
    {
        /// <summary>
        /// Combines parts of a path into a single path.
        /// Works the same as <see cref="Path.Combine(String, String)"/>,
        /// with one fix: if a path part starts with a [back]slash, it will
        /// *not* be returned as the root path, discarding the previous parts.
        /// However, if a path part starts with a drive letter ("C:"), it
        /// *will* be returned as the root path and any paths before it will
        /// be discarded.
        /// 
        /// This method also trims any multiple slashes/backslashes to a single one.
        /// 
        /// Also, this method takes any number of parts, instead of just up to 4.
        /// </summary>
        /// <param name="pathParts">Parts of the path to combine. For example, "c:\\X", "\\ABC\\", "def\\"</param>
        /// <returns>Combined path. For example, @"C:\X\ABC\def\"</returns>
        public static String Combine(IEnumerable<String> pathParts)
        {
            return !pathParts.Any()
                ? String.Empty
                : pathParts.Select(
                    p => {
                        p = Clean(p);
                        // Drive letter
                        if (Regex.Match(p, @"^[a-z]:$", RegexOptions.IgnoreCase).Success)
                            return p + Path.DirectorySeparatorChar;
                        return p;
                    }).Aggregate(Path.Combine);
        }

        /// <summary>
        /// Syntactic sugar for splitting a path into its constituent parts.
        /// </summary>
        /// <param name="path">Path to split.</param>
        /// <returns>A list of parts making up the path.</returns>
        public static IList<String> Split(String path)
        {
            return
                path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                    .Select(Trim)
                    .Where(p => !String.IsNullOrWhiteSpace(p)) // Remove empty elements
                    .ToList();
        }

        /// <summary>
        /// Trim directory separator characters off a path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static String Trim(String path)
        {
            return path.Trim(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }

        /// <summary>
        /// Trim and remove duplicate separator characters from a path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static String Clean(String path)
        {
            var sep = "" + Path.DirectorySeparatorChar + Path.DirectorySeparatorChar;
            var altSep = "" + Path.AltDirectorySeparatorChar + Path.AltDirectorySeparatorChar;

            while (path.Contains(sep))
                path = path.Replace(sep, Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture));

            while (path.Contains(altSep))
                path = path.Replace(altSep, Path.AltDirectorySeparatorChar.ToString(CultureInfo.InvariantCulture));

            return Trim(path);
        }

        /// <summary>
        /// Separate the last part of a path (file or folder name) from
        /// a given path and return it along with the remaining path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Value1 is path, </returns>
        public static PathAndName SplitPathAndName(String path)
        {
            var parts = Split(path);
            if (!parts.Any())
                throw new Exception("Cannot split an empty path!");
            var name = parts.Last();
            parts.RemoveAt(parts.Count - 1);
            return new PathAndName {
                Path = Combine(parts),
                Name = name
            };
        }
    }
}
