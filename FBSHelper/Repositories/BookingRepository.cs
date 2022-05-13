using FBSHelper.Models;
using FBSHelper.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBSHelper.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly SqlConnection con;
        public BookingRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString("DBConnectionString");
            this.con = new SqlConnection(connectionString);
        }
        public string BookFlight(Booking bookingDetails)
        {
            string pnrNumber = GetPNR();
            int flag = 0;
            SqlCommand cmd = new SqlCommand("Proc_BookingDetails_BookFlight", con);
            try
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@flightNumber", bookingDetails.FlightNumber));
                cmd.Parameters.Add(new SqlParameter("@UserId", bookingDetails.UserId));
                cmd.Parameters.Add(new SqlParameter("@name", bookingDetails.Name));
                cmd.Parameters.Add(new SqlParameter("@email", bookingDetails.Email));
                cmd.Parameters.Add(new SqlParameter("@numberOfSeats", bookingDetails.NumberOfSeats));
                cmd.Parameters.Add(new SqlParameter("@mealType", bookingDetails.MealType));
                cmd.Parameters.Add(new SqlParameter("@bookedDate", bookingDetails.BookedDate));
                cmd.Parameters.Add(new SqlParameter("@tripMode", bookingDetails.TripMode));
                cmd.Parameters.Add(new SqlParameter("@totalCost", bookingDetails.TotalCost));
                cmd.Parameters.Add(new SqlParameter("@PNRNumber", pnrNumber));
                cmd.Parameters.Add(new SqlParameter("@flightId", bookingDetails.FlightId));
                cmd.Parameters.Add(new SqlParameter("@fromPlace", bookingDetails.FromPlace));
                cmd.Parameters.Add(new SqlParameter("@toPlace", bookingDetails.ToPlace));
                DataTable passengerTable = GetDataTable(bookingDetails.PassengerDetails);
                var list = new SqlParameter("@passenger", SqlDbType.Structured);
                list.TypeName = "dbo.UDTT_Passenger";
                list.Value = passengerTable;
                cmd.Parameters.Add(list);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    flag = 1;
                }
            }
            catch (SqlException e)
            {
            }
            finally
            {
                con.Close();
            }
            if (flag == 1)
                return pnrNumber;
            else
                return string.Empty;
        }

        public Booking GetBookingDetailsByPNRNumber(string pnrNumber)
        {
            Booking bookingDetails = new Booking();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_BookingDetails_GetBookingDetailsByPNRNumber", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pnrNumber", pnrNumber));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bookingDetails.BookingId = int.Parse(dr["BookingId"].ToString());
                    bookingDetails.FlightNumber = dr["FlightNumber"].ToString();
                    bookingDetails.UserId = Guid.Parse(dr["UserId"].ToString());
                    bookingDetails.Name = dr["Name"].ToString();
                    bookingDetails.Email = dr["Email"].ToString();
                    bookingDetails.NumberOfSeats = int.Parse(dr["NumberOfSeats"].ToString());
                    bookingDetails.MealType = dr["MealType"].ToString();
                    bookingDetails.BookedDate = Convert.ToDateTime(dr["BookedDate"].ToString());
                    bookingDetails.TripMode = dr["TripMode"].ToString();
                    bookingDetails.TotalCost = int.Parse(dr["TotalCost"].ToString());
                    bookingDetails.PNRNumber = dr["PNRNumber"].ToString();
                    bookingDetails.FlightId = int.Parse(dr["FlightId"].ToString());
                    bookingDetails.FromPlace = dr["FromPlace"].ToString();
                    bookingDetails.ToPlace = dr["ToPlace"].ToString();
                    bookingDetails.PassengerDetails = new List<Passenger>();
                }
                dr.NextResult();
                while (dr.Read())
                {
                    bookingDetails.PassengerDetails.Add(new Passenger()
                    {
                        PassengerId = int.Parse(dr["PassengerId"].ToString()),
                        BookingId = int.Parse(dr["BookingId"].ToString()),
                        Name = dr["Name"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        Age = int.Parse(dr["Age"].ToString()),
                        SeatNo = dr["SeatNo"].ToString()
                    });
                }

            }
            catch (SqlException e)
            {
            }
            finally
            {
                con.Close();
            }
            return bookingDetails;
        }

        public List<Booking> GetBookingDetailsByEmail(string email)
        {
            List<Booking> bookingDetailLists = new List<Booking>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_BookingDetails_GetBookingDetailsByEmail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@email", email));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Booking bookingDetails = new Booking();
                    bookingDetails.BookingId = int.Parse(dr["BookingId"].ToString());
                    bookingDetails.FlightNumber = dr["FlightNumber"].ToString();
                    bookingDetails.UserId = Guid.Parse(dr["UserId"].ToString());
                    bookingDetails.Name = dr["Name"].ToString();
                    bookingDetails.Email = dr["Email"].ToString();
                    bookingDetails.NumberOfSeats = int.Parse(dr["NumberOfSeats"].ToString());
                    bookingDetails.MealType = dr["MealType"].ToString();
                    bookingDetails.BookedDate = Convert.ToDateTime(dr["BookedDate"].ToString());
                    bookingDetails.TripMode = dr["TripMode"].ToString();
                    bookingDetails.TotalCost = int.Parse(dr["TotalCost"].ToString());
                    bookingDetails.PNRNumber = dr["PNRNumber"].ToString();
                    bookingDetails.FlightId = int.Parse(dr["FlightId"].ToString());
                    bookingDetails.FromPlace = dr["FromPlace"].ToString();
                    bookingDetails.ToPlace = dr["ToPlace"].ToString();
                    bookingDetails.PassengerDetails = new List<Passenger>();
                    DateTime today = DateTime.Now;
                    int result = DateTime.Compare(today, bookingDetails.BookedDate);
                    if(result < 0)
                    {
                        bookingDetails.IsAbleToCancel = true;
                    }
                    else
                    {
                        bookingDetails.IsAbleToCancel = false;
                    }
                    bookingDetailLists.Add(bookingDetails);
                }
            }
            catch (SqlException e)
            {
            }
            finally
            {
                con.Close();
            }
            return bookingDetailLists;
        }


        public bool CancelBookingByPNRNumber(string pnrNumber)
        {
            int flag = 0;
            SqlCommand cmd = new SqlCommand("Proc_BookingDetails_CancelBooking", con);
            try
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PNRNumber", pnrNumber));
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    flag = 1;
                }
            }
            catch (SqlException e)
            {
            }
            finally
            {
                con.Close();
            }
            if (flag == 1)
                return true;
            else
                return false;
        }
        public Discount GetDiscountByCode(string code)
        {
            Discount discountData = new Discount();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Discounts_GetDiscountByCode", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@code", code));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    discountData.AirlineId = int.Parse(dr["AirlineId"].ToString());
                    discountData.Code = dr["Code"].ToString();
                    discountData.Amount = int.Parse(dr["Amount"].ToString());
                    discountData.DiscountStartDate = Convert.ToDateTime(dr["DiscountStartDate"].ToString());
                    discountData.DiscountEndDate = Convert.ToDateTime(dr["DiscountEndDate"].ToString());
                }

            }
            catch (SqlException e)
            {
            }
            finally
            {
                con.Close();
            }
            return discountData;
        }
        public List<int> GetSeats(int id)
        {
            List<int> seatLists = new List<int>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Passenger_GetSeats", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seatLists.Add(int.Parse(dr["SeatNo"].ToString()));
                }

            }
            catch (SqlException e)
            {
            }
            finally
            {
                con.Close();
            }
            return seatLists;
        }

        private static string GetPNR()
        {
            int length = 8;
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private DataTable GetDataTable(List<Passenger> passengerDetails)
        {
            DataTable passengerTable;
            using (passengerTable = new DataTable())
            {
                passengerTable.Columns.Add("Name", typeof(string));
                passengerTable.Columns.Add("Gender", typeof(string));
                passengerTable.Columns.Add("Age", typeof(int));
                passengerTable.Columns.Add("SeatNo", typeof(string)); 
                foreach(var pd in passengerDetails)
                {
                    passengerTable.Rows.Add(pd.Name, pd.Gender, pd.Age, pd.SeatNo);
                }
            }
            return passengerTable;
        }
    }
}
