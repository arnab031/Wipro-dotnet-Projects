using System.Data.SqlClient;
// See https://aka.ms/new-console-template for more information


string cs = "Server=tcp:arnab-server01.database.windows.net,1433;Initial Catalog=EmployeeDB;Persist Security Info=False;User ID=arnab-admin;Password=Mycompany123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
SqlConnection cn = new SqlConnection(cs);
cn.Open();
//Console.WriteLine("Connection established successfully to sqlserver in azure");
string query = "select * from tblEmployees";
SqlCommand cmd = new SqlCommand(query, cn);
SqlDataReader dr = cmd.ExecuteReader();
while (dr.Read())
{
    Console.WriteLine($"{dr[0].ToString()} {dr[1].ToString()} {dr[2].ToString()} {dr[3].ToString()}");
}


