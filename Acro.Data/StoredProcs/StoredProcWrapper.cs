using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Acro.Common;
using Acro.Data.Implementations;
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

		public IEnumerable<T> GetMany<T>()
		{
			using (var conn = CreateConnection())
			{
				conn.Open();
				return conn.Query<T>(SpProducts.Name, 
					commandType: CommandType.StoredProcedure,
					param: new { Action = SpProducts.ActionSelectAll });
			}
		}

		public IEnumerable<T> Execute<T>(StoredProcedureParameters parameters)
		{
			using (var conn = CreateConnection())
			{
				conn.Open();
				return conn.Query<T>(parameters.StoredProcName,
					commandType: CommandType.StoredProcedure,
					param: parameters.Params);
					//param: new { Action = SpProducts.ActionSelectAll });
			}
		}

		public T ExecuteOne<T>(StoredProcedureParameters parameters)
		{
			using (var conn = CreateConnection())
			{
				conn.Open();
				return conn.QueryFirstOrDefault<T>(parameters.StoredProcName,
					commandType: CommandType.StoredProcedure,
					param: parameters.Params);
			}
		}

		public void ExecuteNonQuery(StoredProcedureParameters parameters)
		{
			using (var conn = CreateConnection())
			{
				conn.Open();
				conn.Execute(parameters.StoredProcName,
					commandType: CommandType.StoredProcedure,
					param: parameters.Params);
			}
		}
	}
}