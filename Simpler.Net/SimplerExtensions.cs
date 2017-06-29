using System;
using System.Collections.Generic;

namespace Simpler.Net
{
	/// <summary>
	/// Miscellaneous helpful extension methods.
	/// </summary>
	public static class SimplerExtensions
	{
		/// <summary>
		/// Execute a function with an object if that object is not null.
		/// </summary>
		/// <param name="obj">Object to exectue the function on.</param>
		/// <param name="func">Fuction to execute on the object.</param>
		/// <param name="otherwise">Default value to return if the object is null.</param>
		/// <typeparam name="TObject">Type of object to check.</typeparam>
		/// <typeparam name="TResult">Type of the function result / default value.</typeparam>
		/// <returns>Result of function if object was not null, otherwise the default value of TResult.</returns>
		public static TResult IfNotNull<TObject, TResult>(
			this TObject obj,
			Func<TObject, TResult> func,
			TResult otherwise = default(TResult))
		{
			return obj != null ? func(obj) : otherwise;
		}


		/// <summary>
		/// Syntactic sugar wrapping around <see cref="IDictionary{TKey,TValue}"/> accessor
		/// allowing to provide a fallback value in case the supplied key is not found in the
		/// dictionary.
		/// </summary>
		/// <typeparam name="TKey">Dictionary key type.</typeparam>
		/// <typeparam name="TValue">Dictionary value type.</typeparam>
		/// <param name="dictionary">Dictionary to get value from.</param>
		/// <param name="key">Key for finding the value.</param>
		/// <param name="fallback">Value to return if the key is not found.</param>
		/// <returns>Found value or <paramref name="fallback"/>.</returns>
		public static TValue Get<TKey, TValue>(
			this IDictionary<TKey, TValue> dictionary,
			TKey key,
			TValue fallback = default(TValue))
		{
			if (dictionary.ContainsKey(key))
				return dictionary[key];
			return fallback;
		}
	}
}