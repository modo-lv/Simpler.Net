using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simpler.Net.Text {
	/// <summary>
	/// Extension methods for <see cref="String"/>s.
	/// </summary>
	public static class TextExtensions {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		/// <param name="mode"></param>
		/// <param name="chars"></param>
		/// <returns></returns>
		public static String SimplerTrim(
			this String text,
			SimplerTrimMode mode = SimplerTrimMode.Both,
			IEnumerable<Char> chars = null)
		{
			if (chars == null)
				chars = new Char[0];

			var ca = chars.ToArray();

			switch (mode) {
				case SimplerTrimMode.Start:
					return text.TrimStart(ca);
				case SimplerTrimMode.End:
					return text.TrimEnd(ca);
				default:
					return text.Trim(ca);
			}
		}

		/// <summary>
		/// Repeat a given <see cref="String"/> a number of times.
		/// </summary>
		/// <param name="text">Text to repeat.</param>
		/// <param name="times">Number of times to repeat.</param>
		/// <returns>Resulting repeated text.</returns>
		public static String Repeat(this String text, Int32 times)
		{
			if (times < 1)
				return "";
			var sb = new StringBuilder();
			for (var a = 0; a < times; a++)
				sb.Append(text);
			return sb.ToString();
		}

		/// <summary>
		/// Syntactic sugar for creating a string consisting of a sequence
		/// of the same character.
		/// </summary>
		/// <param name="chr"></param>
		/// <param name="times"></param>
		/// <returns></returns>
		public static String Repeat(this Char chr, Int32 times)
		{
			return new String(chr, times);
		}

		/// <summary>
		/// Duplicate a given <see cref="String"/> a number of times.
		/// </summary>
		/// <param name="text"></param>
		/// <param name="count">How many copies are needed.</param>
		/// <returns></returns>
		public static IEnumerable<String> Duplicate(this String text, Int32 count)
		{
			for (var a = 0; a < count; a++)
				yield return text;
		}

		/// <summary>
		/// Pad a given string.
		/// </summary>
		/// <param name="text"></param>
		/// <param name="length"></param>
		/// <param name="alignment"></param>
		/// <param name="chr"></param>
		/// <returns></returns>
		public static String Pad(
			this String text,
			Int32 length,
			SimplerTextAlignment alignment = SimplerTextAlignment.Right,
			String chr = null)
		{
			return new SimplerTextPadder(text, chr) {
				Length = length,
				TextAlignment = alignment
			}.GetPadded();
		}
	}
}