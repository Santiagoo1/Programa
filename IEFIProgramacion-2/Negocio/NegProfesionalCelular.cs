using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;

namespace Negocio
{
    public class NegProfesionalCelular
    { 
        AdminisCelulares DatosObjCelular = new AdminisCelulares();  



        public int abmCelulares(string accion, Celular objCelular)
        {
            return DatosObjCelular.abmCelulares(accion, objCelular); 
        } 

        public DataSet ListadoCelulares(string cual)
        {
            return DatosObjCelular.listadoCelulares(cual);
        }


        
    }
}
