using BloodDoner.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BloodDoner.Models
{
    public class ReceiverDBHandler
    {

        private SqlConnection con;

        private void connectionDB()
        {
            con = new SqlConnection("Server=WGIN-DSK-056\\SQL19;Database=BloodBank;Trusted_Connection=True;");
        }
        public List<Receiver> ViewReceivers()
        {
            List<Receiver> receiverslist = new List<Receiver>();

            
            connectionDB();

            SqlCommand query = new SqlCommand("DisplayAllRecievers", con);
            query.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                Receiver r = new Receiver()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Address = reader.GetString(2),
                    City = reader.GetString(3),
                    Refered_by_Hospital = reader.GetString(4),
                    BloodGroup = reader.GetString(5),
                    Quantity = reader.GetInt32(6),
                    Fees = reader.GetDecimal(7),
                    Date = reader.GetDateTime(8),
                    Created_Emp = reader.GetString(9)
                };
                receiverslist.Add(r);
            }
                return receiverslist;
        }
        public Receiver ViewReceiverbyId(int id)
        {
            connectionDB();
            SqlCommand query = new SqlCommand("DisplayRecieversbyId", con);
            query.CommandType = CommandType.StoredProcedure;
            con.Open();
            query.Parameters.AddWithValue("@RId", id);
            Donor d = new Donor();
            Receiver r = new Receiver();
            SqlDataReader reader = query.ExecuteReader();
            if (reader.Read())
            { 
            r.Id = reader.GetInt32(0);
            r.Name = reader.GetString(1);
            r.Address = reader.GetString(2);
            r.City = reader.GetString(3);
            r.Refered_by_Hospital = reader.GetString(4);
            r.BloodGroup = reader.GetString(5);
            r.Quantity = reader.GetInt32(6);
            r.Fees = reader.GetDecimal(7);
            r.Date = reader.GetDateTime(8);
            r.Created_Emp = reader.GetString(9);
                


            }
            return r;
        }
        public bool editreceiver(Receiver r)
        {
            connectionDB();
           
            SqlCommand query = new SqlCommand("EditReciever", con);
            query.CommandType = CommandType.StoredProcedure;
            con.Open();

            query.Parameters.AddWithValue("@RId", r.Id);
            query.Parameters.AddWithValue("@RName", r.Name);
            query.Parameters.AddWithValue("@RAddress",r.Address);
            query.Parameters.AddWithValue("@RCity",r.City);
            query.Parameters.AddWithValue("@Refered_by_Hospital", r.Refered_by_Hospital);
            query.Parameters.AddWithValue("@RBloodGroup", r.BloodGroup);
            query.Parameters.AddWithValue("@Quantity",r.Quantity);
            query.Parameters.AddWithValue("@Fees", r.Fees);
            query.Parameters.AddWithValue("@RDate", r.Date);
            query.Parameters.AddWithValue("@RCreated_Emp", r.Created_Emp);

            int i = query.ExecuteNonQuery();
            con.Close();
            if (i >= 1) return true;
            return false;
        }
       public bool DeleteReceiverbyId(Receiver r)
        {

            connectionDB();

            SqlCommand query = new SqlCommand("DeleteReciever", con);
            query.CommandType = CommandType.StoredProcedure;
            con.Open();
            query.Parameters.AddWithValue("@RId", r.Id);

            int i = query.ExecuteNonQuery();
            con.Close();
            if (i >= 1) return true;
            return false;
        }
        public bool DeleteReceiverbyId2(int id)
        {

            connectionDB();

            SqlCommand query = new SqlCommand("DeleteReciever", con);
            query.CommandType = CommandType.StoredProcedure;
            con.Open();
            query.Parameters.AddWithValue("@RId", id);

            int i = query.ExecuteNonQuery();
            con.Close();
            if (i >= 1) return true;
            return false;
        }
        public bool createReceiver(Receiver r)
        {
            connectionDB();
            SqlCommand query = new SqlCommand("CreateReciever", con);
            query.CommandType = CommandType.StoredProcedure;
            con.Open();
            query.Parameters.AddWithValue("@RName", r.Name);
            query.Parameters.AddWithValue("@RAddress", r.Address);
            query.Parameters.AddWithValue("@RCity", r.City);
            query.Parameters.AddWithValue("@Refered_by_Hospital", r.Refered_by_Hospital);
            query.Parameters.AddWithValue("@RBloodGroup", r.BloodGroup);
            query.Parameters.AddWithValue("@Quantity", r.Quantity);
            query.Parameters.AddWithValue("@Fees",r.Fees);
            query.Parameters.AddWithValue("@RDate",r.Date);
            query.Parameters.AddWithValue("@RCreated_Emp", r.Created_Emp);
            int i = query.ExecuteNonQuery();
            if (i >= 1) return true;
            return false;
        }
    }
}