using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace HtmlHelperDemo.Models
{
    public class UserDAL
    {
        string cstring = "";
        public UserDAL()
        {
            cstring = "Data Source=DESKTOP-F1TPI91;Initial Catalog=UserDB;Integrated Security=True";
        }
        public List<User> GetUsers() {
            List<User> users = new List<User>();
            SqlConnection con = new SqlConnection(cstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("select userid,username,password,email from users", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                User user = new User();
                user.userid = Convert.ToInt32(dr["userid"]);
                user.username = dr["username"].ToString();
                user.password = dr["password"].ToString();
                user.email = dr["email"].ToString();
                users.Add(user);
            }
            con.Close();
            return users;
        }
        public void AddUser(User user) {
            SqlConnection con = new SqlConnection(cstring);
            con.Open();
            SqlCommand cmd = new
                SqlCommand("insert into users(username,password,email) values(@username,@password,@email)", con);
            cmd.Parameters.AddWithValue("@username", user.username);
            cmd.Parameters.AddWithValue("@password", user.password);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void updateUser(User user) {
            SqlConnection con = new SqlConnection(cstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("update users set username=@username,password=@password,email=@email where userid=@id", con);
            cmd.Parameters.AddWithValue("@id", user.userid);
            cmd.Parameters.AddWithValue("@username", user.username);
            cmd.Parameters.AddWithValue("@password", user.password);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public User GetUserbyId(int id) {
            User user = new User();
            SqlConnection con = new SqlConnection(cstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("select userid,username,password,email from users where userid=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                user.userid = Convert.ToInt32(dr["userid"]);
                user.username = dr["username"].ToString();
                user.password = dr["password"].ToString();
                user.email = dr["email"].ToString();
            }
            con.Close();
            return user;

        }
        public void DeleteUser(User user) {
            SqlConnection con = new SqlConnection(cstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from users where userid=@id", con);
            cmd.Parameters.AddWithValue("@id", user.userid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}