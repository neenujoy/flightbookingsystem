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
    public class AirlineRepository : IAirlineRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly SqlConnection con;
        public AirlineRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString("DBConnectionString"); 
            this.con = new SqlConnection(connectionString);
        }
        public bool RegisterAirlines(Airline airlineData)
        {
            int flag = 0;
            SqlCommand cmd = new SqlCommand("Proc_Airlines_AddAirlines", con);
            try
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@airlineName", airlineData.AirlineName));
                cmd.Parameters.Add(new SqlParameter("@airlineLogo", airlineData.AirlineLogo));
                cmd.Parameters.Add(new SqlParameter("@contactNumber", airlineData.ContactNumber));
                cmd.Parameters.Add(new SqlParameter("@contactAddress", airlineData.ContactAddress));
                cmd.Parameters.Add(new SqlParameter("@isBlocked", airlineData.IsBlocked));
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

        public List<Airline> GetAirlines()
        {
            List<Airline> airlineLists = new List<Airline>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Airlines_GetAirlines", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Airline airline = new Airline();
                    airline.AirlineId = int.Parse(dr["AirlineId"].ToString());
                    airline.AirlineName = dr["AirlineName"].ToString();
                    airline.AirlineLogo = dr["AirlineLogo"].ToString();
                    airline.ContactNumber = dr["ContactNumber"].ToString();
                    airline.ContactAddress = dr["ContactAddress"].ToString();
                    airline.IsBlocked = Convert.ToBoolean(dr["IsBlocked"].ToString());
                    airlineLists.Add(airline);
                }

            }
            catch (SqlException e)
            {
            }
            finally
            {
                con.Close();
            }
            return airlineLists;
        }

        public Airline GetAirlineByName(string name)
        {
            Airline airlineData = new Airline();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Airlines_GetAirlineByName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@airlineName", name));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    airlineData.AirlineId = int.Parse(dr["AirlineId"].ToString());
                    airlineData.AirlineName = dr["AirlineName"].ToString();
                    airlineData.AirlineLogo = dr["AirlineLogo"].ToString();
                    airlineData.ContactNumber = dr["ContactNumber"].ToString();
                    airlineData.ContactAddress = dr["ContactAddress"].ToString();
                    airlineData.IsBlocked = Convert.ToBoolean(dr["IsBlocked"].ToString());
                }

            }
            catch (SqlException e)
            {
            }
            finally
            {
                con.Close();
            }
            return airlineData;
        }
        public bool UpdateAirlines(int id, Airline airlineData)
        {
            int flag = 0;
            SqlCommand cmd = new SqlCommand("Proc_Airlines_UpdateAirlines", con);
            try
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@airlineId", id));
                cmd.Parameters.Add(new SqlParameter("@airlineLogo", airlineData.AirlineLogo));
                cmd.Parameters.Add(new SqlParameter("@contactNumber", airlineData.ContactNumber));
                cmd.Parameters.Add(new SqlParameter("@contactAddress", airlineData.ContactAddress));
                cmd.Parameters.Add(new SqlParameter("@isBlocked", airlineData.IsBlocked));
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
        public bool AddDiscount(Discount discountData)
        {
            int flag = 0;
            SqlCommand cmd = new SqlCommand("Proc_Discounts_AddDiscount", con);
            try
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@airlineId", discountData.AirlineId));
                cmd.Parameters.Add(new SqlParameter("@code", discountData.Code));
                cmd.Parameters.Add(new SqlParameter("@amount", discountData.Amount));
                cmd.Parameters.Add(new SqlParameter("@discountStartDate", discountData.DiscountStartDate));
                cmd.Parameters.Add(new SqlParameter("@discountEndDate", discountData.DiscountEndDate));
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
        public List<Discount> GetDiscounts()
        {
            List<Discount> discountLists = new List<Discount>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Discounts_GetAllDiscount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Discount discount = new Discount();
                    discount.Code = dr["Code"].ToString();
                    discount.Amount = int.Parse(dr["Amount"].ToString());
                    discount.AirlineId = int.Parse(dr["AirlineId"].ToString());
                    discount.AirlineName = dr["AirlineName"].ToString();
                    discount.DiscountStartDate = Convert.ToDateTime(dr["DiscountStartDate"].ToString());
                    discount.DiscountEndDate = Convert.ToDateTime(dr["DiscountEndDate"].ToString());
                    discountLists.Add(discount);
                }

            }
            catch (SqlException e)
            {
            }
            finally
            {
                con.Close();
            }
            return discountLists;
        }
    }
}
