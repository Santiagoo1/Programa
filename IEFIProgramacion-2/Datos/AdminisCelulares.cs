using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Datos
{
    public class AdminisCelulares : CadenaConexion
    {
        public int abmCelulares(string accion, Celular objCelular)
        {
            {
                int resultado = -1;
                string orden = string.Empty;

                if (accion == "Alta")
                    //orden = "insert into Celulares values (" + objCelular.p_id+",'"+ objCelular.P_Marca + ",'" + objCelular.p_Modelo + ", " + objCelular.P_Repacion + "', " + 
                    //    objCelular.P_Estado + "', " + objCelular.P_Dni_Tecnico + "', " +
                    //    objCelular.P_FechaIngreso + "', " + objCelular.P_FechaEgreso + "); ";
                    orden = $"insert into Celulares values ({objCelular.p_id},'{objCelular.P_Marca}','{objCelular.p_Modelo}','{objCelular.P_Repacion}','{objCelular.P_Estado}',{objCelular.P_Dni_Tecnico},{objCelular.P_Costo_total},'{objCelular.P_FechaIngreso}','{objCelular.P_FechaEgreso}' );";


//                CodCeular int primary key, 
//Marca varchar(50), 
//Modelo varchar(50), 
//Reparacion varchar(50), 
//Estado varchar(50), 
//Dni_Tecnico int,
//Costo_total int,
//FechaIngreso varchar(50),
//FechaEgreso varchar(50) 


                if (accion == "Modificar")
                    orden = "update Celulares set CodCelular='"+objCelular.p_id+"Marca= " + objCelular.P_Marca + " Modelo= " + objCelular.p_Modelo+ "Reparacion= "
                        + objCelular.P_Repacion+ "Estado: "+objCelular.P_Estado 
                        + "Dni_tecnico= "+ objCelular.P_Dni_Tecnico+"costo_total= "+ objCelular.P_Costo_total 
                        + "FechaIngreso= "+ objCelular.P_FechaIngreso+ "FechaEgreso= "+objCelular.P_FechaEgreso +"where Id= " + objCelular.p_id+ "; ";


                if (accion == "Borrar")
                    orden = $"delete from Celulares where CodCeular = {objCelular.p_id};";
                    //orden = "delete into Celulares values (" +objCelular.p_id+ ",'" + objCelular.P_Marca + ",'" + objCelular.p_Modelo + "', " + objCelular.P_Repacion + "', " +
                    //    objCelular.P_Estado + "', " + objCelular.P_Dni_Tecnico + "', " +
                    //    objCelular.P_FechaIngreso + "', " + objCelular.P_FechaEgreso + "',); ";

                
                

                SqlCommand cmd = new SqlCommand(orden, conexion);

                try
                {
                    Abrirconexion();
                  
                    resultado = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Errror al tratar de guardar,borrar o modificar celular", e);
                }
                finally
                {
                    Cerrarconexion();
                    cmd.Dispose();
                }
                return resultado;
            }

        }

        public DataSet listadoCelulares(string cual)
        {
            string orden = string.Empty;


            if (cual != "Todos") 
                orden = "select * from Celulares where CodCelular = " + int.Parse(cual) + ";";
            else
                orden = "select * from Celulares;";


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
                throw new Exception("Error al listar celulares", e);
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

    
