using Microsoft.AspNetCore.DataProtection;

namespace RazorHotelDB.Services
{
    public class Connection
    {
        protected string connectionString = Secret.ConnectionString;
    }
}
