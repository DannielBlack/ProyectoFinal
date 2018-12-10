using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryProyectoFinal
{
    public class clsSalario
    {
        public int IdSalario { get; set; }
        public string Persona { get; set; }
        public decimal Valor { get; set; }
        public char Tipo { get; set; }
        public string Denominacion { get; set; }
        public decimal Impuestos { get; set; }

        public bool ingresarSalario(string Persona, decimal Valor, char Tipo,
            string Denominacion, decimal Impuestos)
        {
            var hereda = App.Current as App;
            try
            {
                hereda.connect.Open();

                string sqlIngreso = "insert into tblSalario " +
                    "values(@Persona, @Valor, @Tipo, @Denominacion, @Impuestos)";

                SqlCommand cmd = new SqlCommand(sqlIngreso, hereda.connect);

                cmd.Parameters.Add("@Persona", SqlDbType.VarChar, 50).Value = Persona;
                cmd.Parameters.Add("@Valor", SqlDbType.Decimal).Value = Valor;
                cmd.Parameters.Add("@Tipo", SqlDbType.Char, 2).Value = Tipo;
                cmd.Parameters.Add("@Denominacion", SqlDbType.VarChar, 50).Value = Denominacion;
                cmd.Parameters.Add("@Impuestos", SqlDbType.Decimal).Value = Impuestos;
                
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

        public List<clsSalario> consultarSalario()
        {
            var hereda = App.Current as App;

            List<clsSalario> listaSalario = new List<clsSalario>();

            hereda.connect.Open();

            string sqlConsultar = "select * from tblSalario";

            SqlCommand cmd = new SqlCommand(sqlConsultar, hereda.connect);

            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                clsSalario person = new clsSalario();

                person.IdSalario = lector.GetInt32(0);
                person.Persona = lector.GetString(1);
                person.Valor = lector.GetDecimal(2);
                person.Tipo = lector.GetString(3);
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

                cmd.Parameters.Add("@Nombres", SqlDbType.VarChar, 50).Value = Nombres;
                cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 50).Value = Apellidos;
                cmd.Parameters.Add("@Genero", SqlDbType.VarChar, 50).Value = Genero;
                cmd.Parameters.Add("@Cedula", SqlDbType.Int, 4).Value = Cedula;
                cmd.Parameters.Add("@Nacionalidad", SqlDbType.VarChar, 50).Value = Nacionalidad;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 50).Value = Direccion;
                cmd.Parameters.Add("@FechaNacimiento", SqlDbType.VarChar, 50).Value = FechaNacimiento;
                cmd.Parameters.Add("@GrupoSanguineo", SqlDbType.VarChar, 50).Value = GrupoSanguineo;
                cmd.Parameters.Add("@EstadoCivil", SqlDbType.VarChar, 50).Value = EstadoCivil;
                cmd.Parameters.Add("@Profesion", SqlDbType.VarChar, 50).Value = Profesion;
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
}
