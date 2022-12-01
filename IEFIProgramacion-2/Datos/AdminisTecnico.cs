using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class AdminisTecnico : CadenaConexion
    {
        public int abmTecnico(string accion, Tecnico ObjTecnico)
        {
            {
                int resultado = -1;//controlar que se realice la operacion con exito
                string orden = string.Empty;//para guardar consulta


                if (accion == "Alta")
                    orden = "insert into Producto values (" + ObjTecnico.P_Dni + ",'" + ObjTecnico.p_Nombre + "', " + ObjTecnico.p_Apellido + "); ";



                if (accion == "Borrar")
                    orden = "delete into Producto values (" + ObjTecnico.P_Dni + ",'" + ObjTecnico.p_Nombre +",' "+ ObjTecnico.p_Apellido + ",); ";

                SqlCommand cmd = new SqlCommand(orden, conexion);

                try
                {
                    Abrirconexion();
                    //EJECUTA ALGO ME DEVUELVE LAS FILAS Q SE GUARDAN EN LA VARIABLE RESULTADO
                    resultado = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Errror al tratar de guardar,borrar o modificar Tecnico", e);
                }
                finally
                {
                    Cerrarconexion();
                    cmd.Dispose();
                }
                return resultado;
            }

        }

        public DataSet listadoTecnicos(string cual)//para uno o todos los dato segun el codigo
        {
            string orden = string.Empty;


            if (cual != "Todos") //entonces me va devolver un solo valor 
                orden = "select * from Tecnicos where DNI = " + int.Parse(cual) + ";";
            else
                orden = "select * from Tecnicos;";


            SqlCommand cmd = new SqlCommand(orden, conexion);

            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter();


            try
            {
                Abrirconexion();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar Tecnicos", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }


    }
}

