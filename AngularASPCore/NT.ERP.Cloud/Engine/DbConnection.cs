using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NTERPCloud.Engine
{
    public static class DbConnection
    {
        public static AppConfiguration ConfigSettings { get; set; }
        public static SqlConnection _connection = new SqlConnection();
        public static SqlConnection Connection
        {
            get
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    Get_Connection();
                }
                return _connection;
            }
        }


        public static void Get_Connection()
        {
            _connection = new SqlConnection();
            //connection = DB_Connect.Make_Connnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
            _connection.ConnectionString = GlobalVariables.ConnectionString;

            //            if (db_manage_connnection.DB_Connect.OpenTheConnection(connection))
            if (Open_Local_Connection())
            {
            }
            else
            {
                //					MessageBox::Show("No database connection connection made...\n Exiting now", "Database Connection Error");
                //					 Application::Exit();
            }
        }

        public static bool Open_Local_Connection()
        {
            try
            {
                _connection.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static SqlDataReader OpenReader(string strSql)
        {
            try
            {
                Get_Connection();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Connection;
                cmd.CommandText = strSql;
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static int ExecuteNonQuery(string strSql)
        {
            try
            {
                Get_Connection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Connection;
                cmd.CommandText = strSql;
                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
    // read-write variable
    //public static string Bar
    //{
    //    get
    //    {
    //        return HttpContext.Current.Application["Bar"] as string;
    //    }
    //    set
    //    {
    //        HttpContext.Current.Application["Bar"] = value;
    //    }
    //}
}

