using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class UserRepository
    {


        private static string connectionString
        {
            get
            {
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();

                builder.DataSource = ".";
                builder.InitialCatalog = "UserAccessManagementDB";


                builder.UserID = "sa";
                builder.Password = "sa123456";
                builder.IntegratedSecurity = false;
                return builder.ToString();
            }
        }


       static public List<User> GetAllUsers()
        {

            List<User> _users = new List<User>();


            using (SqlConnection con = new SqlConnection(connectionString))
            {


                using (SqlCommand cmd = new SqlCommand("Sp_GetAllUsers", con))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {

                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {


                                _users.Add(new User(
                                    (int)reader["UserID"],
                                    (string)reader["FullName"],
                                    (string)reader["UserName"],
                                    (string)reader["Email"],
                                    reader["PhoneNumber"] == DBNull.Value ? null : (string)reader["PhoneNumber"],
                                    (string)reader["Role"],
                                    (bool)reader["IsActive"],
                                    (DateTime)reader["CreatedAt"],
                                    reader["UpdatedAt"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["UpdatedAt"]


                                    )



                                    );

                            }

                        }



                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.ToString());
                        return new List<User>();

                    }


                }



            }

            return _users;



        }


        static public User GetUserById(int UserID)
        {

          User user = null;


            using (SqlConnection con = new SqlConnection(connectionString))
            {


                using (SqlCommand cmd = new SqlCommand("Sp_GetUserByID", con))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {

                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                           if(reader.Read())
                            {


                                user = new User(
                                   UserID,
                                   (string)reader["FullName"],
                                   (string)reader["UserName"],
                                   (string)reader["Email"],
                                   reader["PhoneNumber"] == DBNull.Value ? null : (string)reader["PhoneNumber"],
                                   (string)reader["Role"],
                                   (bool)reader["IsActive"],
                                   (DateTime)reader["CreatedAt"],
                                   reader["UpdatedAt"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["UpdatedAt"]


                                );




                            }

                        }



                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.ToString());
                        return null;

                    }


                }



            }

            return user;



        }


        static public User GetUserByEmail(string Email)
        {

            User user = null;


            using (SqlConnection con = new SqlConnection(connectionString))
            {


                using (SqlCommand cmd = new SqlCommand("Sp_GetUserByEmail", con))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Email", Email);

                    try
                    {

                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            if (reader.Read())
                            {


                                user = new User(
                                   (int)reader["UserID"],
                                   (string)reader["FullName"],
                                   (string)reader["UserName"],
                                   Email,
                                   reader["PhoneNumber"] == DBNull.Value ? null : (string)reader["PhoneNumber"],
                                   (string)reader["Role"],
                                   (bool)reader["IsActive"],
                                   (DateTime)reader["CreatedAt"],
                                   reader["UpdatedAt"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["UpdatedAt"]


                                );




                            }

                        }



                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.ToString());
                        return null;

                    }


                }



            }

            return user;



        }



        static public int InsertUser(User user)
        {


            int NewId = -1;

            using(SqlConnection con = new SqlConnection(connectionString))
            {

                using(SqlCommand cmd = new SqlCommand("Sp_AddNewUser" , con))
                {


                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FullName", user.FullName);
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", (object)user.PhoneNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);
                    cmd.Parameters.AddWithValue("@UpdatedAt", (object)user.LastUpdatedAt ?? DBNull.Value);
                    SqlParameter outputId = new SqlParameter("@NewUserID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputId);


                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                       
                        cmd.ExecuteNonQuery();

                      
                        if (outputId.Value != DBNull.Value)
                        {
                            NewId = (int)outputId.Value;
                           
                        }


                    }
                    catch(Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                        return -1;
                    }


                }

            }

           

            return NewId;
        }


        static public bool UpdateUserRole(int userId, string newRole)
        {

            int rowAffected = 0;

            using(SqlConnection con = new SqlConnection(connectionString))
            {



                using(SqlCommand cmd = new SqlCommand("SP_UpdateUserRole" , con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@NewRole", newRole);


                    try
                    {
                        con.Open();

                        rowAffected = cmd.ExecuteNonQuery();

                    }catch(Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                        return false;

                    }


                }


            }

            return (rowAffected > 0);

        }

        static public bool UpdateUserEmail(int userId, string Email)
        {

            int rowAffected = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {



                using (SqlCommand cmd = new SqlCommand("SP_UpdateUserEmail", con))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@NewEmail", Email);


                    try
                    {
                        con.Open();

                        rowAffected = cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                        return false;

                    }


                }


            }

            return (rowAffected > 0);

        }


        static public bool DeactivateUser(int userId)
        {

            int rowAffected = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {



                using (SqlCommand cmd = new SqlCommand("SP_DeactivateUser", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userId);
                  

                    try
                    {
                        con.Open();

                        rowAffected = cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                        return false;

                    }


                }


            }

            return (rowAffected > 0);

        }

        static public bool DeleteUser(int userId)
        {

            int rowAffected = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {



                using (SqlCommand cmd = new SqlCommand("SP_DeleteUser", con))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userId);


                    try
                    {
                        con.Open();

                        rowAffected = cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                        return false;

                    }


                }


            }

            return (rowAffected > 0);

        }


        static public int GetUsersCount()
        {
            int Count = 0;


            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SP_GetCountUsers", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        con.Open();

                        object Result = cmd.ExecuteScalar();

                        if(Result != null && int.TryParse(Result.ToString() , out int CountUser))
                        {
                            Count = CountUser;
                        }

                    }catch(Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                        return -1;
                    }



                }
            }

            return Count;

        }



    }
}
