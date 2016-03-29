using System;

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
		public static TResult IfNotNull<TObject, TResult>(this TObject obj,
			Func<TObject, TResult> func,
			TResult otherwise = default(TResult))
		{
			return obj != null ? func(obj) : otherwise;
		}
	}
}
