using FluentAssertions;
using Xunit;

namespace TO.UGen.Tests
{
	public class SimpleGuidGeneratorTests
	{
		[Fact]
		public void CreateNewNotEmpty()
		{
			var generator = new SimpleGuidGenerator();
			generator.CreateNew().Should().NotBeEmpty();
		}

		[Fact]
		public void CreateNewNoDuplicates()
		{
			var generator = new SimpleGuidGenerator();
			generator.CreateNew().Should().NotBe(generator.CreateNew());
		}
	}
}
