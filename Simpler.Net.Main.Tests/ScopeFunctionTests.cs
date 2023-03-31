using FluentAssertions;
using Simpler.Net.Main;

namespace Simpler.Net.Tests;

public class ScopeFunctionTests {
  [Test]
  public void Let() {
    "Original"
      .Let(it => it.Replace("Original", "Replaced"))
      .Should().Be("Replaced");
  }

  [Test]
  public void Also() {
    var result = "";
    
    "Original"
      .Also(it => result = it.Replace("Original", "Replaced"))
      .Should().Be("Original");
    result.Should().Be("Replaced");
  }
}