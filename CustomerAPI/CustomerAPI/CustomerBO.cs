using System;
using System.Data.SqlClient;

namespace CustomerAPI
{
	public class CustomerBO
	{
		SqlConnection  ConnectToDB()
        {
			string cs = "server = localhost; Database = CustomerDB; User = sa; Password = Arnab@123";
			SqlConnection cn = new SqlConnection(cs);
			cn.Open();
			return cn;

		}
		public List<CustomerModel> GetCustomers()
        {
			string query = "select * from tblCustomers";
			SqlCommand cmd = new SqlCommand(query, ConnectToDB());
            SqlDataReader dr = cmd.ExecuteReader();
            List<CustomerModel> customers = new List<CustomerModel>();
            while (dr.Read())
            {
                CustomerModel c = new CustomerModel();
                c.Id = Convert.ToInt32(dr[0]);
                c.CName = dr[1].ToString();
                c.MobileNumber = dr[1].ToString();
                c.City = dr[2].ToString();
                customers.Add(c);
            }
            return customers;
        }

        public CustomerModel GetCustomerById(int id)
        {
            string query = "select * from tblCustomers where id=@id";
            SqlCommand cmd = new SqlCommand(query, ConnectToDB());
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            CustomerModel c = new CustomerModel();
            if (dr.Read())
            {
                c.Id = Convert.ToInt32(dr[0]);
                c.CName = dr[1].ToString();
                c.MobileNumber = dr[2].ToString();
                c.City = dr[3].ToString();
            }
            return c;
        }

        public int AddCustomer(CustomerModel c)
        {
            string query = "insert into tblCustomers values (@id, @cname, @mobilenumber, @city)";
            SqlCommand cmd = new SqlCommand(query, ConnectToDB());
            cmd.Parameters.AddWithValue("@id", c.Id);
            cmd.Parameters.AddWithValue("@cname", c.CName);
            cmd.Parameters.AddWithValue("@mobilenumber", c.MobileNumber);
            cmd.Parameters.AddWithValue("@city", c.City);
            return cmd.ExecuteNonQuery();
        }

        public int EditCustomerById(int id, CustomerModel c)
        {
            string query = "update tblCustomers set cname= @cname,mobilenumber= @mobilenumber, city=@city where id=@id";
            SqlCommand cmd = new SqlCommand(query, ConnectToDB());
            cmd.Parameters.AddWithValue("@id", c.Id);
            cmd.Parameters.AddWithValue("@cname", c.CName);
            cmd.Parameters.AddWithValue("@mobilenumber", c.MobileNumber);
            cmd.Parameters.AddWithValue("@city", c.City);
            return cmd.ExecuteNonQuery();
        }
        public int DeleteCustomerById(int id)
        {
            string query = "delete tblCustomers where id=@id";
            SqlCommand cmd = new SqlCommand(query, ConnectToDB());
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }


    }
}

