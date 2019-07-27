using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Acro.Common;
using Dapper;

namespace Acro.Data.StoredProcs
{
	public class StoredProcWrapper
	{
		private readonly string _connectionString;
		
		public StoredProcWrapper(DbSettings settings)
		{
			_connectionString = settings.ConnectionString;
		}

		public IDbConnection CreateConnection()
		{
			return new SqlConnection(_connectionString);
		}

		public IEnumerable<T> GetByStoredProc<T>()
		{
			using (var conn = CreateConnection())
			{
				conn.Open();
				return conn.Query<T>(SpProducts.Name, 
					commandType: CommandType.StoredProcedure,
					param: new { Action = SpProducts.ActionSelectAll });
			}
		}
	}
}