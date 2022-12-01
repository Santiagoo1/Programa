using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class Tecnico
    {


        private int Dni_Tecnico;

        private string Nombre;

      private string Apellido;


        public int P_Dni
        {
            get { return Dni_Tecnico; }
            set { Dni_Tecnico = value;}
        }

        public string p_Nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string p_Apellido
        {
            get { return Apellido; }
            set { Apellido = value; }
        } 


        public Tecnico (int DNI, string nombre, string apellido)
        {
            Dni_Tecnico= DNI;
            Nombre = nombre;
            Apellido = apellido;
        }
    }
}
