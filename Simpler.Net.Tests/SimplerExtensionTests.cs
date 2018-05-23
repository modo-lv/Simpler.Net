using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Simpler.Net.Tests
{
    public class SimplerExtensionTests
    {
        [Fact]
        public void ToStringDictionary()
        {
					// ARRANGE
	        var obj = new
	        {
		        Id = Guid.NewGuid(),
		        String = "Title",              
		        GuidList = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() },                
		        Index = 1,                
		        Byte = 10,                
		        Date = DateTime.Parse("08-02-2016"),                
		        Foo1 = new { Str = "str", Ints = new List<Int32> { 0, 1, 2, 3 } },
		        Fooes = new [] { new { Foo = "Foo1" }, new { Foo = "Foo2" } }
	        };

					// ACT
	        var result = obj.ToStringDictionary();

					// ASSERT
	        result.Should()
		        .ContainKeys(
			        "Id",
			        "String",
			        "GuidList[0]",
			        "GuidList[1]",
			        "Index",
			        "Byte",
			        "Date",
			        "Foo1.Str",
			        "Foo1.Ints[0]",
			        "Foo1.Ints[1]",
			        "Foo1.Ints[2]",
			        "Foo1.Ints[3]",
			        "Fooes[0].Foo",
			        "Fooes[1].Foo");
        }
    }
}
