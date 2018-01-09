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
using Models.Comenzi;

namespace Models.DataAccessLayer
{
    public class Dal
    {
        private readonly string connString = "Server=tcp:irrigationserver.database.windows.net,1433;Initial Catalog=Irrigation;Persist Security Info=False;User ID=aprodaniuc;Password=P@ssw0rd123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public UserLogged LogareUtilizator(UtilizatorDto utilizatorDto)
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
                        return new UserLogged() { Id = Guid.Parse(result["Id"].ToString()), IsSetUp = bool.Parse(result["IsSetup"].ToString()) };
                    }
                    else
                    {
                        return new UserLogged();
                    }
                }
            }
        }

        public void ActualizeazaOrar(OrarDto orar)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Schedule.UpdateSchedule", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var id = new SqlParameter("Id", orar.Id);
                    cmd.Parameters.Add(id);

                    var data = new SqlParameter("Data", JsonConvert.SerializeObject(orar.Materii));
                    cmd.Parameters.Add(data);

                    conn.Open();
                    var result = cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }

        public OrarDto GasesteOrar(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Schedule.FindScheduleById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var Id = new SqlParameter("Id", id.ToString());
                    cmd.Parameters.Add(Id);

                    conn.Open();
                    var result = cmd.ExecuteReader();
                    OrarDto orar = new OrarDto();
                    while (result.Read())
                    {
                        var Data = JsonConvert.DeserializeObject<List<MaterieDto>>(result["Data"].ToString());
                        orar.Id = Guid.Parse(result["Id"].ToString());
                        var Sectia = result["Sectia"].ToString();
                        orar.Sectie = Sectia;
                        orar.Materii = Data;
                    }

                    conn.Close();
                    return orar;

                }
            }
        }

        internal List<Eveniment> IncarcaListaEvenimente()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Schedule.LoadEvents", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    var result = cmd.ExecuteReader();
                    List<Eveniment> evenimente = new List<Eveniment>();
                    while (result.Read())
                    {
                        var e = JsonConvert.DeserializeObject<Eveniment>(result["Data"].ToString());
                        evenimente.Add(e);
                    }

                    conn.Close();
                    return evenimente;

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

                    var data = new SqlParameter("Data", JsonConvert.SerializeObject(evenimenteNoi.LastOrDefault()));
                    cmd.Parameters.Add(data);

                    conn.Open();
                    var result = cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }

        public OrarDto AdaugareOrar(OrarDto orarDto)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Schedule.AddSchedule", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var id = new SqlParameter("Id", orarDto.Id);
                    cmd.Parameters.Add(id);

                    var sectie = new SqlParameter("Sectia", orarDto.Sectie);
                    cmd.Parameters.Add(sectie);

                    var data = new SqlParameter("Data", JsonConvert.SerializeObject(orarDto.Materii));
                    cmd.Parameters.Add(data);

                    conn.Open();
                    var result = cmd.ExecuteNonQuery();

                    conn.Close();
                    return orarDto;
                }
            }
        }

        public OrarDto OrarNotExists(OrarDto orarDto)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Schedule.FindSchedule", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var sectia = new SqlParameter("Sectia", orarDto.Sectie);
                    cmd.Parameters.Add(sectia);

                    conn.Open();
                    var result = cmd.ExecuteReader();
                    OrarDto orar = new OrarDto();
                    while (result.Read())
                    {
                        var Data = JsonConvert.DeserializeObject<List<MaterieDto>>(result["Data"].ToString());
                        var Id = result["Id"].ToString();
                        var Sectia = result["Sectia"].ToString();
                        orar.Id = Guid.Parse(Id);
                        orar.Sectie = Sectia;
                        orar.Materii = Data;
                    }

                    conn.Close();
                    return orar;

                }
            }
        }

        internal void SalvareStudent(StudentDto studentDto)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Schedule.AddStudent", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var id = new SqlParameter("Id", studentDto.Id);
                    cmd.Parameters.Add(id);

                    var data = new SqlParameter("Data", JsonConvert.SerializeObject(studentDto));
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
