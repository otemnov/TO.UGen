using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace TO.UGen.Tests
{

	public class CommonGuidGeneratorTests
	{
		[Theory]
		[MemberData(nameof(Generators))]
		public void NewGuidNotEmpty(IGuidGenerator generator)
		{
			generator.NewGuid().Should().NotBeEmpty();
		}

		[Theory]
		[MemberData(nameof(Generators))]
		public void NewGuidNoDuplicates(IGuidGenerator generator)
		{
			generator.NewGuid().Should().NotBe(generator.NewGuid());
		}

		public static readonly IEnumerable<object[]> Generators = new[]
		{
			new object[] { new SqlCombGuidGenerator() }, 
			new object[] { new SimpleGuidGenerator() }
		};
	}
}
