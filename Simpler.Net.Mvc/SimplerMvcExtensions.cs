using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Simpler.Net.Html;

namespace Simpler.Net.Mvc
{
	/// <summary>
	/// Misc. extension methods for simplifying work with HTML in MVC views.
	/// </summary>
	public static class SimplerMvcHtmlExtensions
	{
		/// <summary>
		/// Same as
		/// <see cref="HtmlHelperInputExtensions.TextBoxFor{TModel,TResult}(IHtmlHelper{TModel},Expression{Func{TModel,TResult}})"/>,
		/// but returns a <see cref="SimplerHtmlTag"/> that can be further modified and processed before outputting.
		/// </summary>
		public static SimplerHtmlTag SimplerTextBoxFor<TModel, TResult>(
			this IHtmlHelper<TModel> helper,
			Expression<Func<TModel, TResult>> expression)
		{
			// ReSharper disable once SuggestVarOrType_SimpleTypes
			var tag = new SimplerHtmlTag("input")
				.SetAttribute("type", "text")
				.SetAttribute("name", helper.NameFor(expression))
				.SetAttribute("id", helper.IdFor(expression))
				.SetAttribute("value", helper.ValueFor(expression))
				;

			return tag;
		}
	}
}