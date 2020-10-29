using System;

namespace TO.UGen
{
	public class UnixDateTimeConverter : IDateTimeConverter
	{
		private const int NumLongBytes = sizeof(long);
		public int NumDateBytes => 6;
		public static readonly DateTime MinDateTimeValue = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

		public Span<byte> ToBytes(DateTime timestamp)
		{
			DateTime utcDate = timestamp.ToUniversalTime();
			long milliseconds = (utcDate.Ticks - MinDateTimeValue.Ticks) / TimeSpan.TicksPerMillisecond;
			byte[] msBytes = BitConverter.GetBytes(milliseconds);
			if (BitConverter.IsLittleEndian) Array.Reverse(msBytes);
			return msBytes.AsSpan(NumLongBytes - NumDateBytes, NumDateBytes);
		}

		public DateTime ToUtcDateTime(Span<byte> value)
		{
			// using Span here for quick migration .NET core in nearest future
			var msBytes = new byte[NumLongBytes];
			var msSpan = new Span<byte>(msBytes, NumLongBytes - NumDateBytes, NumDateBytes);
			value.CopyTo(msSpan);
			if (BitConverter.IsLittleEndian) Array.Reverse(msBytes);
			var ms = BitConverter.ToInt64(msBytes, 0);
			return MinDateTimeValue.AddMilliseconds(ms);
		}
	}
}
