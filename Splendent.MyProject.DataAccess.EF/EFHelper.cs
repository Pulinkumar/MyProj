using Splendent.MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splendent.MyProject.DataAccess.EF
{
    public static class EFHelper
    {
        public static string CreateSPCommand(string spName, SqlParameter[] paramArray)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(spName + " ");

            foreach (SqlParameter parameter in paramArray)
            {
                if (parameter.Direction == ParameterDirection.Output)
                {
                    sb.Append(parameter.ParameterName + " OUTPUT,");
                }
                else
                {
                    sb.Append(parameter.ParameterName + ",");
                }
            }
            return (sb.ToString().TrimEnd(','));
        }


        public static IEnumerable<T> ExecuteSql<T>(string query, params object[] parameters)
        {

            using (var context = new DatabaseContext())
            {
                return context.Database.SqlQuery<T>(query, parameters).ToList();
            }
        }

        public static IEnumerable<T> ExecuteSP<T>(string spName, SqlParameter[] parameters)
        {
            string query = CreateSPCommand(spName, parameters);

            return ExecuteSql<T>(query, parameters);
        }


        public static int ExecuteSqlCommand(string spName, SqlParameter[] parameters, int ReturnParameterIndex)
        {
            string query = CreateSPCommand(spName, parameters);
            int nTotalRowsAffected = DataContextFactory.GetDataContext().Database.ExecuteSqlCommand(query, parameters);
            return Convert.ToInt32(parameters[ReturnParameterIndex].Value.ToString());
        }

        public static int ExecuteSqlCommand(string spName, SqlParameter[] parameters)
        {
            string query = CreateSPCommand(spName, parameters);

            using (var context = new DatabaseContext())
            {
                return context.Database.ExecuteSqlCommand(query, parameters);
            }
        }

        public static IEnumerable<T> ExecuteSP<T>(string spName)
        {
            return ExecuteSql<T>(spName);
        }

        public static T ExecuteScalar<T>(string query, params object[] parameters)
        {
            return ExecuteSql<T>(query, parameters).FirstOrDefault();
        }

        public static T ExecuteScalar<T>(string query)
        {
            return ExecuteScalar<T>(query, new object[] { });
        }

        public static IQueryable<TEntity> GetLookUp<TEntity, K>() where TEntity : DomainEntity<K>
        {
            return DataContextFactory.GetDataContext().Set<TEntity>();
        }
    }
}
