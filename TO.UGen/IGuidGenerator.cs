using System;

namespace TO.UGen
{
	public interface IGuidGenerator
	{
		Guid CreateNew();
	}

	public interface ICombGuidGenerator : IGuidGenerator
	{
		DateTime GetTimestamp(Guid value);
	}
}
