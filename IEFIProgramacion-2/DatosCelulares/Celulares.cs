using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.sq

namespace DatosCelulares
{
    public class Celulares
    {
        #region Atributos
        private int IdCelular;
        private string Marca;
        private string Modelo;
        private string Reparacion;
        private bool Estado;
        private long Dni_Tecnico;
        private int Costo_total;
        private DateTime FechaIngreso;
        private DateTime FechaEgreso;
        #endregion

        #region Propiedades
        public string P_Marca
        {
            set { Marca = value; }
            get { return Marca; }
        } 

        public string  p_Modelo
        {
            set { Modelo = value; }
            get { return Modelo; }
        }

        public string P_Repacion
        { 
            set { Reparacion = value; } 
            get { return Reparacion; }

        }

        public bool P_Estado
        {
            set { Estado = value; } 
            get { return Estado; }
        } 

        public long P_Dni_Tecnico
        {
             set { Dni_Tecnico = value;}
            get { return Dni_Tecnico;}
        }

        public int P_Costo_total
        {

            set { Costo_total = value; }
            get { return Costo_total; }
        }

        public DateTime P_FechaIngreso
        {
            set { FechaIngreso = value;}
            get { return FechaIngreso; }
        } 

        public DateTime P_FechaEgreso
        {
            set { FechaEgreso = value;}
            get { return FechaEgreso; }
        }
        #endregion

        #region Constructor
        public Celulares (string marca, string modelo, string reparacion, bool estado, 
            long tecnico, int costoTotal, DateTime FechaI, DateTime FechaE)
        {
            Marca = marca; 
            Modelo = modelo;
            Reparacion = reparacion; 
            Estado = estado;
            Dni_Tecnico = tecnico;
            Costo_total = costoTotal;
            FechaIngreso = FechaI;
            FechaEgreso = FechaE; 
        }
        #endregion  

    }
}
