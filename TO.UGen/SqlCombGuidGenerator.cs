using System;

namespace TO.UGen
{
	public sealed class SqlCombGuidGenerator : ICombGuidGenerator
	{
		private readonly IDateTimeConverter _converter;

		public SqlCombGuidGenerator(IDateTimeConverter converter)
		{
			_converter = converter ?? throw new ArgumentNullException(nameof(converter));
		}

		public SqlCombGuidGenerator()
		{
			_converter = new UnixDateTimeConverter();
		}

		/// <summary>
		/// Checkout a reason why we set time as last 6 bytes for MsSql
		/// https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql/comparing-guid-and-uniqueidentifier-values
		/// </summary>
		public Guid CreateNew()
		{
			var gBytes = Guid.NewGuid().ToByteArray();
			var dateBytes = _converter.ToBytes(DateTime.Now);
			var gSpan = new Span<byte>(gBytes, gBytes.Length - _converter.NumDateBytes, _converter.NumDateBytes);
			dateBytes.CopyTo(gSpan);

			return new Guid(gBytes);
		}

		public DateTime GetTimestamp(Guid value)
		{
			var byteArray = value.ToByteArray();
			var gBytes = new Span<byte>(byteArray, byteArray.Length - _converter.NumDateBytes, _converter.NumDateBytes);
			return _converter.ToUtcDateTime(gBytes);
		}
	}
}