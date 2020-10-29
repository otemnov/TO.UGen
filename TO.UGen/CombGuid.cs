using System;

namespace TO.UGen
{
	public static class CombGuid
	{
		public static readonly ICombGuidGenerator Sql = new SqlCombGuidGenerator();

		public static Guid CreateNew()
		{
			return Sql.CreateNew();
		}
	}
}
