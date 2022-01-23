using BloodDoner.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BloodDoner.Models
{
    public class DonorDBHandler
    {
        private SqlConnection con;

        private void connectionDB()
        {
            con = new SqlConnection("Server=WGIN-DSK-056\\SQL19;Database=BloodBank;Trusted_Connection=True;");
        }
        public List<Donor> getlistofdonor()
        {
            List<Donor> donorslist = new List<Donor>();
            connectionDB();
            SqlCommand query = new SqlCommand("DisplayAllDonors", con);
            query.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                Donor d = new Donor()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Address = reader.GetString(2),
                    City = reader.GetString(3),
                    Age = reader.GetInt32(4),
                    Gender = reader.GetString(5),
                    BloodGroup = reader.GetString(6),
                    Date = reader.GetDateTime(7),
                    Created_Emp = reader.GetString(8)
                };
                donorslist.Add(d);
            }
            con.Close();
            return donorslist;


        }
         int id;
        public Donor viewEdit(int id)
        {
            connectionDB();
            SqlCommand query = new SqlCommand("DisplayDonorsbyId", con);
            query.CommandType = CommandType.StoredProcedure;
            con.Open();
            query.Parameters.AddWithValue("@DId", id);
            Donor d = new Donor();
            SqlDataReader reader = query.ExecuteReader();
            if (reader.Read())
            {


                d.Id = reader.GetInt32(0);
                d.Name = reader.GetString(1);
                d.Address = reader.GetString(2);
                d.City = reader.GetString(3);
                d.Age = reader.GetInt32(4);
                d.Gender = reader.GetString(5);
                d.BloodGroup = reader.GetString(6);
                d.Date = reader.GetDateTime(7);
                d.Created_Emp = reader.GetString(8);
                
               
            }
            d.Id = id;
            return d;



        }
       
        public bool editpost(Donor d)
        {
            connectionDB();
            SqlCommand query = new SqlCommand("EditDonor", con);
            query.CommandType = CommandType.StoredProcedure;
            con.Open();
            query.Parameters.AddWithValue("@DId", d.Id);
            query.Parameters.AddWithValue("@DName", d.Name);
            query.Parameters.AddWithValue("@DAddress", d.Address);
            query.Parameters.AddWithValue("@DCity", d.City);
            query.Parameters.AddWithValue("@DAge", d.Age);
            query.Parameters.AddWithValue("@DGender", d.Gender);
            query.Parameters.AddWithValue("@DBloodGroup", d.BloodGroup);
            query.Parameters.AddWithValue("@DDate", d.Date);
            query.Parameters.AddWithValue("@Created_Emp", d.Created_Emp);
            int i = query.ExecuteNonQuery();
            con.Close();
            if (i >= 1) return true;
            return false;

        }
        public bool deletedonor(int id)
        {

            connectionDB();
            SqlCommand query = new SqlCommand("DeleteDonor", con);
            query.CommandType = CommandType.StoredProcedure;
            con.Open();
            query.Parameters.AddWithValue("@DId", id);
           
            int i = query.ExecuteNonQuery();
            con.Close();
            if (i >= 1) return true;
            return false;
        }
        public bool createDonor(Donor d)
        {
            connectionDB();
            SqlCommand query = new SqlCommand("CreateDonor", con);
            query.CommandType = CommandType.StoredProcedure;
            con.Open();
            query.Parameters.AddWithValue("@DName",d.Name);
            query.Parameters.AddWithValue("@DAddress",d.Address);
            query.Parameters.AddWithValue("@DCity",d.City);
            query.Parameters.AddWithValue("@DAge",d.Age);
            query.Parameters.AddWithValue("@DGender",d.Gender);
            query.Parameters.AddWithValue("@DBloodGroup",d.BloodGroup);
            query.Parameters.AddWithValue("@DDate",d.Date);
            query.Parameters.AddWithValue("@Created_Emp", d.Created_Emp);
            int i=query.ExecuteNonQuery();
            if (i >= 1) return true;
            return false;
        }
        public List<Donor> displayblood(Blood b)
        {
            List<Donor> listofdonor = new List<Donor>();
            connectionDB();
            SqlCommand query = new SqlCommand("SearchBlood", con);
            query.CommandType = CommandType.StoredProcedure;
            con.Open();
            query.Parameters.AddWithValue("@bloodgroup", b.blood);
            SqlDataReader reader = query.ExecuteReader();

            while(reader.Read())
            {
                Donor d = new Donor()
                {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Address = reader.GetString(2),
                City = reader.GetString(3),
                Age = reader.GetInt32(4),
                Gender = reader.GetString(5),
                BloodGroup = reader.GetString(6),
                Date = reader.GetDateTime(7),
                Created_Emp = reader.GetString(8)
                 };
                listofdonor.Add(d);
            }
            con.Close();
            return listofdonor;

        }
    }
}