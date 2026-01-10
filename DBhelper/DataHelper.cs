using ROServiceProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ROServiceProject.DataHelper
{
    public class DbHelper
    {
        // Get connection string from Web.config
        private static string connectionString = ConfigurationManager.ConnectionStrings["ROServiceDatabase"].ConnectionString;

        #region Execute Non-Query (INSERT, UPDATE, DELETE)

        /// <summary>
        /// Executes stored procedure for INSERT, UPDATE, DELETE operations
        /// Returns number of rows affected
        /// </summary>
        public static int ExecuteNonQuery(string procedureName, SqlParameter[] parameters = null)
        {
            int result = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters if provided
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        conn.Open();
                        result = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ExecuteNonQuery: " + ex.Message);
            }

            return result;
        }

        #endregion

        #region Execute Scalar (Get Single Value)

        /// <summary>
        /// Executes stored procedure and returns a single value (first column of first row)
        /// Useful for COUNT, SUM, MAX, etc.
        /// </summary>
        public static object ExecuteScalar(string procedureName, SqlParameter[] parameters = null)
        {
            object result = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        conn.Open();
                        result = cmd.ExecuteScalar();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ExecuteScalar: " + ex.Message);
            }

            return result;
        }

        #endregion

        #region Execute Reader (Get DataTable)

        /// <summary>
        /// Executes stored procedure and returns DataTable
        /// Used for SELECT queries
        /// </summary>
        public static DataTable ExecuteDataTable(string procedureName, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ExecuteDataTable: " + ex.Message);
            }

            return dt;
        }

        #endregion

        #region Execute Dataset (Get Multiple Tables)

        /// <summary>
        /// Executes stored procedure and returns DataSet (multiple tables)
        /// </summary>
        public static DataSet ExecuteDataSet(string procedureName, SqlParameter[] parameters = null)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ExecuteDataSet: " + ex.Message);
            }

            return ds;
        }

        #endregion

        #region Execute with Output Parameter

        /// <summary>
        /// Executes stored procedure with output parameter
        /// Returns the output parameter value
        /// </summary>
        public static object ExecuteWithOutputParam(string procedureName, SqlParameter[] parameters, string outputParamName)
        {
            object result = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        // Get output parameter value
                        result = cmd.Parameters[outputParamName].Value;

                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ExecuteWithOutputParam: " + ex.Message);
            }

            return result;
        }

        #endregion

        #region Helper Methods for Parameter Creation

        /// <summary>
        /// Creates a SQL parameter
        /// </summary>
        public static SqlParameter CreateParameter(string paramName, object value)
        {
            return new SqlParameter(paramName, value ?? DBNull.Value);
        }

        /// <summary>
        /// Creates a SQL output parameter
        /// </summary>
        public static SqlParameter CreateOutputParameter(string paramName, SqlDbType dbType)
        {
            SqlParameter param = new SqlParameter(paramName, dbType);
            param.Direction = ParameterDirection.Output;
            return param;
        }

        #endregion

        #region Test Connection

        /// <summary>
        /// Tests database connection
        /// Returns true if connection is successful
        /// </summary>
        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static UserModel GetCurrentUser()
        {
            UserModel user = null;

            if (HttpContext.Current != null &&
                HttpContext.Current.User.Identity.IsAuthenticated)
            {
                HttpCookie authCookie =
                    HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (authCookie != null)
                {
                    FormsAuthenticationTicket ticket =
                        FormsAuthentication.Decrypt(authCookie.Value);

                    if (ticket != null && !string.IsNullOrEmpty(ticket.UserData))
                    {
                        string[] userData = ticket.UserData.Split('|');

                        user = new UserModel
                        {

                            UserId = Convert.ToInt32(userData[0]),
                            UserName = userData[1],
                        };
                    }
                }
            }

            return user;
        }


        public static SqlParameter CreateOutputParameter(string name, SqlDbType type, int size)
        {
            return new SqlParameter
            {
                ParameterName = name,
                SqlDbType = type,
                Size = size,
                Direction = ParameterDirection.Output
            };
        }


        #endregion
    }
}