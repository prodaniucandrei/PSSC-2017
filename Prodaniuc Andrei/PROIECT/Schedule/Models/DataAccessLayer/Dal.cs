using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTO_s;
using Models.Evenimente;
using Newtonsoft.Json;

namespace Models.DataAccessLayer
{
    public class Dal
    {
        private readonly string connString = "Server=tcp:irrigationserver.database.windows.net,1433;Initial Catalog=Irrigation;Persist Security Info=False;User ID=aprodaniuc;Password=P@ssw0rd123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public Guid LogareUtilizator(UtilizatorDto utilizatorDto)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Schedule.UserLogin", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var email = new SqlParameter("Email", utilizatorDto.Email);
                    cmd.Parameters.Add(email);

                    var pass = new SqlParameter("Password", utilizatorDto.Password);
                    cmd.Parameters.Add(pass);

                    conn.Open();
                    var result = cmd.ExecuteReader();

                    if (result.Read())
                    {
                        return Guid.Parse(result["Id"].ToString());
                    }
                    else
                    {
                        return Guid.Empty;
                    }
                }
            }
        }
        public void SalvareEvenimente(ReadOnlyCollection<Eveniment> evenimenteNoi)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Schedule.AddEvent", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var data = new SqlParameter("Data", JsonConvert.SerializeObject(evenimenteNoi.FirstOrDefault()));
                    cmd.Parameters.Add(data);

                    conn.Open();
                    var result = cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }

        public void SalvareUtilizator(UtilizatorDto utilizatorDto)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Schedule.AddUser", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var id = new SqlParameter("Id", utilizatorDto.Id);
                    cmd.Parameters.Add(id);

                    var email = new SqlParameter("Email", utilizatorDto.Email);
                    cmd.Parameters.Add(email);

                    var pass = new SqlParameter("Password", utilizatorDto.Password);
                    cmd.Parameters.Add(pass);

                    conn.Open();
                    var result = cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }
    }
}
