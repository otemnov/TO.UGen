using System;
using FluentAssertions;
using Xunit;

namespace TO.UGen.Tests
{
	public class UnixDateTimeConverterTests	
	{
		[Fact]
		public void ConvertViceVersa()
		{
			var date = new DateTime(1984, 8, 21, 0, 0, 0, DateTimeKind.Utc);
			var converter = new UnixDateTimeConverter();
			converter.ToUtcDateTime(converter.ToBytes(date)).Should().Be(date);
		}

		[Fact]
		public void ConvertInUtc()
		{
			var bd = new DateTime(1984, 8, 21, 0, 0, 0, DateTimeKind.Unspecified);
			var bdByTokyo = TimeZoneInfo.ConvertTime(bd, TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time"));
			var converter = new UnixDateTimeConverter();

			converter.ToUtcDateTime(converter.ToBytes(bdByTokyo)).Should().Be(bdByTokyo.ToUniversalTime());
		}

		[Fact]
		public void ToUtcDateTimeReturnsUtc()
		{
			var converter = new UnixDateTimeConverter();
			converter.ToUtcDateTime(converter.ToBytes(DateTime.Now)).Kind.Should().Be(DateTimeKind.Utc);
		}
	}
}
