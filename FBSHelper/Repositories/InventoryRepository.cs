using FBSHelper.Models;
using FBSHelper.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBSHelper.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly SqlConnection con;
        public InventoryRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString("DBConnectionString");
            this.con = new SqlConnection(connectionString);
        }


        public bool AddInventory(Inventory inventoryData)
        {
            int flag = 0;
            SqlCommand cmd = new SqlCommand("Proc_Inventories_AddInventory", con);
            try
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@flightNumber", inventoryData.FlightNumber));
                cmd.Parameters.Add(new SqlParameter("@airlineId", inventoryData.AirlineId));
                cmd.Parameters.Add(new SqlParameter("@fromPlace", inventoryData.FromPlace));
                cmd.Parameters.Add(new SqlParameter("@toPlace", inventoryData.ToPlace));
                cmd.Parameters.Add(new SqlParameter("@startTime", inventoryData.StartDate));
                cmd.Parameters.Add(new SqlParameter("@endTime", inventoryData.EndDate));
                cmd.Parameters.Add(new SqlParameter("@scheduledDays", inventoryData.ScheduledDays));
                cmd.Parameters.Add(new SqlParameter("@instrumentUsed", inventoryData.InstrumentUsed));
                cmd.Parameters.Add(new SqlParameter("@totalBCSeats", inventoryData.TotalBCSeats));
                cmd.Parameters.Add(new SqlParameter("@totalNBCSeats", inventoryData.TotalNBCSeats));
                cmd.Parameters.Add(new SqlParameter("@numberOfRows", inventoryData.NumberOfRows));
                cmd.Parameters.Add(new SqlParameter("@mealType", inventoryData.MealType));
                cmd.Parameters.Add(new SqlParameter("@bcTicketCost", inventoryData.BCTicketCost));
                cmd.Parameters.Add(new SqlParameter("@nbcTicketCost", inventoryData.NBCTicketCost));
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

        public List<Inventory> GetAllInventories()
        {
            List<Inventory> inventoryLists = new List<Inventory>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Inventories_GetAllInventories", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Inventory inventory = new Inventory();
                    inventory.flightId = int.Parse(dr["flightId"].ToString());
                    inventory.FlightNumber = dr["FlightNumber"].ToString();
                    inventory.AirlineName = dr["AirlineName"].ToString();
                    inventory.AirlineId = int.Parse(dr["AirlineId"].ToString());
                    inventory.FromPlace = dr["FromPlace"].ToString();
                    inventory.ToPlace = dr["ToPlace"].ToString();
                    inventory.StartDate = Convert.ToDateTime(dr["StartTime"].ToString());
                    inventory.EndDate = Convert.ToDateTime(dr["EndTime"].ToString());
                    inventory.ScheduledDays = dr["ScheduledDays"].ToString();
                    inventory.InstrumentUsed = dr["InstrumentUsed"].ToString();
                    inventory.TotalBCSeats = int.Parse(dr["TotalBCSeats"].ToString());
                    inventory.TotalNBCSeats = int.Parse(dr["TotalNBCSeats"].ToString());
                    inventory.NumberOfRows = int.Parse(dr["NumberOfRows"].ToString());
                    inventory.MealType = dr["MealType"].ToString();
                    inventory.BCTicketCost = float.Parse(dr["BCTicketCost"].ToString());
                    inventory.NBCTicketCost = float.Parse(dr["NBCTicketCost"].ToString());
                    inventoryLists.Add(inventory);
                }

            }
            catch (SqlException e)
            {
            }
            finally
            {
                con.Close();
            }
            return inventoryLists;
        }

        public List<Inventory> GetAllFlightDetails(string fromPlace, string toPlace, DateTime? startDate, DateTime? endDate, string tripMode)
        {
            List<Inventory> inventoryLists = new List<Inventory>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Inventories_GetAllFlightDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@fromPlace", fromPlace));
                cmd.Parameters.Add(new SqlParameter("@toPlace", toPlace));
                cmd.Parameters.Add(new SqlParameter("@startTime", startDate));
                cmd.Parameters.Add(new SqlParameter("@endTime", endDate));
                cmd.Parameters.Add(new SqlParameter("@tripMode", tripMode));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Inventory inventoryData = new Inventory();
                    inventoryData.flightId = int.Parse(dr["flightId"].ToString());
                    inventoryData.FlightNumber = dr["FlightNumber"].ToString();
                    inventoryData.AirlineName = dr["AirlineName"].ToString();
                    inventoryData.FromPlace = dr["FromPlace"].ToString();
                    inventoryData.ToPlace = dr["ToPlace"].ToString();
                    inventoryData.StartDate = Convert.ToDateTime(dr["StartTime"].ToString());
                    inventoryData.EndDate = Convert.ToDateTime(dr["EndTime"].ToString());
                    inventoryData.ScheduledDays = dr["ScheduledDays"].ToString();
                    inventoryData.MealType = dr["MealType"].ToString();
                    inventoryData.BCTicketCost = float.Parse(dr["BCTicketCost"].ToString());
                    inventoryData.NBCTicketCost = float.Parse(dr["NBCTicketCost"].ToString());
                    inventoryLists.Add(inventoryData);
                }

            }
            catch (SqlException e)
            {
            }
            finally
            {
                con.Close();
            }
            return inventoryLists;
        }

        public Inventory GetInventoryByFlightNumberAndStartDate(string flightNumber, DateTime startTime)
        {
            Inventory inventoryData = new Inventory();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Inventories_GetInventoryByFlightNumberAndStartDate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@flightNumber", flightNumber));
                cmd.Parameters.Add(new SqlParameter("@startTime", startTime));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    inventoryData.flightId = int.Parse(dr["flightId"].ToString());
                    inventoryData.FlightNumber = dr["FlightNumber"].ToString();
                    inventoryData.AirlineName = dr["AirlineName"].ToString();
                    inventoryData.AirlineId = int.Parse(dr["AirlineId"].ToString());
                    inventoryData.FromPlace = dr["FromPlace"].ToString();
                    inventoryData.ToPlace = dr["ToPlace"].ToString();
                    inventoryData.StartDate = Convert.ToDateTime(dr["StartTime"].ToString());
                    inventoryData.EndDate = Convert.ToDateTime(dr["EndTime"].ToString());
                    inventoryData.ScheduledDays = dr["ScheduledDays"].ToString();
                    inventoryData.InstrumentUsed = dr["InstrumentUsed"].ToString();
                    inventoryData.TotalBCSeats = int.Parse(dr["TotalBCSeats"].ToString());
                    inventoryData.TotalNBCSeats = int.Parse(dr["TotalNBCSeats"].ToString());
                    inventoryData.NumberOfRows = int.Parse(dr["NumberOfRows"].ToString());
                    inventoryData.MealType = dr["MealType"].ToString();
                    inventoryData.BCTicketCost = float.Parse(dr["BCTicketCost"].ToString());
                    inventoryData.NBCTicketCost = float.Parse(dr["NBCTicketCost"].ToString());
                }

            }
            catch (SqlException e)
            {
            }
            finally
            {
                con.Close();
            }
            return inventoryData;
        }

        public Inventory GetFlightById(int id)
        {
            Inventory inventoryData = new Inventory();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Inventories_GetInventoryById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@flightId", id));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    inventoryData.flightId = int.Parse(dr["flightId"].ToString());
                    inventoryData.FlightNumber = dr["FlightNumber"].ToString();
                    inventoryData.AirlineName = dr["AirlineName"].ToString();
                    inventoryData.AirlineId = int.Parse(dr["AirlineId"].ToString());
                    inventoryData.FromPlace = dr["FromPlace"].ToString();
                    inventoryData.ToPlace = dr["ToPlace"].ToString();
                    inventoryData.StartDate = Convert.ToDateTime(dr["StartTime"].ToString());
                    inventoryData.EndDate = Convert.ToDateTime(dr["EndTime"].ToString());
                    inventoryData.ScheduledDays = dr["ScheduledDays"].ToString();
                    inventoryData.InstrumentUsed = dr["InstrumentUsed"].ToString();
                    inventoryData.TotalBCSeats = int.Parse(dr["TotalBCSeats"].ToString());
                    inventoryData.TotalNBCSeats = int.Parse(dr["TotalNBCSeats"].ToString());
                    inventoryData.NumberOfRows = int.Parse(dr["NumberOfRows"].ToString());
                    inventoryData.MealType = dr["MealType"].ToString();
                    inventoryData.BCTicketCost = float.Parse(dr["BCTicketCost"].ToString());
                    inventoryData.NBCTicketCost = float.Parse(dr["NBCTicketCost"].ToString());
                }

            }
            catch (SqlException e)
            {
            }
            finally
            {
                con.Close();
            }
            return inventoryData;
        }
    }
}
