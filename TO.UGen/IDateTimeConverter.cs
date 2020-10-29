using System;

namespace TO.UGen
{
	public interface IDateTimeConverter
	{
		public int NumDateBytes { get; }
		Span<byte> ToBytes(DateTime timestamp);
		DateTime ToUtcDateTime(Span<byte> value);
	}
}