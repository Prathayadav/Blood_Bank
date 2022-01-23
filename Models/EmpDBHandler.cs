using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BloodDoner.Models
{
    public class EmpDBHandler
    {
        private SqlConnection con;

        private void connectionDB()
        {
            con = new SqlConnection("Server=WGIN-DSK-056\\SQL19;Database=BloodBank;Trusted_Connection=True;");
        }
        public bool loginValidation(Employee e)
        {
            connectionDB();
            SqlCommand query = new SqlCommand("EmpLogin", con);
            bool check = false;
            query.CommandType = CommandType.StoredProcedure;

            con.Open();
            query.Parameters.AddWithValue("@Email", e.Email);
            query.Parameters.AddWithValue("@EmpPassword", e.Password);
            SqlDataReader reader = query.ExecuteReader();


            if (reader.Read())
            {
                check = true;
            }
            con.Close();
            return check;
        }
        public List<Admin> emplist()
        {
            connectionDB();
            SqlCommand query = new SqlCommand("Listemp", con);
            query.CommandType = CommandType.StoredProcedure;
            con.Open();
            List<Admin> listofadmin = new List<Admin>();
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                Admin a = new Admin()
                {
                    Email = reader.GetString(0)
                };
                listofadmin.Add(a);
            }
            return listofadmin;
        }
        public Admin detailsemp(string email)
        {
            connectionDB();
            SqlCommand query = new SqlCommand("DetailsEmp", con);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.AddWithValue("@email",email);
            con.Open();
            Admin admin = new Admin();
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {

                admin.Empname = reader.GetString(0);
                admin.Email = reader.GetString(1);
                admin.Password = reader.GetString(2);
                admin.ConatctNo = reader.GetString(3);
                
            }
            return admin;
        }
        public bool deleteemp(String empemail)
        {
            connectionDB();
            SqlCommand query = new SqlCommand("DeleteEmp", con);
            query.CommandType = CommandType.StoredProcedure;
            con.Open();
            query.Parameters.AddWithValue("@email", empemail);
            int i = query.ExecuteNonQuery();
            con.Close();
            if (i >= 1) return true;

            return false;
        }

        public bool createemp(Admin a)
        {
            connectionDB();
            SqlCommand query = new SqlCommand("CreateEmp", con);
            query.CommandType = CommandType.StoredProcedure;
            con.Open();
            query.Parameters.AddWithValue("@empname", a.Empname);
            query.Parameters.AddWithValue("@email", a.Email);
            query.Parameters.AddWithValue("@emppassword", a.Password);
            query.Parameters.AddWithValue("@empcontact", a.ConatctNo);
            int i = query.ExecuteNonQuery();
            con.Close();
            if (i >= 1) return true;

            return false;
        }

        }
}