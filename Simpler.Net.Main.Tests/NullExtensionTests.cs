using Simpler.Net.Main;

namespace Simpler.Net.Tests;

public class NullExtensionTests {
  [TestCase(null, "fallback", TestName = "Null input produces fallback", ExpectedResult = "fallback")]
  [TestCase(123, "321", TestName = "Non-null input produces input as string", ExpectedResult = "123")]
  public String ToStringOr(Object? input, String fallback) {
    return input.ToStringOr(fallback);
  }

  [TestCase(null, TestName = "Null input produces empty string", ExpectedResult = "")]
  [TestCase(123, TestName = "Non-null input produces input as string", ExpectedResult = "123")]
  public String ToStringOrEmpty(Object? input) {
    return input.ToStringOrEmpty();
  }

}