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
        public void UpdateAdgangskode(string email, string adgangskode)
        {
            using (var CMD = new SqlCommand("update Bruger set Adgangskode=@adgangskode where Email=@email", Conn.CreateConnection()))
            {
                CMD.Parameters.AddWithValue("@adgangskode", adgangskode);
                CMD.Parameters.AddWithValue("@email", email);

                CMD.ExecuteNonQuery();
                CMD.Connection.Close();
            }
        }

        public bool UserExist(string email)
        {
            if (GetBy("Email", email).Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Bruger Login(string email, string adgangskode)
        {
            Bruger b = new Bruger();
            Mapper<Bruger> mapper = new Mapper<Bruger>();

            using (var CMD = new SqlCommand("select * from Bruger where Email=@email and Adgangskode=@adgangskode", Conn.CreateConnection()))
            {
                CMD.Parameters.AddWithValue("@email", email);
                CMD.Parameters.AddWithValue("@adgangskode", adgangskode);

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
