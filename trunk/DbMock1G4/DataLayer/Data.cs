using System;
using System.Data.Common;
using System.Configuration;
using System.Data;
namespace DbMock1G4.DataAccess
{
    public class Data
    {
        private static readonly string DataProvider = ConfigurationManager.ConnectionStrings["ConnectionString"].ProviderName;
        private static readonly DbProviderFactory Factory = DbProviderFactories.GetFactory(DataProvider);
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #region parameters

        public static DbParameter CreateParameter(string parameterName, DbType parameterType, int parameterSize)
        {
            DbParameter p = Factory.CreateParameter();
            p.ParameterName = parameterName;
            p.DbType = parameterType;
            p.Size = parameterSize;
            return p;
        }

        public static DbParameter CreateParameter(string parameterName, object parameterValue)
        {
            DbParameter p = Factory.CreateParameter();
            p.ParameterName = parameterName;
            p.Value = parameterValue;
            return p;
        }

        public static DbParameter CreateParameter(string parameterName)
        {
            DbParameter p = Factory.CreateParameter();
            p.ParameterName = parameterName;
            return p;
        }

        #endregion
    }
}
