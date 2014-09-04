using System;
using System.Data.Common;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DbMock1G4.DataAccess
{
    public class Data
    {
        public Data()
        {
            
        }
        private static string DataProvider = ConfigurationManager.ConnectionStrings["ConnectionString"].ProviderName;
        private  static  DbProviderFactory Factory = DbProviderFactories.GetFactory(DataProvider);
        public static  string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //public static string ConnectionString1()
        //{
        //    string str = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //    try
        //    {
        //        return str;
        //    }
        //    catch
        //    {
        //        str = @"Data Source=PC\TRUNGDUC;Initial Catalog=DbMock1G4;Integrated Security=True";
        //    }
        //    var cn = new SqlConnection(str);
        //    if (cn.State == ConnectionState.Closed)
        //    {
        //        cn.Open();
        //    }
        //    return str;
        //}
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
