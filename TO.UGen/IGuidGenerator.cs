using System;

namespace TO.UGen
{
	public interface IGuidGenerator
	{
		Guid NewGuid();
	}

	public interface ICombGuidGenerator : IGuidGenerator
	{
		DateTime GetTimestamp(Guid value);
	}
}
