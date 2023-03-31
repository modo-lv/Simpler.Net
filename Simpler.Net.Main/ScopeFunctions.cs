using System;

namespace Simpler.Net.Main;

/// <summary>
/// Provides scope extension methods similar to Kotlin's `let`, `run`, etc.
/// </summary>
public static class ScopeFunctions {
  /// <summary>
  /// Perform an action on the context object, and return the object.
  /// </summary>
  /// <remarks>
  /// A C# implementation of Kotlin's
  /// <a href="https://kotlinlang.org/docs/scope-functions.html#also"><c>also()</c></a>
  /// context function.
  /// </remarks>
  /// <param name="it">Context object.</param>
  /// <param name="a">Action to perform.</param>
  /// <typeparam name="TIt">Context object type.</typeparam>
  /// <returns>Context object.</returns>
  public static TIt Also<TIt>(this TIt it, Action<TIt> a) {
    a(it);
    return it;
  }
  
  /// <summary>
  /// Invoke a function with the context object as the argument, and return the result.
  /// </summary>
  /// <remarks>
  /// A C# implementation of Kotlin's
  /// <a href="https://kotlinlang.org/docs/scope-functions.html#let"><c>let()</c></a>
  /// context function.
  /// </remarks>
  /// <param name="it">Context object.</param>
  /// <param name="f">Function to invoke.</param>
  /// <typeparam name="TIt">Context object type.</typeparam>
  /// <typeparam name="TResult">Result type.</typeparam>
  /// <returns>Result of invoking <paramref name="f"/> with <paramref name="it"/> as the argument.</returns>
  public static TResult Let<TIt, TResult>(this TIt it, Func<TIt, TResult> f) {
    return f(it);
  }
}