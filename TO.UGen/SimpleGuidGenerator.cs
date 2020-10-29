using System;

namespace TO.UGen
{
	public sealed class SimpleGuidGenerator : IGuidGenerator 
	{
		public Guid CreateNew()
		{
			return Guid.NewGuid();
		}
	}
}