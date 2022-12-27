using Microsoft.Win32;
using System;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Configuration;
using Microsoft.AspNetCore.Hosting.Server;
using System.Net.NetworkInformation;
using Idylis_Framework.Idylis_DAL;
namespace testApi.Model
{
    public class BDDConnection
    {

        public static SqlConnection conn;
        public static void Connect()
        {      
            string connStr = "server=10.38.2.5\\SQLDEV_1;uid=sa;pwd=sql@saint0uen;packet size=4096;Connection Timeout=60;";
            conn = new SqlConnection(connStr);
        }
    }
}
