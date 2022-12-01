using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegTecnicos
    { 
        AdminisTecnico DatosObjTecnico = new AdminisTecnico();
        public int abmTecnicos(string accion, Tecnico objTecnico)
        {
            return DatosObjTecnico.abmTecnico (accion, objTecnico);
        }

        public DataSet listadoTecnicos(string cual)
        {
            return DatosObjTecnico.listadoTecnicos(cual);
        }

        public DataSet listadoTecnicos(object value)
        {
            throw new NotImplementedException();
        }
    }
}
