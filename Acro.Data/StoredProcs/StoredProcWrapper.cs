using Acro.Common;

namespace Acro.Data.StoredProcs
{
	public class StoredProcWrapper
	{
		private readonly string _connectionString;
		
		public StoredProcWrapper(DbSettings settings)
		{
			_connectionString = settings.ConnectionString;
		}


	}
}