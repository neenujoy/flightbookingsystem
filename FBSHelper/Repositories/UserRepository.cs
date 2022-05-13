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
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly SqlConnection con;
        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString("DBConnectionString");
            this.con = new SqlConnection(connectionString);
        }

        public bool AddUser(User userData)
        {
            int flag = 0;
            SqlCommand cmd = new SqlCommand("Proc_Users_AddUser", con);
            try
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@userId", userData.UserId));
                cmd.Parameters.Add(new SqlParameter("@name", userData.Name));
                cmd.Parameters.Add(new SqlParameter("@email", userData.Email));
                cmd.Parameters.Add(new SqlParameter("@password", userData.Password));
                cmd.Parameters.Add(new SqlParameter("@role", userData.UserRole));
                cmd.Parameters.Add(new SqlParameter("@address", userData.Address));
                cmd.Parameters.Add(new SqlParameter("@phone", userData.Phone));
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

        public User GetUserByUsernameAndPassword(Login loginDetails)
        {
            User userData = new User();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Users_GetUserByUsernameAndPassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@username", loginDetails.Username));
                cmd.Parameters.Add(new SqlParameter("@password", loginDetails.Password));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    userData.UserId = Guid.Parse(dr["UserId"].ToString());
                    userData.Name = dr["Name"].ToString();
                    userData.Email = dr["Email"].ToString();
                    userData.UserRole = (Role)(int.Parse(dr["Role"].ToString()));
                    userData.Address = dr["Address"].ToString();
                    userData.Phone = dr["Phone"].ToString();
                }

            }
            catch (SqlException e)
            {
            }
            finally
            {
                con.Close();
            }
            return userData;
        }

        public User GetUserByUsername(string username)
        {
            User userData = new User();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Users_GetUserByUsername", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@username", username));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    userData.UserId = Guid.Parse(dr["UserId"].ToString());
                    userData.Name = dr["Name"].ToString();
                    userData.Email = dr["Email"].ToString();
                    userData.UserRole = (Role)(int.Parse(dr["Role"].ToString()));
                    userData.Address = dr["Address"].ToString();
                    userData.Phone = dr["Phone"].ToString();
                }

            }
            catch (SqlException e)
            {
            }
            finally
            {
                con.Close();
            }
            return userData;
        }
    }
}
