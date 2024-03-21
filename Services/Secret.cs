using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace RazorHotelDB.Services
{
    public class Secret
    {
        //private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelDbtest2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private static string _connectionString = @"Data Source = mssql1.unoeuro.com; Initial Catalog = datarat_eu_db_ratdb; User ID = datarat_eu; Password=hwgack9zG3x5tnDfyrFB;Connect Timeout = 30; Encrypt=True;Trust Server Certificate=True;Application Intent = ReadWrite; Multi Subnet Failover=False";
        public static string ConnectionString
        {
            get { return _connectionString; }
        }
    }
}
