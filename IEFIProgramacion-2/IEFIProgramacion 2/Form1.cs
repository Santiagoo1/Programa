using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEFIProgramacion_2
{
    public partial class Form1 : Form
    {
        Celular nuevoIngreso;
        Celular Cargado; 
        NegProfesionalCelular objNegCelular = new NegProfesionalCelular();

        Tecnico NuevoTecnico;
        Tecnico CargarTecnico; 
        NegTecnicos objNegTecnicos = new NegTecnicos();
        bool nuevo = true;
        int fila; 
        public Form1()
        {
            InitializeComponent();
            CrearDgvC();
            LlenarDgvC();
        }

        private void LlenarDgvC()
        {
            dgvCelular.Rows.Clear(); 
            DataSet ds = new DataSet();

            ds = objNegCelular.ListadoCelulares("Todos"); 
            if(ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvCelular.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], 
                        dr[4].ToString(), dr[5].ToString(),
                        dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                }
            }
            else
            {
                MessageBox.Show("No hay datos cargados en el sistema");
            }
        }

        private void CrearDgvC()
        {
            dgvCelular.Columns.Add("0", "Id");
            dgvCelular.Columns.Add("1", "Marca");
            dgvCelular.Columns.Add("2", "Modelo");
            dgvCelular.Columns.Add("3", "Reparacion");
            dgvCelular.Columns.Add("4", "Estado");
            dgvCelular.Columns.Add("5", "DNI_Tecnico");
            dgvCelular.Columns.Add("6", "Costo_}total");
            dgvCelular.Columns.Add("7", "Fecha_Ingreso");
            dgvCelular.Columns.Add("8", "Fecha_Egreso");


            dgvCelular.Columns[0].Width = 100;
            dgvCelular.Columns[1].Width = 100;
            dgvCelular.Columns[2].Width = 100;
            dgvCelular.Columns[3].Width = 100;
            dgvCelular.Columns[4].Width = 100;
            dgvCelular.Columns[5].Width = 100;
            dgvCelular.Columns[6].Width = 100;
            dgvCelular.Columns[7].Width = 100;
            dgvCelular.Columns[8].Width = 100;




        }

        private void LlenarDgvT()
        {
            dgvTecnico.Rows.Clear();
            DataSet ds = new DataSet();

            ds = objNegTecnicos.listadoTecnicos("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvTecnico.Rows.Add(dr[0].ToString(), dr[1], dr[2]);
                }
            }    
            else
            {
                MessageBox.Show("No hay datos cargados en el sistema");
            }
        }

        private void CrearDgvT()
        {
            dgvTecnico.Columns.Add("0", "DNI");
            dgvTecnico.Columns.Add("1", "Nombre");
            dgvTecnico.Columns.Add("2", "Apellido");
          


            dgvTecnico.Columns[0].Width = 100;
            dgvTecnico.Columns[1].Width = 100;
            dgvTecnico.Columns[2].Width = 100;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbEstado.Items.Add("Pendiente");
            cbEstado.Items.Add("Listo");

            cbTecnico.Items.Add("44475358"); 

        }

        private void btCargarCelular_Click(object sender, EventArgs e)
        {
            int nGrabados = -1;

            nuevoIngreso = new Celular(int.Parse(txtCodigo.Text),txtMarca.Text, txtModelo.Text,
                txtReparacion.Text, cbEstado.Text, int.Parse(cbTecnico.Text),
int.Parse(txtCostoTotal.Text), txtFechaIngreso.Text, txtFechaEgreso.Text);

            nGrabados = objNegCelular.abmCelulares("Alta", nuevoIngreso); 

            if(nGrabados == -1)
            {
                MessageBox.Show("No se pudo grabar la informacion en el sistema");
            } 
            else
            {
                txtCodigo.Text  = nuevoIngreso.p_id.ToString();
                txtMarca.Text = nuevoIngreso.P_Marca;
                txtModelo.Text = nuevoIngreso.p_Modelo;
                txtReparacion.Text = nuevoIngreso.P_Repacion;
                cbEstado.Text = nuevoIngreso.P_Estado;
                cbTecnico.Text = nuevoIngreso.P_Dni_Tecnico.ToString();
                txtCostoTotal.Text = nuevoIngreso.P_Costo_total.ToString();
                txtFechaIngreso.Text = nuevoIngreso.P_FechaIngreso;
                txtFechaEgreso.Text = nuevoIngreso.P_FechaEgreso;

               


                LlevarProdAldgv(nuevoIngreso);
                nuevo = true;

                void LlevarProdAldgv(Celular cel)
                {
                    dgvCelular.Rows.Add(cel.p_id,cel.P_Marca,
                    cel.p_Modelo, cel.P_Repacion, cel.P_Estado, cel.P_Estado,cel.P_Dni_Tecnico, cel.P_Dni_Tecnico
                    ,cel.P_Costo_total.ToString(), cel.P_FechaIngreso, cel.P_FechaEgreso);
                    fila = (dgvCelular.Rows.Count - 1);
                }



            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (nuevo == false) 
            {

                if (rdIngreso.Checked == true)
                {
                    Cargado.ingreso(cbEstado.SelectedItem.ToString());
                }
                if (rdEgreso.Checked == true)
                {
                    Cargado.Egreso(cbEstado.SelectedItem.ToString());
                }
             
                int nResultado = -1;
                nResultado = objNegCelular.abmCelulares("Modificar", Cargado);

                if (nResultado != -1)
                {
                    LlenarDgvC();
                    LlenarDgvT();
                }
                else
                    MessageBox.Show("Error", "Se produjo error al insertar modificar al producto");
            }
            else //si es nuevo entra por aca
            {
                if (rdIngreso.Checked == true)
                {
                    nuevoIngreso.ingreso(cbEstado.SelectedItem.ToString());
                }
                if (rdEgreso.Checked == true)
                {
                    nuevoIngreso.Egreso(cbEstado.SelectedItem.ToString());
                }
                // LlevarProdAldgv(NuevoProducto, fila);
                int nResultado = -1;
                nResultado = objNegCelular.abmCelulares("Modificar", nuevoIngreso);

                if (nResultado != -1)
                {
                    LlenarDgvC();
                }
                else

                    MessageBox.Show("Error", "Se produjo error al insertar modificar al producto");
            }
            
            void LlevarProdAldgv(Celular Cel, int lugar)
            {
                dgvCelular[0, lugar].Value = Cel.p_id;
                dgvCelular[1, lugar].Value = Cel.P_Marca;
                dgvCelular[2, lugar].Value = Cel.p_Modelo;
                dgvCelular[3, lugar].Value = Cel.P_Repacion;
                dgvCelular[4, lugar].Value = Cel.P_Estado;
                dgvCelular[5, lugar].Value = Cel.P_Dni_Tecnico;
                dgvCelular[6, lugar].Value = Cel.P_Costo_total;
                dgvCelular[7, lugar].Value = Cel.P_FechaIngreso;
                dgvCelular[8, lugar].Value = Cel.P_FechaEgreso;
            
            }
        }

        private void dgvCelular_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cargado = new Celular(Convert.ToInt32(dgvCelular.CurrentRow.Cells[0].Value),
               dgvCelular.CurrentRow.Cells[1].Value.ToString(), dgvCelular.CurrentRow.Cells[2].Value.ToString(), 
               dgvCelular.CurrentRow.Cells[3].Value.ToString(), dgvCelular.CurrentRow.Cells[4].Value.ToString(),
               Convert.ToInt32( dgvCelular.CurrentRow.Cells[5].Value), Convert.ToInt32(dgvCelular.CurrentRow.Cells[6].Value),
                 dgvCelular.CurrentRow.Cells[7].Value.ToString(), dgvCelular.CurrentRow.Cells[8].Value.ToString());
            nuevo = false;
            DataSet ds = new DataSet();

            ds = objNegCelular.ListadoCelulares(nuevoIngreso.p_id.ToString()); //busco uno en particular
            if (ds.Tables[0].Rows.Count > 0)
            {
                Ds_a_Controles(ds);
            }
        }
        private void Ds_a_Controles(DataSet ds)
        {
            txtCodigo.Text = ds.Tables[0].Rows[0]["CodCelular"].ToString();
            txtMarca.Text = ds.Tables[0].Rows[0]["Marca"].ToString();
            txtModelo.Text = ds.Tables[0].Rows[0]["Modelo"].ToString();
            //lbl_StockMov.Text = ds.Tables[0].Rows[0]["stock"].ToString() + "unidades";
            txtReparacion.Text = ds.Tables[0].Rows[0]["Reparacion"].ToString();
            txtCostoTotal.Text = ds.Tables[0].Rows[0]["Costo Total"].ToString();
            txtFechaIngreso.Text = ds.Tables[0].Rows[0]["Fecha Ingreso"].ToString();
            txtFechaEgreso.Text = ds.Tables[0].Rows[0]["Fecha Egreso"].ToString();

        }

        private void btCargarCelular_Click_1(object sender, EventArgs e)
        {
            int nGrabados = -1;

            nuevoIngreso = new Celular(int.Parse(txtCodigo.Text), txtMarca.Text, txtModelo.Text,
                txtReparacion.Text, cbEstado.Text, int.Parse(cbTecnico.Text),
int.Parse(txtCostoTotal.Text), txtFechaIngreso.Text, txtFechaEgreso.Text);

            nGrabados = objNegCelular.abmCelulares("Alta", nuevoIngreso);

            if (nGrabados == -1)
            {
                MessageBox.Show("No se pudo grabar la informacion en el sistema");
            }
            else
            {
                txtCodigo.Text = nuevoIngreso.p_id.ToString();
                txtMarca.Text = nuevoIngreso.P_Marca;
                txtModelo.Text = nuevoIngreso.p_Modelo;
                txtReparacion.Text = nuevoIngreso.P_Repacion;
                cbEstado.Text = nuevoIngreso.P_Estado;
                cbTecnico.Text = nuevoIngreso.P_Dni_Tecnico.ToString();
                txtCostoTotal.Text = nuevoIngreso.P_Costo_total.ToString();
                txtFechaIngreso.Text = nuevoIngreso.P_FechaIngreso;
                txtFechaEgreso.Text = nuevoIngreso.P_FechaEgreso;




                LlevarProdAldgv(nuevoIngreso);
                nuevo = true;

                void LlevarProdAldgv(Celular cel)
                {
                    dgvCelular.Rows.Add(cel.p_id, cel.P_Marca,
                    cel.p_Modelo, cel.P_Repacion, cel.P_Estado, cel.P_Estado, cel.P_Dni_Tecnico, cel.P_Dni_Tecnico
                    , cel.P_Costo_total.ToString(), cel.P_FechaIngreso, cel.P_FechaEgreso);
                    fila = (dgvCelular.Rows.Count - 1);
                }



            }
        }
    }
    
}
