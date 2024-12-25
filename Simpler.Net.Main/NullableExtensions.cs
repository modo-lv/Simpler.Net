using System;

namespace Simpler.Net.Main;

public static class NullExtensions {
  /// <summary>
  /// Return a value's <see cref="string"/> representation, or a fallback if the value is <c>null</c>.
  /// </summary>
  /// <remarks>
  /// A fluent alternative to <code>value?.ToString() ?? fallback;</code>
  /// </remarks>
  /// <param name="value">Value to call <c>.ToString()</c> on.</param>
  /// <param name="fallback">Fallback value to return if <paramref name="value"/> is <c>null</c>.</param>
  /// <returns>String representation of <paramref name="value"/> or <paramref name="fallback"/>.</returns>
  public static String ToStringOr(this Object? value, String fallback = "") {
    return value?.ToString() ?? fallback;
  }

  /// <summary>
  /// Return a value's <see cref="String"/> representation, or an empty string if the value is <c>null</c>.
  /// </summary>
  /// <remarks>
  /// A fluent alternative to <code>value?.ToString() ?? String.Empty;</code>
  /// </remarks>
  /// <param name="value">Value to call <c>.ToString()</c> on.</param>
  /// <returns>String representation of <paramref name="value"/> or <see cref="string.Empty"/>.</returns>
  public static String ToStringOrEmpty(this Object? value) =>
    ToStringOr(value, String.Empty);
}