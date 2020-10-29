using System;

namespace TO.UGen
{
	public sealed class SimpleGuidGenerator : IGuidGenerator 
	{
		public Guid NewGuid()
		{
			return Guid.NewGuid();
		}
	}
}