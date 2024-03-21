using Microsoft.Data.SqlClient;
using RazorHotelDB.Interfaces;
using RazorHotelDB.Models;
using System.Data;

namespace RazorHotelDB.Services
{
    public class HotelService : Connection, IHotelService
    {
        private string sqlString1 = "SELECT Hotel_No, Name, Address FROM Hotel";
        private string sqlString2 = "INSERT INTO Hotel VALUES(@ID, @Navn, @Adresse)";
        private string sqlString3 = "SELECT Hotel_No, Name, Address FROM Hotel WHERE Hotel_No = @searchID";
        private string sqlString4 = "UPDATE Hotel SET Hotel_No = @EditedNumber, Name = @EditedName, Address = @EditedAddress WHERE Hotel_No = @HotelToEdit";

        public bool CreateHotel(Hotel hotel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlString2, connection);
                    command.Parameters.AddWithValue("@ID", hotel.HotelNr);
                    command.Parameters.AddWithValue("@Navn", hotel.Navn);
                    command.Parameters.AddWithValue("@Adresse", hotel.Adresse);
                    command.Connection.Open();
                    int noOfRows = command.ExecuteNonQuery();
                    return noOfRows == 1;
                }
                catch (SqlException sqlExp)
                {
                    Console.WriteLine("Database error" + sqlExp.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Generel fejl: " + ex.Message);
                }
                finally
                {

                }
            }
            return false;
        }

        public Hotel DeleteHotel(int hotelNr)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> GetAllHotel()
        {
            List<Hotel> hoteller = new List<Hotel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlString1, connection);
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int hotelNr = reader.GetInt32("Hotel_No");
                        string hotelNavn = reader.GetString("Name");
                        string hotelAdr = reader.GetString("Address");
                        Hotel hotel = new Hotel(hotelNr, hotelNavn, hotelAdr);
                        hoteller.Add(hotel);
                    }
                    reader.Close();
                }
                catch (SqlException sqlExp)
                {
                    Console.WriteLine("Database error" + sqlExp.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Generel fejl: " + ex.Message);
                }
                finally
                {

                }
            }
            return hoteller;

        }

        public Hotel GetHotelFromId(int hotelNr)
        {
            Console.WriteLine("GetHotelFromID called");
            Hotel hotelFound = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlString3, connection);
                    command.Parameters.AddWithValue("@searchID", hotelNr);
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Console.WriteLine("Reader.Read() called");
                        int hotelNum = reader.GetInt32("Hotel_No");
                        string hotelNavn = reader.GetString("Name");
                        string hotelAdr = reader.GetString("Address");
                        hotelFound = new Hotel(hotelNum, hotelNavn, hotelAdr);
                    }
                    reader.Close();
                }
                catch (SqlException sqlExp)
                {
                    Console.WriteLine("Database error" + sqlExp.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Generel fejl: " + ex.Message);
                }
                finally
                {

                }
            }
            return hotelFound;
        }

        public List<Hotel> GetHotelsByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateHotel(Hotel editedHotel, int hotelToEdit)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlString4, connection);
                    command.Parameters.AddWithValue("@EditedNumber", editedHotel.HotelNr);
                    command.Parameters.AddWithValue("@EditedName", editedHotel.Navn);
                    command.Parameters.AddWithValue("@EditedAddress", editedHotel.Adresse);
                    command.Parameters.AddWithValue("@HotelToEdit", hotelToEdit);
                    command.Connection.Open();
                    int noOfRows = command.ExecuteNonQuery();
                    return noOfRows == 1;
                }
                catch (SqlException sqlExp)
                {
                    Console.WriteLine("Database error" + sqlExp.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Generel fejl: " + ex.Message);
                }
                finally
                {

                }
            }
            return false;
        }
    }
}
