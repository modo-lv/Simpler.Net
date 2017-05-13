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
		/// Add a view model property's generated HTML-form name to an HTML tag.
		/// </summary>
		/// <typeparam name="TModel">Model type</typeparam>
		/// <typeparam name="TResult">Model property type</typeparam>
		/// <param name="tag">HTML tag to set the name on</param>
		/// <param name="helper">HTML helper for determining the name.</param>
		/// <param name="expression">Expression containing the property.</param>
		/// <returns>Modified HTML tag.</returns>
		public static SimplerHtmlTag AddNameFor<TModel, TResult>(
			this SimplerHtmlTag tag,
			IHtmlHelper<TModel> helper,
			Expression<Func<TModel, TResult>> expression)
		{
			var name = helper.NameFor(expression);
			tag.SetAttribute("name", name);
			return tag;
		}

		/// <summary>
		/// Same as <see cref="AddNameFor{TModel,TResult}"/>, but for "id" attribute instead of "name".
		/// </summary>
		public static SimplerHtmlTag AddIdFor<TModel, TResult>(
			this SimplerHtmlTag tag,
			IHtmlHelper<TModel> helper,
			Expression<Func<TModel, TResult>> expression)
		{
			var name = helper.IdFor(expression);
			tag.SetAttribute("id", name);
			return tag;
		}

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
				.AddNameFor(helper, expression)
				.AddIdFor(helper, expression);

			return tag;
		}
	}
}