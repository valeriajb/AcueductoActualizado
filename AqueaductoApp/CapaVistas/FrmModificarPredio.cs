using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AqueaductoApp.CapaVistas
{
    public partial class FrmModificarPredio : Form
    {
        int estado;
        int id;
        int posicion;
        string catastro;
        string estadoPropi;
        string estadoStri;
        int index;
        public FrmModificarPredio()
        {
            InitializeComponent();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            CapaDatos.DataSet1TableAdapters.PREDIOSTableAdapter predioExistencia = new CapaDatos.DataSet1TableAdapters.PREDIOSTableAdapter();
            int predioExist = (int)predioExistencia.validarPredio(this.txtCatastro.Text);

            if (predioExist == 0 || this.txtCatastro.Text==catastro )
            {
                if (this.txtCatastro.Text == "")
                {
                    MessageBox.Show("Digite el Catastro del Predio", "Notificaciòn");
                }
                else
                {
                    if (this.txtCedula.Text == "")
                    {
                        MessageBox.Show("Digite la Cédula del Propietario", "Notificación");
                    }
                    else
                    {
                        if (this.comboBarrio.Text == "")
                        {
                            MessageBox.Show("Digite el Barrio del Predio", "Notificación");
                        }
                        else
                        {
                            if (this.comboEstrato.Text == "")
                            {
                                MessageBox.Show("Digite el Estrato del Predio", "Notificación");
                            }
                            else
                            {
                                if (this.comboEstado.Text == "")
                                {
                                    MessageBox.Show("Digite el Estado del Predio", "Notificación");
                                }
                                else
                                {

                                    int cedula = int.Parse(this.txtCedula.Text);
                                    //Casa
                                    CapaDatos.DataSet1TableAdapters.PREDIOSTableAdapter TPR = new CapaDatos.DataSet1TableAdapters.PREDIOSTableAdapter();
                                    TPR.ModificarPredio(this.txtCatastro.Text, this.txtCedula.Text, int.Parse(this.comboEstrato.Text), int.Parse(this.comboBarrio.Text), estado, id);



                                    //Recargar DataGrid
                                    CapaDatos.DataSet1TableAdapters.PREDIOSTableAdapter Tp = new CapaDatos.DataSet1TableAdapters.PREDIOSTableAdapter();
                                    CapaDatos.DataSet1.PREDIOSDataTable tp = Tp.GetData();
                                    GridPredio.DataSource = tp;

                                    //Mensaje de Modificado Predio, limpia los campos. 
                                    MessageBox.Show("Predio modificado", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.txtCatastro.Text = "";
                                    this.txtCedula.Text = "";

                                }
                            }
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Este predio ya existe, por favor ingrese otro número de catastro");
                this.txtCedula.Focus();
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            //Mensaje Recarga
            if (MessageBox.Show("¿Desea cancelar el proceso?", "Notificación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.txtCedula.Text = "";
                this.txtCatastro.Text = "";
                //Recargar DataGrid
                CapaDatos.DataSet1TableAdapters.PREDIOSTableAdapter Tp = new CapaDatos.DataSet1TableAdapters.PREDIOSTableAdapter();
                CapaDatos.DataSet1.PREDIOSDataTable tp = Tp.GetData();
                GridPredio.DataSource = tp;

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CapaDatos.DataSet1TableAdapters.PREDIOSTableAdapter Tp = new CapaDatos.DataSet1TableAdapters.PREDIOSTableAdapter();
            CapaDatos.DataSet1.PREDIOSDataTable tp = Tp.GetData();
            GridPredio.DataSource = tp;
        }

        private void GridPredio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

         

        }



        private void comboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboEstado.Text == "Activo")
            {
                estado = 1;
            }
            else
            {
                estado = 0;
            }
        }

        private void txtContador_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            //No permite que el Usuario escriba en el campo
            e.Handled = true;
        }

        private void txtCatastro_KeyPress(object sender, KeyPressEventArgs e)
        {
           e.Handled=true;
        }

        private void comboEstrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBarrio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FrmModificarPredio_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.BARRIOS' Puede moverla o quitarla según sea necesario.
            this.bARRIOSTableAdapter1.Fill(this.dataSet1.BARRIOS);
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.ESTRATOS' Puede moverla o quitarla según sea necesario.
            this.eSTRATOSTableAdapter.Fill(this.dataSet1.ESTRATOS);
            // TODO: esta línea de código carga datos en la tabla 'acueductoDataSet.BARRIOS' Puede moverla o quitarla según sea necesario.
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.PREDIOS' Puede moverla o quitarla según sea necesario.
            this.pREDIOSTableAdapter1.Fill(this.dataSet1.PREDIOS);
            // TODO: esta línea de código carga datos en la tabla 'acueductoDataSet.PREDIOS' Puede moverla o quitarla según sea necesario.
            //this.pREDIOSTableAdapter.Fill(this.acueductoDataSet.PREDIOS);

        }

        private void GridUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            posicion = GridPredio.CurrentRow.Index;

            id = int.Parse(GridPredio.CurrentRow.Cells[0].Value.ToString());
            catastro = GridPredio.CurrentRow.Cells[1].Value.ToString();
            this.txtCatastro.Text = catastro;
            string barrio = GridPredio.CurrentRow.Cells[4].Value.ToString();
            index = comboBarrio.FindString(barrio);
            this.comboBarrio.Text = barrio;
            string estrato = GridPredio.CurrentRow.Cells[3].Value.ToString();
            this.comboEstrato.Text = estrato;
            index = comboEstrato.FindString(estrato);
            string cedula = GridPredio.CurrentRow.Cells[2].Value.ToString();
            this.txtCedula.Text = cedula;
            CapaDatos.DataSet1TableAdapters.PREDIOSTableAdapter predioExistencia = new CapaDatos.DataSet1TableAdapters.PREDIOSTableAdapter();
            estado = int.Parse(GridPredio.CurrentRow.Cells[5].Value.ToString());


            string estadoPredio = GridPredio.CurrentRow.Cells[5].Value.ToString();
            //Poner el estado en el comboBox
            if (estadoPredio == "1")
            {
                estadoStri = "Activo";
                int index = comboEstado.FindString(estadoStri);
                comboEstado.SelectedIndex = index;
            }
            else
            {
                estadoStri = "Inactivo";
                int index = comboEstado.FindString(estadoStri);
                comboEstado.SelectedIndex = index;
            }





        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
           

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.bARRIOSTableAdapter1.FillBy1(this.dataSet1.BARRIOS);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
