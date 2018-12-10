using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryProyectoFinal
{
    public class clsPersona
    {
        public int IdPersona { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public int Cedula { get; set; }
        public string Nacionalidad { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string GrupoSanguineo { get; set; }
        public string EstadoCivil { get; set; }
        public string Profesion { get; set; }

        public bool ingresarPersona(string Nombres, string Apellidos, string Genero,
            int Cedula, string Nacionalidad, string Direccion, DateTime FechaNacimiento,
            string GrupoSanguineo, string EstadoCivil, string Profesion)
        {
            var hereda = App.Current as App;
            try
            {
                hereda.connect.Open();

                string sqlIngreso = "insert into tblPersona " +
                    "values(@Nombres, @Apellidos, @Genero, @Cedula, @Nacionalidad, " +
                    "@Direccion, @FechaNacimiento, @GrupoSanguineo, @EstadoCivil, @Profesion)";

                SqlCommand cmd = new SqlCommand(sqlIngreso, hereda.connect);

                cmd.Parameters.Add("@Nombres", SqlDbType.VarChar, 50).Value = Nombres;
                cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 50).Value = Apellidos;
                cmd.Parameters.Add("@Genero", SqlDbType.Char, 1).Value = Genero;
                cmd.Parameters.Add("@Cedula", SqlDbType.Int).Value = Cedula;
                cmd.Parameters.Add("@Nacionalidad", SqlDbType.VarChar, 50).Value = Nacionalidad;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 50).Value = Direccion;
                cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = FechaNacimiento;
                cmd.Parameters.Add("@GrupoSanguineo", SqlDbType.Char, 2).Value = GrupoSanguineo;
                cmd.Parameters.Add("@EstadoCivil", SqlDbType.VarChar, 50).Value = EstadoCivil;
                cmd.Parameters.Add("@Profesion", SqlDbType.VarChar, 50).Value = Profesion;

                cmd.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            finally
            {
                hereda.connect.Close();
            }


        }

        public List<clsPersona> consultarPersona()
        {
            var hereda = App.Current as App;

            List<clsPersona> listaPersonas = new List<clsPersona>();

            hereda.connect.Open();

            string sqlConsultar = "select * from tblPersona";

            SqlCommand cmd = new SqlCommand(sqlConsultar, hereda.connect);

            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                clsPersona person = new clsPersona();

                person.IdPersona = lector.GetInt32(0);
                person.Nombres = lector.GetString(1);
                person.Apellidos = lector.GetString(2);
                person.Genero = lector.GetString(3);
                person.Cedula = lector.GetInt32(4);
                person.Nacionalidad = lector.GetString(5);
                person.Direccion = lector.GetString(6);
                person.FechaNacimiento = lector.GetDateTime(7);
                person.GrupoSanguineo = lector.GetString(8);
                person.EstadoCivil = lector.GetString(9);
                person.Profesion = lector.GetString(10);


                listaPersonas.Add(person);

            }

            hereda.connect.Close();
            return listaPersonas;




        }

        public bool modificarPersona(int idpersona, string Nombres, string Apellidos, string Genero,
            int Cedula, string Nacionalidad, string Direccion, DateTime FechaNacimiento,
            string GrupoSanguineo, string EstadoCivil, string Profesion)
        {
            var hereda = App.Current as App;

            try
            {
                hereda.connect.Open();

                string sqlActualiza = "update tblPersona" +
                    " set Nombres=@Nombres, Apellidos=@Apellidos, Genero=@Genero, Cedula=@Cedula, Nacionalidad=@Nacionalidad, " +
                    "Direccion=@Direccion, FechaNacimiento=@FechaNacimiento, GrupoSanguineo=@GrupoSanguineo, " +
                    "EstadoCivil=@EstadoCivil, Profesion=@Profesion where idpersona=@IdPersona";

                SqlCommand cmd = new SqlCommand(sqlActualiza, hereda.connect);
                cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@Nombres", SqlDbType.VarChar, 50).Value = Nombres;
                cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 50).Value = Apellidos;
                cmd.Parameters.Add("@Genero", SqlDbType.Char, 1).Value = Genero;
                cmd.Parameters.Add("@Cedula", SqlDbType.Int).Value = Cedula;
                cmd.Parameters.Add("@Nacionalidad", SqlDbType.VarChar, 50).Value = Nacionalidad;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 50).Value = Direccion;
                cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = FechaNacimiento;
                cmd.Parameters.Add("@GrupoSanguineo", SqlDbType.Char, 2).Value = GrupoSanguineo;
                cmd.Parameters.Add("@EstadoCivil", SqlDbType.VarChar, 50).Value = EstadoCivil;
                cmd.Parameters.Add("@Profesion", SqlDbType.VarChar, 50).Value = Profesion;

                cmd.ExecuteNonQuery();



                return true;

            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            finally
            {
                hereda.connect.Close();
            }

        }

        public bool eliminarPersona(int idpersona)
        {
            var hereda = App.Current as App;

            try
            {
                hereda.connect.Open();

                string sqlElimina = "delete from tblPersona where idpersona=@IdPersona";

                SqlCommand cmd = new SqlCommand(sqlElimina, hereda.connect);

                cmd.Parameters.Add("@IdPersona", SqlDbType.Int, 4).Value = idpersona;

                cmd.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            finally
            {
                hereda.connect.Close();
            }

        }
    }
}
