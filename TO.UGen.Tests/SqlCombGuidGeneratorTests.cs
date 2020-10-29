using System.Data.SqlTypes;
using System.Linq;
using System.Threading;
using FluentAssertions;
using Xunit;

namespace TO.UGen.Tests
{
	public class SqlCombGuidGeneratorTests
	{
		[Fact]
		public void CreateNewNotEmpty()
		{
			var generator = new SqlCombGuidGenerator();
			generator.CreateNew().Should().NotBeEmpty();
		}

		[Fact]
		public void CreateNewNoDuplicates()
		{
			var generator = new SqlCombGuidGenerator();
			generator.CreateNew().Should().NotBe(generator.CreateNew());
		}

		[Fact]
		public void CreateInSqlOrder()
		{
			var generator = new SqlCombGuidGenerator();
			var raw = Enumerable.Range(0, 100).Select(x =>
			{
				//need sleep ms to distribute ids by time, as we keep milliseconds data only
				Thread.Sleep(1);
				return generator.CreateNew();
			}).ToList();

			var sql = raw.Select(x => new SqlGuid(x)).ToList();
			
			sql.Sort();
			
			sql.Select(x => x.Value).Should().Equal(raw);
		}
	}
}
