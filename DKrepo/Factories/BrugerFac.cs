using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DKrepo
{
    public class BrugerFac: AutoFac<Bruger>
    {
        public void UpdateAdgangskode(string Email, string Adgangskode)
        {
            using (var CMD = new SqlCommand("update Bruger set Adgangskode=@adgangskode where Email=@email", Conn.CreateConnection()))
            {
                CMD.Parameters.AddWithValue("@adgangskode", Adgangskode);
                CMD.Parameters.AddWithValue("@email", Email);

                CMD.ExecuteNonQuery();
                CMD.Connection.Close();
            }
        }

        public bool UserExist(string Email)
        {
            if (GetBy("Email", Email).Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Bruger Login(string Email, string Adgangskode)
        {
            Bruger b = new Bruger();
            Mapper<Bruger> mapper = new Mapper<Bruger>();

            using (var CMD = new SqlCommand("select * from Bruger where Email=@email and Adgangskode=@adgangskode", Conn.CreateConnection()))
            {
                CMD.Parameters.AddWithValue("@email", Email);
                CMD.Parameters.AddWithValue("@adgangskode", Adgangskode);

                var r = CMD.ExecuteReader();

                if (r.Read())
                {
                    b = mapper.Map(r);
                }
            }

            return b;
        }
    }
}
