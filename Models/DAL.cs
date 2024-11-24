using Microsoft.Data.SqlClient;
using System.Data;

namespace LoginRegistrationApp.Models
{
    public class DAL
    {
        public Response Register(Register user, SqlConnection con)
        {
            Response response = new Response();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_register", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.Char, 200);
                cmd.Parameters["@ErrorMessage"].Direction = System.Data.ParameterDirection.Output;
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Registration Successful !!";
                }

            }
            catch (Exception ex)
            {
                response.StatusCode = 100;
                response.StatusMessage = ex.Message;
            }
            return response;
        }
        public Response Login(Login user, SqlConnection con)
        {
            Response response = new Response();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_login",con);
                da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Email",user.Email);
                da.SelectCommand.Parameters.AddWithValue("@Password",user.Password);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    response.StatusCode=200;
                    response.StatusMessage = "Login Successful !!";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 100;
                response.StatusMessage = ex.Message;
            }
            return response;
        }
    }
}
