using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Simpler.Net
{
	/// <summary>
	/// Miscellaneous helpful extension methods.
	/// </summary>
	public static class SimplerExtensions
	{
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

		/// <summary>
		/// Convert fields and properties of an object to a flat dictionary of <see cref="String"/>
		/// keys and values. Source: http://geeklearning.io/serialize-an-object-to-an-url-encoded-string-in-csharp/
		/// </summary>
		/// <remarks>
		///	Uses JSON.NET serialization for key names and string values, thus key values are serialized
		/// in a web-friendly "parent.child[arrayIndex]=value" format.
		/// </remarks>
		/// <param name="obj">Object to serialize</param>
		/// <param name="recursively">Also include child objects?</param>
		/// <returns></returns>
		public static IDictionary<String, String> ToStringDictionary(this Object obj, Boolean recursively = true)
		{
			if (obj == null)
				return null;

			if (!(obj is JToken token))
			{
				return ToStringDictionary(JObject.FromObject(obj));
			}

			if (token.HasValues)
			{
				var contentData = new Dictionary<String, String>();
				foreach (JToken child in token.Children().ToList())
				{
					var childContent = child.ToStringDictionary();
					if (childContent != null)
					{
						contentData = contentData.Concat(childContent)
							.ToDictionary(k => k.Key, v => v.Value);
					}
				}

				return contentData;
			}

			var jValue = token as JValue;
			if (jValue?.Value == null)
			{
				return null;
			}

			var value = jValue.Type == JTokenType.Date ?
				jValue.ToString("o", CultureInfo.InvariantCulture) :
				jValue.ToString(CultureInfo.InvariantCulture);

			return new Dictionary<String, String> { { token.Path, value } };
		}
	}
}