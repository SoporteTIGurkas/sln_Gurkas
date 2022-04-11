using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl_Gurkas.Datos
{
  
   class AuditoriaModulos
    {
        Datos.Conexiondbo conexion = new Datos.Conexiondbo();
        public void auditoria(string moduloPrincipal , string ModuloSegundario,string ModuloTercero,string ModuloCuarto)
        {
            string hora = DateTime.Now.ToString("hh:mm:ss tt");
            string _nombre = Datos.DatosUsuario._usuario;
            SqlCommand comando2 = new SqlCommand("sp_insertarHistorialModulo", conexion.conexionBD());
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.Parameters.AddWithValue("@Usuario", _nombre);
            comando2.Parameters.AddWithValue("@Modulo", moduloPrincipal);
            comando2.Parameters.AddWithValue("@hora ", hora);
            comando2.ExecuteNonQuery();
        }
        
    }
}
